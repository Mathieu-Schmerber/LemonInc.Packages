using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Ui.Graph;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Scriptables
{
	/// <summary>
	/// Implementation of <see cref="IStateMachine"/> for <see cref="ScriptableObject"/>.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="LemonInc.Core.StateMachine.Interfaces.IStateMachine" />
	[CreateAssetMenu(menuName = "Lemon Inc/State Machine", fileName = "State Machine")]
    public class ScriptableStateMachine : ScriptableObject, IStateMachine, INodeContainer<ScriptableState>
    {
        [SerializeField] private ScriptableState _initialState;
		
		#region IStateMachine

		/// <inheritdoc/>
		public IState InitialState
		{
			get => _initialState;
			set => _initialState = value as ScriptableState;
		}

		/// <inheritdoc/>
		public IState ProcessTransitions(StateComponent stateComponent, IState currentState)
		{
			if (currentState.Transitions.IsNullOrEmpty())
				return currentState;

			foreach (var stateTransition in currentState.Transitions)
			{
				if (stateTransition.Conditions.IsNullOrEmpty())
					return stateTransition.SuccessState ?? currentState;

				if (stateTransition.Conditions.All(condition => condition.Verify(stateComponent)))
					return stateTransition.SuccessState;
			}

			return currentState;
		}

		#endregion

		#region INodeContainer

		/// <inheritdoc/>
		public IEnumerable<ScriptableState> GetAllNodes()
		{
			var path = AssetDatabase.GetAssetPath(this);
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

			AddNode(state);
			return state;
		}

		/// <inheritdoc/>
		public void AddNode(ScriptableState state)
		{
			EditorGUIUtility.SetIconForObject(state, EditorGUIUtility.IconContent("d_AnimatorController Icon").image as Texture2D);
			AssetDatabase.AddObjectToAsset(state, this);
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public void DeleteNode(ScriptableState node)
		{
			DeleteActions(node);

			AssetDatabase.RemoveObjectFromAsset(node);
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
		}
		
		/// <inheritdoc/>
		public void LinkNodes(ScriptableState inputNode, ScriptableState outputNode)
		{
			var transition = new StateTransition(outputNode);

			inputNode.AddTransition(transition);
			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
		}

		/// <inheritdoc/>
		public void UnlinkNodes(ScriptableState inputNode, ScriptableState outputNode)
		{
			var remove = inputNode.Transitions.Where(tr => tr.SuccessState.Id.Equals(outputNode.Id)).ToList();

			foreach (var stateTransition in remove)
			{
				foreach (var stateTransitionCondition in stateTransition.Conditions)
					AssetDatabase.RemoveObjectFromAsset(stateTransitionCondition as ScriptableCondition);
				inputNode.RemoveTransition(stateTransition);
			}

			EditorUtility.SetDirty(this);
			AssetDatabase.SaveAssets();
		}

		/// <summary>
		/// Gets the children of a node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		public IEnumerable<ScriptableState> GetChildren(ScriptableState node)
			=> node.Transitions.Select(x => x.SuccessState).Cast<ScriptableState>();

		#endregion

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
