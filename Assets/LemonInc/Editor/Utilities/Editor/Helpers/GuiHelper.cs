using LemonInc.Core.Utilities.Extensions;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Helpers
{
	/// <summary>
	/// Gui Helper.
	/// </summary>
	public static class GuiHelper
	{
		public static Color LightColor = Color.white.WithAlpha(.5f);
		public static Color LighterColor = Color.white.WithAlpha(.7f);

		public static Color DarkColor = Color.black.WithAlpha(.5f);
		public static Color DarkerColor = Color.black.WithAlpha(.7f);

		public static class Styles
		{
			public static readonly GUIStyle LineSeparator = new GUIStyle().WithFixedHeight(1).WithMargin(new RectOffset(0, 0, 2, 2));
		}

		public static readonly string ResourcesPath = "Assets/Plugins/Nawlian/Resources/EditorTools";

		public static Texture2D LoadTexture(string name) => AssetDatabase.LoadAssetAtPath<Texture2D>($"{ResourcesPath}/{name}");

		public static Texture2D CreateSingleColorTexture(Color color)
		{
			var texture = new Texture2D(1, 1);

			texture.SetPixel(0, 0, color);
			texture.Apply();
			return texture;
		}

		public static Texture2D CreateOutlineTexture(Color color)
		{
			var texture = new Texture2D(64, 64);
			var alpha = new Color(0, 0, 0, 0);

			for (var x = 0; x < 64; x++)
			{
				for (var y = 0; y < 64; y++)
				{
					var apply = (y < 1 || y > 63) || (x < 1 || x > 63) ? color : alpha;
					texture.SetPixel(x, y, apply);
				}
			}
			texture.Apply();
			return texture;
		}

		public static void DrawLineSeparator(string label = null)
		{
			var hasLabel = !string.IsNullOrEmpty(label);
			EditorGUILayout.BeginVertical();
			var rect = GUILayoutUtility.GetRect(GUIContent.none, Styles.LineSeparator, GUILayout.ExpandWidth(true));
			var labelRect = new Rect();
			GUIContent labelContent = null;
			if (hasLabel)
			{
				labelContent = new GUIContent(label);
				labelRect = GUILayoutUtility.GetRect(labelContent, EditorStyles.miniLabel, GUILayout.ExpandWidth(true));
			}
			EditorGUILayout.EndVertical();

			if (Event.current.type != EventType.Repaint)
				return;

			var orgColor = GUI.color;
			var tintColor = EditorGUIUtility.isProSkin ? new Color(0.12f, 0.12f, 0.12f, 1.333f) : new Color(0.6f, 0.6f, 0.6f, 1.333f);
			GUI.color *= tintColor;
			GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
			GUI.color = orgColor;

			if (hasLabel)
				EditorGUI.LabelField(labelRect, labelContent, EditorStyles.miniLabel);
		}

		public static GUIStyle WithNormalBackground(this GUIStyle style, Texture2D background)
		{
			style.normal.background = background;
			return style;
		}

		public static GUIStyle WithNormalBackground(this GUIStyle style, Color color)
		{
			var texture = new Texture2D(1, 1);

			texture.SetPixel(0, 0, color);
			texture.Apply();
			style.normal.background = texture;
			return style;
		}

		public static GUIStyle WithNormalOutlineBackground(this GUIStyle style, Color color)
		{
			var texture = CreateOutlineTexture(color);
			style.normal.background = texture;
			return style;
		}

		public static GUIStyle WithFontSize(this GUIStyle style, int fontSize)
		{
			style.fontSize = fontSize;
			return style;
		}

		public static GUIStyle WithFontStyle(this GUIStyle style, FontStyle fontStyle)
		{
			style.fontStyle = fontStyle;
			return style;
		}

		public static GUIStyle WithAlignment(this GUIStyle style, TextAnchor alignment)
		{
			style.alignment = alignment;
			return style;
		}

		public static GUIStyle WithMargin(this GUIStyle style, RectOffset margin)
		{
			style.margin = margin;
			return style;
		}

		public static GUIStyle WithBorder(this GUIStyle style, RectOffset border)
		{
			style.border = border;
			return style;
		}

		public static GUIStyle WithBorder(this GUIStyle style, RectOffset border, Color color)
		{
			var texture = CreateOutlineTexture(color);

			style.normal.background = texture;
			style.border = border;
			return style;
		}

		public static GUIStyle WithPadding(this GUIStyle style, RectOffset padding)
		{
			style.padding = padding;
			return style;
		}

		public static GUIStyle WithFixedWidth(this GUIStyle style, int fixedWidth)
		{
			style.fixedWidth = fixedWidth;
			return style;
		}

		public static GUIStyle WithFixedHeight(this GUIStyle style, int fixedHeight)
		{
			style.fixedHeight = fixedHeight;
			return style;
		}

		public static GUIStyle WithRichText(this GUIStyle style, bool richText = true)
		{
			style.richText = richText;
			return style;
		}

		public static GUIStyle WithFont(this GUIStyle style, Font font)
		{
			style.font = font;
			return style;
		}

		public static GUIStyle WithContentOffset(this GUIStyle style, Vector2 contentOffset)
		{
			style.contentOffset = contentOffset;
			return style;
		}

		public static GUIStyle WithNormalTextColor(this GUIStyle style, Color textColor)
		{
			style.normal.textColor = textColor;
			return style;
		}
	}
}