using LemonInc.Core.Utilities.Extensions;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Utilities
{
	/// <summary>
	/// LemonInc Editor Utilities.
	/// </summary>
	public static class LemonIncEditorUtilities
	{
		/// <summary>
		/// Draws a rectangle.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="color">The color.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawRect(Rect rect, Color color, float eulerRotationZ = 0)
		{
			var baseMatrix = GUI.matrix;
			if (eulerRotationZ != 0)
			{
				GUI.matrix = Matrix4x4.TRS(rect.center,  Quaternion.Euler(0, 0, eulerRotationZ + baseMatrix.rotation.eulerAngles.z), Vector3.one);
				EditorGUI.DrawRect(new Rect(-rect.width / 2f, -rect.height/2f, rect.width, rect.height), color);
				GUI.matrix = baseMatrix;
			}
			else
			{
				EditorGUI.DrawRect(rect, color);
			}
		}

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
		/// Draws a texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="texture">The texture.</param>
		/// <param name="scaleToFit">The scale to fit.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Texture2D texture, ScaleMode scaleToFit, float eulerRotationZ = 0)
		{
			var baseMatrix = GUI.matrix;
			GUI.matrix = Matrix4x4.TRS(rect.center, Quaternion.Euler(0, 0, eulerRotationZ + baseMatrix.rotation.eulerAngles.z), Vector3.one);
			GUI.DrawTexture(new Rect(-rect.width / 2f, -rect.height / 2f, rect.width, rect.height), texture, scaleToFit);
			GUI.matrix = baseMatrix;
		}

		/// <summary>
		/// Draws a texture.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <param name="sprite">The sprite.</param>
		/// <param name="scaleToFit">The scale to fit.</param>
		/// <param name="eulerRotationZ">The euler rotation z.</param>
		public static void DrawTexture(Rect rect, Sprite sprite, ScaleMode scaleToFit, float eulerRotationZ = 0)
			=> DrawTexture(rect, sprite.ToTexture(), scaleToFit, eulerRotationZ);

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
	}
}
