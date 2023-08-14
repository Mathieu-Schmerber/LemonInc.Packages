using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Ui.GraphView.Interfaces;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Editor.Graph
{
	/// <summary>
	/// Implementation of <see cref="INodeController{TNodeData}"/> for <see cref="ScriptableState"/>.
	/// </summary>
	/// <seealso>
	///     <cref>
	///         LemonInc.Editor.Utilities.Ui.Graph.Interfaces.INodeController&amp;
	///         lt;LemonInc.Core.StateMachine.Scriptables.ScriptableState&amp;gt;
	///     </cref>
	/// </seealso>
	public class StateMachineController : INodeController<ScriptableState>
	{
		/// <summary>
		/// The state machine.
		/// </summary>
		public ScriptableStateMachine StateMachine { get; set; }
		
		/// <inheritdoc/>
		public IEnumerable<ScriptableState> GetAllNodes()
		{
			var path = AssetDatabase.GetAssetPath(StateMachine);
			var assets = AssetDatabase.LoadAllAssetsAtPath(path);
			var result = new List<ScriptableState>();

			foreach (var asset in assets)
			{
				if (asset is ScriptableState state)
					result.Add(state);
			}

			return result;
		}

		/// <inheritdoc/>
		public ScriptableState CreateNodeOfType(Type type)
		{
			var state = ScriptableObject.CreateInstance(type) as ScriptableState;

			Add(state);
			return state;
		}

		/// <inheritdoc/>
		public void Add(ScriptableState node)
		{
			EditorGUIUtility.SetIconForObject(node,
				EditorGUIUtility.IconContent("d_AnimatorController Icon").image as Texture2D);
			AssetDatabase.AddObjectToAsset(node, StateMachine);
			EditorUtility.SetDirty(StateMachine);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public void Delete(ScriptableState node)
		{
			DeleteActions(node);

			AssetDatabase.RemoveObjectFromAsset(node);
			EditorUtility.SetDirty(StateMachine);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public ScriptableState Duplicate(ScriptableState node)
		{
			var copy = node.Clone() as ScriptableState;
			if (copy == null)
				return null;

			foreach (var action in node.EntryActions)
			{
				var dup = (action as ScriptableAction).Clone();
				copy.AddEntryAction(dup);
				AssetDatabase.AddObjectToAsset(dup, StateMachine);
			}

			EditorUtility.SetDirty(StateMachine);
			AssetDatabase.SaveAssets();
			return copy;
		}

		/// <inheritdoc/>
		public void Link(ScriptableState inputNode, ScriptableState outputNode)
		{
			var transition = new StateTransition(outputNode);

			inputNode.AddTransition(transition);
			EditorUtility.SetDirty(StateMachine);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public void Unlink(ScriptableState inputNode, ScriptableState outputNode)
		{
			var remove = inputNode.Transitions.Where(tr => tr.SuccessState.Id.Equals(outputNode.Id)).ToList();

			foreach (var stateTransition in remove)
			{
				foreach (var stateTransitionCondition in stateTransition.Conditions)
					AssetDatabase.RemoveObjectFromAsset(stateTransitionCondition as ScriptableCondition);
				inputNode.RemoveTransition(stateTransition);
			}

			EditorUtility.SetDirty(StateMachine);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public IEnumerable<ScriptableState> GetRelated(ScriptableState node)
			=> node.Transitions.Select(x => x.SuccessState).Cast<ScriptableState>();

		/// <summary>
		/// Deletes the actions.
		/// </summary>
		/// <param name="state">The state.</param>
		private static void DeleteActions(IState state)
		{
			foreach (var action in state.EntryActions)
				AssetDatabase.RemoveObjectFromAsset(action as ScriptableAction);
			foreach (var action in state.StateActions)
				AssetDatabase.RemoveObjectFromAsset(action as ScriptableAction);
			foreach (var action in state.PhysicsActions)
				AssetDatabase.RemoveObjectFromAsset(action as ScriptableAction);
			foreach (var action in state.ExitActions)
				AssetDatabase.RemoveObjectFromAsset(action as ScriptableAction);
		}
	}
}
