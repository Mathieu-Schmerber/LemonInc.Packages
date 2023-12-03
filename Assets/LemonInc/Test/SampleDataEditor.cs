using LemonInc.Core.Utilities;
using LemonInc.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace Assets.LemonInc.Test
{
	[CustomEditor(typeof(SampleData))]
	public class SampleDataEditor : Editor
	{
		private float _time;

		public override bool RequiresConstantRepaint() => true;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();

			var rect = GUILayoutUtility.GetLastRect();
			rect.height += 500;

			_time += Time.deltaTime;

			LemonIncEditorUtilities.DrawRect(rect, Color.cyan);
			LemonIncEditorUtilities.DrawLine(rect.center, rect.min, 3f, Color.red);
			LemonIncEditorUtilities.DrawLine(rect.center, rect.max, 3f, Color.black);
			LemonIncEditorUtilities.DrawLine(rect.center, new Vector2(rect.xMax, rect.yMin), 3f, Color.green);
			LemonIncEditorUtilities.DrawLine(rect.center, new Vector2(rect.xMin, rect.yMax), 3f, Color.yellow);
			LemonIncEditorUtilities.DrawArrow(rect.center, 5f, rect.size.y / 2f, 20f, ColorUtilities.RandomColor(), _time % 360);

			EditorGUILayout.Space(rect.height);
		}
	}
}
