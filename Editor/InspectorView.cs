using System.Linq;
using LemonInc.Core.StateMachine.Editor.Graph;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Core.Utilities.Editor.Ui.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	/// <summary>
	/// Inspector view.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.VisualElement" />
	public class InspectorView : VisualElement
	{
		public new class UxmlFactory : UxmlFactory<InspectorView> { }

		private StateTransitionEditor _stateTransitionEditor;
		private readonly Label _selectedElement;
		private readonly VisualElement _contentContainer;

		public InspectorView()
		{
			_selectedElement = new Label { name = "selectedTitle" };
			_contentContainer = new VisualElement
			{
				style = { flexGrow = new StyleFloat(1) }
			};

			Add(_selectedElement);
			Add(_contentContainer);
			ClearInspector();
		}

		/// <summary>
		/// Inspects the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void Inspect(StateNodeView node)
		{
			var editor = UnityEditor.Editor.CreateEditor(node.Data);
			var inspector = new InspectorElement(editor)
			{
				style =
				{
					paddingTop = new StyleLength(Length.None()),
					paddingBottom = new StyleLength(Length.None()),
					paddingLeft = new StyleLength(Length.None()),
					paddingRight = new StyleLength(Length.None()),
					flexGrow = new StyleFloat(1)
				}
			};

			_contentContainer.Clear();
			SetTitleSelected(node.Data.Alias);
			node.OnNodeRenamed = () => SetTitleSelected(node.Data.Alias);
			_contentContainer.Add(inspector);
			this.Bind(editor.serializedObject);
		}
		
		/// <summary>
		/// Inspects the specified edge.
		/// </summary>
		/// <param name="edge">The edge.</param>
		public void Inspect(EdgeView edge)
		{
			_contentContainer.Clear();
			if (edge.input.node is not StateNodeView input ||
			    edge.output.node is not StateNodeView output)
				return;

			var transition = input.Data.Transitions.FirstOrDefault(x => x.SuccessState.Id.Equals(output.Data.Id));
			if (transition is not StateTransition stateTransition)
				return;

			_stateTransitionEditor = new StateTransitionEditor(stateTransition, input.Data);
			SetTitleSelected($"{input.title} -> {edge.output.node.title}");
			_contentContainer.Add(_stateTransitionEditor);
		}

		private void SetTitleSelected(string title)
		{
			_selectedElement.style.display = string.IsNullOrEmpty(title)
				? new StyleEnum<DisplayStyle>(DisplayStyle.None)
				: new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
			_selectedElement.text = title;
		}

		public void ClearInspector()
		{
			SetTitleSelected(null);
			_contentContainer.Clear();
		}
	}
}
