using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Editor.Node;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Ui.Graph;
using UnityEditor;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	/// <summary>
	/// State machine graph view
	/// </summary>
	public class StateMachineGraphView : GraphView<ScriptableStateMachine, StateNodeView, ScriptableState>
	{
		public new class UxmlFactory : UxmlFactory<StateMachineGraphView> {}

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

		/// <inheritdoc/>
		protected override ScriptableState DuplicateNodeData(ScriptableState nodeData)
		{
			var copy = nodeData.Clone() as ScriptableState;
			if (copy == null)
				return null;

			foreach (var action in nodeData.EntryActions)
			{
				var dup = (action as ScriptableAction).Clone();
				copy.AddEntryAction(dup);
				AssetDatabase.AddObjectToAsset(dup, Container);
			}

			EditorUtility.SetDirty(Container);
			AssetDatabase.SaveAssets();
			return copy;
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
			if (nodeView.Data.Id.Equals(Container.InitialState.Id))
			{
				Container.InitialState = Container.GetAllNodes().FirstOrDefault();
				if (Container.InitialState != null)
					GetNodeView(Container.InitialState!.Id)?.ToggleInitialState(true, false);
			}
		}

		/// <summary>
		/// Handles the initial state.
		/// </summary>
		/// <param name="nodeView">The node view.</param>
		private void HandleInitialState(StateNodeView nodeView)
		{
			Container.InitialState ??= nodeView.Data;
			nodeView.ToggleInitialState(nodeView.Data.Id.Equals(Container.InitialState.Id), false);
			nodeView.OnInitialStateToggled = () =>
			{
				GetNodeView(Container.InitialState.Id)?.ToggleInitialState(false, false);
				Container.InitialState = nodeView.Data;

				EditorUtility.SetDirty(Container);
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
