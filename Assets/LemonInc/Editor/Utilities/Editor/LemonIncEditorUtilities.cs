using System;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

namespace LemonInc.Editor.Utilities
{
	/// <summary>
	/// LemonInc Editor Utilities.
	/// </summary>
	public static class LemonIncEditorUtilities
	{
		/// <summary>
		/// The pivot mapping.
		/// </summary>
		private static Dictionary<Pivot, Vector2> PIVOT_MAPPING = new Dictionary<Pivot, Vector2>()
		{
			{ Pivot.TOP_LEFT, new Vector2(0, 1)},
			{ Pivot.TOP, new Vector2(.5f, 1)},
			{ Pivot.TOP_RIGHT, new Vector2(1, 1)},
			{ Pivot.LEFT, new Vector2(0, .5f)},
			{ Pivot.CENTER, new Vector2(.5f, .5f)},
			{ Pivot.SPRITE, new Vector2(.5f, .5f)},
			{ Pivot.RIGHT, new Vector2(1, .5f)},
			{ Pivot.BOTTOM_LEFT, new Vector2(0, 0)},
			{ Pivot.BOTTOM, new Vector2(.5f, 0)},
			{ Pivot.BOTTOM_RIGHT, new Vector2(1, 0)},
		};

		/// <summary>
		/// Draws a line between two points.
		/// </summary>
		/// <param name="from">The start location.</param>
		/// <param name="to">The end location.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="color">The color.</param>
		public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
		{
			var vector = to - from;
			var direction = vector.normalized;
			var angle = Vector2.SignedAngle(Vector2.right, direction);

			DrawLine(from, thickness, vector.magnitude, color, angle);
		}

		/// <summary>
		/// Draws a line at an angle.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="length">The length.</param>
		/// <param name="color">The color.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawLine(Vector2 position, float thickness, float length, Color color, float eulerRotationZ = 0)
		{
			var baseMatrix = GUI.matrix;
			GUI.matrix = Matrix4x4.TRS(position, Quaternion.Euler(0, 0, eulerRotationZ + baseMatrix.rotation.eulerAngles.z), Vector3.one);
			EditorGUI.DrawRect(new Rect(-thickness / 2f, -thickness / 2f, length, thickness), color);
			GUI.matrix = baseMatrix;
		}

		/// <summary>
		/// Draws an arrow between two points.
		/// </summary>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="tipLength">Length of the tip.</param>
		/// <param name="color">The color.</param>
		public static void DrawArrow(Vector2 from, Vector2 to, float thickness, float tipLength, Color color)
		{
			var vector = to - from;
			var direction = vector.normalized;
			var angle = Vector2.SignedAngle(Vector2.right, direction);

			DrawArrow(from, thickness, vector.magnitude, tipLength, color, angle);
		}

		/// <summary>
		/// Draws an arrow at an angle.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="bodyLength">Length of the body.</param>
		/// <param name="tipLength">Length of the tip.</param>
		/// <param name="color">The color.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawArrow(Vector2 position, float thickness, float bodyLength, float tipLength, Color color, float eulerRotationZ = 0)
		{
			var direction = Vector3.right.Rotate(new Vector3(0, 0, eulerRotationZ)).ToVector2Xy();
			var arrowTip = position + direction.normalized * bodyLength;

			DrawLine(position, thickness, bodyLength, color, eulerRotationZ);
			DrawLine(arrowTip, thickness, tipLength, color, eulerRotationZ + 145f);
			DrawLine(arrowTip, thickness, tipLength, color, eulerRotationZ - 145f);
		}

		/// <summary>
		/// Draws a rect.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="color">The color.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawRect(Rect rect, Color color, Vector2 pivot, float eulerRotationZ = 0)
		{
			var startBotLeft = new Vector2(0, -rect.size.y);
			var pivotAdjustment = rect.size * pivot * new Vector2(1, -1);
			var baseMatrix = GUI.matrix;

			GUI.matrix = Matrix4x4.TRS(rect.position, Quaternion.Euler(0, 0, eulerRotationZ + baseMatrix.rotation.eulerAngles.z), Vector3.one);
			EditorGUI.DrawRect(new Rect(startBotLeft - pivotAdjustment, rect.size), color);
			GUI.matrix = baseMatrix;
		}

		/// <summary>
		/// Draws a rect.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="color">The color.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawRect(Rect rect, Color color, Pivot pivot, float eulerRotationZ = 0)
			=> DrawRect(rect, color, PIVOT_MAPPING[pivot], eulerRotationZ);

		/// <summary>
		/// Draws the texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="texture">The texture.</param>
		/// <param name="scaleMode">The scale to fit.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Texture2D texture, ScaleMode scaleMode, Vector2 pivot, float eulerRotationZ = 0)
		{
			var startBotLeft = new Vector2(0, -rect.size.y);
			var pivotAdjustment = rect.size * pivot * new Vector2(1, -1);
			var baseMatrix = GUI.matrix;

			GUI.matrix = Matrix4x4.TRS(rect.position, Quaternion.Euler(0, 0, eulerRotationZ + baseMatrix.rotation.eulerAngles.z), Vector3.one);
			GUI.DrawTexture(new Rect(startBotLeft - pivotAdjustment, rect.size), texture, scaleMode);
			GUI.matrix = baseMatrix;
		}

		/// <summary>
		/// Draws the texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="sprite">The sprite.</param>
		/// <param name="scaleMode">The scale mode.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="onTextureCreated">The create texture.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Sprite sprite, ScaleMode scaleMode, Vector2 pivot, Action<Texture2D> onTextureCreated = null, float eulerRotationZ = 0)
		{
			var texture = sprite.ToTexture();

			onTextureCreated?.Invoke(texture);
			DrawTexture(rect, texture, scaleMode, pivot, eulerRotationZ);
		}

		/// <summary>
		/// Draws the texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="texture">The texture.</param>
		/// <param name="scaleMode">The scale to fit.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Texture2D texture, ScaleMode scaleMode, Pivot pivot, float eulerRotationZ = 0)
		{
			DrawTexture(rect, texture, scaleMode, PIVOT_MAPPING[pivot], eulerRotationZ);
		}

		/// <summary>
		/// Draws the texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="sprite">The sprite.</param>
		/// <param name="scaleMode">The scale mode.</param>
		/// <param name="pivot">The pivot.</param>
		/// <param name="onTextureCreated">The create texture.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Sprite sprite, ScaleMode scaleMode, Pivot pivot, Action<Texture2D> onTextureCreated = null, float eulerRotationZ = 0)
		{
			var texture = sprite.ToTexture();
			var finalPivot = PIVOT_MAPPING[pivot];
			if (pivot == Pivot.SPRITE)
				finalPivot = sprite.pivot / texture.width;

			onTextureCreated?.Invoke(texture);
			DrawTexture(rect, texture, scaleMode, finalPivot, eulerRotationZ);
		}
	}
}
