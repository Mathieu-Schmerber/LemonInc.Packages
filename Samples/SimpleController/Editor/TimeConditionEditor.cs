using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine._Samples.SimpleController.Editor
{
	/// <summary>
	/// Time condition editor.
	/// </summary>
	/// <seealso cref="UnityEditor.Editor" />
	[CustomEditor(typeof(TimeCondition))]
	public class TimeConditionEditor : UnityEditor.Editor
	{
		public override VisualElement CreateInspectorGUI()
		{
			var root = new VisualElement()
			{
				style =
				{
					flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
					unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleCenter)
				}
			};
			
			root.Add(new FloatField(10)
			{
				bindingPath = "_duration"
			});
			root.Add(new Label("seconds")
			{
				style = { marginLeft = new StyleLength(5)}
			});
			return root;
		}
	}
}