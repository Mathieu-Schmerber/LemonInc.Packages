using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Tooltip
{
	/// <summary>
	/// <see cref="Tooltip"/> property drawer.
	/// </summary>
	[CustomPropertyDrawer(typeof(Tooltip))]
	public class TooltipPropertyDrawer : PropertyDrawer
	{
		/// <summary>
		/// Override this method to make your own GUI based GUI for the property.
		/// </summary>
		/// <param name="position">Rectangle on the screen to use for the property GUI.</param>
		/// <param name="property">The SerializedProperty to make the custom GUI for.</param>
		/// <param name="label">The label of this property.</param>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var tooltip = ((Tooltip)attribute).Content;
			var labelSize = GetLabelSize(property.name + "\t");
			var btnRect = new Rect(position.position.x + labelSize.x, position.position.y, EditorGUIUtility.singleLineHeight, EditorGUIUtility.singleLineHeight);

			label.tooltip = tooltip;
			EditorGUI.PropertyField(position, property, label);
			GUI.Button(btnRect, new GUIContent(EditorIcons.Help2X.image, tooltip), GetStyle());
		}

		/// <summary>
		/// Override this method to specify how tall the GUI for this field is in pixels.
		/// </summary>
		/// <param name="property">The SerializedProperty to make the custom GUI for.</param>
		/// <param name="label">The label of this property.</param>
		/// <returns>
		/// The height in pixels.
		/// </returns>
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}

		/// <summary>
		/// Gets the style.
		/// </summary>
		/// <returns></returns>
		private static GUIStyle GetStyle()
		{
			var style = new GUIStyle(GUI.skin.label)
			{
				margin = new RectOffset()
			};

			return style;
		}

		/// <summary>
		/// Gets the size of the label.
		/// </summary>
		/// <param name="label">The label.</param>
		/// <returns></returns>
		private static Vector2 GetLabelSize(string label) => GUI.skin.label.CalcSize(new GUIContent(label));
	}
}
