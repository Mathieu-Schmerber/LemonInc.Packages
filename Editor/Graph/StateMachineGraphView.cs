using System.Linq;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Core.Utilities.Editor.Ui.GraphView;
using LemonInc.Core.Utilities.Editor.Ui.GraphView.Interfaces;
using UnityEditor;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor.Graph
{
	/// <summary>
	/// State machine graph view
	/// </summary>
	public class StateMachineGraphView : GraphViewBase<StateNodeView, ScriptableState>
	{
		public new class UxmlFactory : UxmlFactory<StateMachineGraphView> { }

		/// <summary>
		/// The controller.
		/// </summary>
		private StateMachineController _controller;

		/// <inheritdoc/>
		protected override bool HandlesCopyPaste => true;

		/// <summary>
		/// Initializes a new instance of the <see cref="StateMachineGraphView"/> class.
		/// </summary>
		public StateMachineGraphView()
		{
			AddMiniMap();
			AddSearchWindow();
		}

		/// <summary>
		/// Initializes the specified state machine.
		/// </summary>
		/// <param name="stateMachine">The state machine.</param>
		public void Initialize(ScriptableStateMachine stateMachine)
		{
			_controller.StateMachine = stateMachine;
		}

		/// <summary>
		/// Creates the controller.
		/// </summary>
		/// <returns></returns>
		protected override INodeController<ScriptableState> CreateController()
		{
			_controller = new StateMachineController();
			return _controller;
		}

		/// <summary>
		/// Called when [node created].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected override void OnNodeCreated(StateNodeView nodeView)
		{
			AddToSelection(nodeView);
			nodeView.StartRename();
		}

		/// <summary>
		/// Called when [node added].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected override void OnNodeAdded(StateNodeView nodeView)
		{
			HandleInitialState(nodeView);
		}

		/// <summary>
		/// Called when [node added].
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		protected override void OnNodeDeleted(StateNodeView nodeView)
		{
			if (!nodeView.Data.Id.Equals(_controller.StateMachine.InitialState.Id)) 
				return;

			_controller.StateMachine.InitialState = _controller.GetAllNodes().FirstOrDefault();
			if (_controller.StateMachine.InitialState != null)
				GetNodeView(_controller.StateMachine.InitialState!.Id)?.ToggleInitialState(true, false);
		}

		/// <summary>
		/// Handles the initial state.
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		private void HandleInitialState(StateNodeView nodeView)
		{
			_controller.StateMachine.InitialState ??= nodeView.Data;
			nodeView.ToggleInitialState(nodeView.Data.Id.Equals(_controller.StateMachine.InitialState.Id), false);
			nodeView.OnInitialStateToggled = () =>
			{
				GetNodeView(_controller.StateMachine.InitialState.Id)?.ToggleInitialState(false, false);
				_controller.StateMachine.InitialState = nodeView.Data;

				EditorUtility.SetDirty(_controller.StateMachine);
				AssetDatabase.SaveAssets();
			};
		}

		/// <summary>
		/// Clears the graph.
		/// </summary>
		public void ClearGraph()
		{
			foreach (var node in nodes)
				RemoveElement(node);

			foreach (var edge in edges)
				RemoveElement(edge);
		}
	}
}
