using System.Linq;
using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Core.Utilities.Editor;
using UnityEditor;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	public class StateTransitionEditor : VisualElement
	{
		private readonly StateTransition _transition;
		private readonly ScriptableState _target;

		/// <summary>
		/// Initializes a new instance of the <see cref="StateTransitionEditor"/> class.
		/// </summary>
		/// <param name="transition">The transition.</param>
		/// <param name="target">The target.</param>
		public StateTransitionEditor(StateTransition transition, ScriptableState target)
		{
			_transition = transition;
			_target = target;

			var conditionList = new TitledList<ScriptableCondition, Widget<ScriptableCondition>>(
				transition.Conditions.Cast<ScriptableCondition>().ToList(),
				title: "Conditions",
				icon: EditorIcons.Help2X.image) 
			{
				OnCreate = OnConditionCreated,
				OnDeleted = OnConditionDeleted
			};

			conditionList.AddToClassList("conditionList");
			Add(conditionList);
		}

		private void OnConditionDeleted(ScriptableCondition condition)
		{
			if (condition == null)
				return;

			_transition.RemoveCondition(condition);
			AssetDatabase.RemoveObjectFromAsset(condition);
			Save();
		}

		private void OnConditionCreated(ScriptableCondition condition)
		{
			if (_transition.Conditions.Contains(condition))
				return;

			AssetDatabase.AddObjectToAsset(condition, _target);
			_transition.AddCondition(condition);
			Save();
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		private void Save()
		{
			var main = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(_target));

			EditorUtility.SetDirty(main);
			AssetDatabase.SaveAssets();
		}
	}
}