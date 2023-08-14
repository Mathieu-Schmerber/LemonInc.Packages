using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Core.StateMachine.Scriptables;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using EditorIcons = LemonInc.Editor.Utilities.EditorIcons;

namespace LemonInc.Core.StateMachine.Editor
{
	[CustomEditor(typeof(ScriptableState))]
	public class ScriptableStateEditor : UnityEditor.Editor
    {
        private enum ActionType { Entry, Update, Physics, Exit }

        private Dictionary<ActionType, Texture> _iconsDictionary;

        private ScriptableState _scriptableState;
        public ScriptableState ScriptableState => _scriptableState ??= target as ScriptableState;

        private void OnEnable()
        {
			_iconsDictionary = new Dictionary<ActionType, Texture>
			{
				{ ActionType.Entry, EditorIcons.Sceneloadin.image },
				{ ActionType.Update, EditorIcons.DPreaudioloopoff.image },
				{ ActionType.Physics, EditorIcons.DProfilerPhysics.image },
				{ ActionType.Exit, EditorIcons.Sceneloadout.image }
			};
		}

        public override VisualElement CreateInspectorGUI()
        {
	        var root = new VisualElement();
	        root.AddToClassList("scriptableStateEditor");

	        var actionLists = new Dictionary<ActionType, IReadOnlyList<IStateAction>>()
	        {
		        { ActionType.Entry, ScriptableState.EntryActions },
		        { ActionType.Update, ScriptableState.StateActions },
		        { ActionType.Physics, ScriptableState.PhysicsActions },
		        { ActionType.Exit, ScriptableState.ExitActions },
	        };

	        foreach (var (type, list) in actionLists)
	        {
		        var titledList =
			        new TitledList<ScriptableAction, Widget<ScriptableAction>>(list.Cast<ScriptableAction>().ToList(),
				        type.ToString(), _iconsDictionary[type])
			        {
				        OnCreate = created => OnActionCreated(list, created, type),
				        OnDeleted = deleted => OnActionDeleted(deleted, type)
			        };

				titledList.AddToClassList("actionList");
				root.Add(titledList);
			}

	        return root;
        }

		#region Action Handling

		/// <summary>
		/// Adds the type of the action by.
		/// </summary>
		/// <param name="actionType">Type of the action.</param>
		/// <param name="item">The item.</param>
		private void AddActionByType(ActionType actionType, IStateAction item)
        {
            switch (actionType)
            {
                case ActionType.Entry:
                    ScriptableState.AddEntryAction(item);
                    break;
                case ActionType.Exit:
                    ScriptableState.AddExitAction(item);
                    break;
                case ActionType.Update:
                    ScriptableState.AddStateAction(item);
                    break;
                case ActionType.Physics:
                    ScriptableState.AddPhysicsAction(item);
                    break;
            }
        }

		/// <summary>
		/// Called when [action created].
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="created">The created.</param>
		/// <param name="type">The type.</param>
		private void OnActionCreated(IEnumerable<IStateAction> list, ScriptableAction created, ActionType type)
        {
	        if (list.Contains(created))
		        return;

	        AssetDatabase.AddObjectToAsset(created, target);
	        AddActionByType(type, created);
	        Save();
        }

		/// <summary>
		/// Called when [action deleted].
		/// </summary>
		/// <param name="deleted">The deleted.</param>
		/// <param name="actionType">Type of the action.</param>
		private void OnActionDeleted(ScriptableAction deleted, ActionType actionType)
		{
			if (deleted == null)
				return;
			
			RemoveActionByType(actionType, deleted);
            AssetDatabase.RemoveObjectFromAsset(deleted);
            Save();
        }

		/// <summary>
		/// Removes the type of the action by.
		/// </summary>
		/// <param name="actionType">Type of the action.</param>
		/// <param name="action">The action.</param>
		private void RemoveActionByType(ActionType actionType, IStateAction action)
        {
            switch (actionType)
            {
                case ActionType.Entry:
                    ScriptableState.RemoveEntryAction(action);
                    break;
                case ActionType.Exit:
                    ScriptableState.RemoveExitAction(action);
                    break;
                case ActionType.Update:
                    ScriptableState.RemoveStateAction(action);
                    break;
                case ActionType.Physics:
                    ScriptableState.RemovePhysicsAction(action);
                    break;
            }
        }

		#endregion
		
		/// <summary>
		/// Saves this instance.
		/// </summary>
		private void Save()
        {
            var main = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(target));
			
            EditorUtility.SetDirty(main);
            AssetDatabase.SaveAssets();
        }
    }
}