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

			LemonIncEditorUtilities.DrawTexture(new Rect(rect.center, new Vector2(50, 50)), Databases.Test.Okk.Err.Angry, ScaleMode.ScaleToFit, Pivot.SPRITE, _time * 10);
			LemonIncEditorUtilities.DrawRect(new Rect(rect.center, new Vector2(5, 5)), Color.cyan, Pivot.CENTER);


			EditorGUILayout.Space(rect.height);
		}
	}
}
