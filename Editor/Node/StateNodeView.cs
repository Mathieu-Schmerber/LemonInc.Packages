using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Editor.Utilities.Ui.Graph;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

namespace LemonInc.Core.StateMachine.Editor.Node
{
	/// <summary>
	/// <see cref="NodeViewBase{TNodeData}"/> implementation for <see cref="ScriptableState"/>.
	/// </summary>
	/// <seealso cref="ScriptableState" />
	public class StateNodeView : NodeViewBase<ScriptableState>
	{
		/// <summary>
		/// The initial state uss class.
		/// </summary>
		public const string INITIAL_STATE = "initialState";

		protected override NodeType Type => NodeType.WITHOUT_PORTS;
		public override bool AllowSelfLinking => false;
		public override bool IsRenamable() => true;

		private VisualElement _nodeTitle;
		private readonly VisualElement _initialStateText;

		private bool _initialState = false;

		/// <summary>
		/// Gets or sets the on initial state toggled.
		/// </summary>
		/// <value>
		/// The on initial state toggled.
		/// </value>
		public Action OnInitialStateToggled { get; set; }

		/// <summary>
		/// Gets or sets the on renamed.
		/// </summary>
		/// <value>
		/// The on renamed.
		/// </value>
		public Action OnNodeRenamed { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StateNodeView"/> class.
		/// </summary>
		public StateNodeView()
		{
			_initialStateText = new Label("Initial") { name = "initialStateText" };
			titleContainer.Insert(0, _initialStateText);
		}

		/// <inheritdoc/>
		protected override void OnDataBound()
		{
			var foldout = titleContainer.Q("title-button-container");
			titleContainer.Remove(foldout);

			_nodeTitle = this.Q("title-label");
			_nodeTitle.name = "nodeTitle"; // Cleanse builtin styles
		}

		/// <inheritdoc/>
		protected override IEnumerable<Port> InstantiateInputPorts()
		{
			var input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Multi, typeof(ScriptableState));
			
			return new[] { input };
		}

		/// <inheritdoc/>
		protected override IEnumerable<Port> InstantiateOutputPorts()
		{
			var output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(ScriptableState));

			return new[] { output };
		}

		/// <inheritdoc/>
		public override List<EdgeView> LinkPorts(List<NodeViewBase<ScriptableState>> nodes)
		{
			return nodes.Select(nodeView => ConnectPorts(InputPorts[0], nodeView.OutputPorts[0])).ToList();
		}

		/// <inheritdoc/>
		protected override void OnRenamed(string newName)
		{
			var oldName = Data.name;

			if (string.IsNullOrWhiteSpace(newName))
			{
				this.title = oldName;
				Data.Alias = oldName;
				return;
			}

			Data.name = newName;
			EditorUtility.SetDirty(Data);
			AssetDatabase.SaveAssets();
			OnNodeRenamed?.Invoke();
		}

		/// <summary>
		/// Add menu items to the node contextual menu.
		/// </summary>
		/// <param name="evt">The event holding the menu to populate.</param>
		public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
		{
			base.BuildContextualMenu(evt);

			evt.menu.InsertAction(2, "Set as Initial", _ => ToggleInitialState(true), 
				status: _initialState ? DropdownMenuAction.Status.Disabled : DropdownMenuAction.Status.Normal);
			evt.menu.InsertSeparator("", 2);
		}

		/// <summary>
		/// Toggles the initial state.
		/// </summary>
		/// <param name="initialState">if set to <c>true</c> [initial state].</param>
		/// <param name="notify"></param>
		public void ToggleInitialState(bool initialState, bool notify = true)
		{
			_initialState = initialState;

			if (_initialState)
			{
				_nodeTitle.AddToClassList(INITIAL_STATE);
				if (notify)
					OnInitialStateToggled?.Invoke();
			}
			else
				_nodeTitle.RemoveFromClassList(INITIAL_STATE);

			_initialStateText.style.display = new StyleEnum<DisplayStyle>(_initialState ? DisplayStyle.Flex : DisplayStyle.None);
		}
	}
}