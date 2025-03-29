using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Extends any type of UnityEngine.Vector
	/// </summary>
	public static class VectorExtension
	{
		/// <summary>
		/// The iso matrix.
		/// </summary>
		private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

		/// <summary>
		/// Rotates a direction by the given euler.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <param name="euler">The euler.</param>
		/// <returns>The rotated vector.</returns>
		public static Vector3 Rotate(this Vector3 direction, Vector3 euler)
		{
			var matrix = Matrix4x4.Rotate(Quaternion.Euler(euler));

			return matrix.MultiplyPoint3x4(direction);
		}

		/// <summary>
		/// Rotates a point around a pivot.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <param name="euler">The euler.</param>
		/// <param name="pivot">The pivot.</param>
		/// <returns>The rotated point.</returns>
		public static Vector3 RotatePoint(this Vector3 point, Vector3 euler, Vector3 pivot)
		{
			var dir = point - pivot;
			var normalized = point / dir.magnitude;
			var rotate = normalized.Rotate(euler);

			return rotate * dir.magnitude;
		}

		/// <summary>
		/// Rotates a point around a pivot.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <param name="euler">The euler.</param>
		/// <param name="pivot">The pivot.</param>
		/// <returns></returns>
		public static Vector3Int RotatePoint(this Vector3Int point, Vector3Int euler, Vector3Int pivot)
		{
			return Vector3Int.RoundToInt(((Vector3)point).RotatePoint(euler, pivot));
		}

		/// <summary>
		/// Converts a Vector3 as isometric
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static Vector3 ToIsometric(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);

		/// <summary>
		/// Return the array's closest position to the given point.
		/// </summary>
		public static Vector3 Closest(this Vector3[] input, Vector3 point)
		{
			var best = Vector3.zero;
			var bestDistance = Mathf.Infinity;

			if (input == null || input.Length == 0)
				throw new ArgumentNullException("input was null or empty");

			foreach (var p in input)
			{
				var distance = Vector3.Distance(point, p);
				if (!(distance < bestDistance)) 
					continue;

				best = p;
				bestDistance = distance;
			}
			return best;
		}

		/// <summary>
		/// Return the list closest position to the given point.
		/// </summary>
		public static Vector3 Closest(this IEnumerable<Vector3> input, Vector3 point) => input.ToArray().Closest(point);

		/// <summary>
		/// Converts a Vector2 to a Vector3, translating to X and Z
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Vector3 ToVector3Xz(this Vector2 vector, float y = 0) => new(vector.x, y, vector.y);
		public static Vector3 ToVector3Xz(this Vector2Int vector, float y = 0) => new(vector.x, y, vector.y);

		/// <summary>
		/// Converts a Vector2 to a Vector3, translating to X and Y
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Vector3 ToVector3Xy(this Vector2 vector, float z = 0) => new(vector.x, vector.y, z);
		public static Vector3 ToVector3Xy(this Vector2Int vector, float z = 0) => new(vector.x, vector.y, z);

		/// <summary>
		/// Returns the vector setting its X
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="x"></param>
		/// <returns></returns>
		public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);

		/// <summary>
		/// Returns the vector setting its Y
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Vector3 WithY(this Vector3 vector, float y) => new(vector.x, y, vector.z);

		/// <summary>
		/// Returns the vector setting its Z
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static Vector3 WithZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);

		public static Vector2 ToVector2Xy(this Vector3 vector) => new(vector.x, vector.y);
		public static Vector2 ToVector2Xz(this Vector3 vector) => new(vector.x, vector.z);
		public static Vector2 ToVector2Yz(this Vector3 vector) => new(vector.y, vector.z);

		public static Vector2 InvertXy(this Vector2 vector) => new(vector.y, vector.x);
		public static Vector2 InvertXy(this Vector2Int vector) => new(vector.y, vector.x);
		public static Vector3 InvertXy(this Vector3 vector) => new(vector.y, vector.x, vector.z);
		public static Vector3 InvertXz(this Vector3 vector) => new(vector.z, vector.y, vector.x);
		public static Vector3 InvertYz(this Vector3 vector) => new(vector.x, vector.z, vector.y);
		public static Vector3Int InvertXy(this Vector3Int vector) => new(vector.y, vector.x, vector.z);
		public static Vector3Int InvertXz(this Vector3Int vector) => new(vector.z, vector.y, vector.x);
		public static Vector3Int InvertYz(this Vector3Int vector) => new(vector.x, vector.z, vector.y);
		
		public static float2 ToFloat2(this Vector2 vector) => new float2(vector.x, vector.y);
		public static float2 ToFloat2(this Vector2Int vector) => new float2(vector.x, vector.y);
		public static float3 ToFloat3(this Vector3 vector) => new float3(vector.x, vector.y, vector.z);
		public static float3 ToFloat3(this Vector3Int vector) => new float3(vector.x, vector.y, vector.z);

		public static int2 ToInt2(this Vector2 vector) => new int2((int)vector.x, (int)vector.y);
		public static int2 ToInt2(this Vector2Int vector) => new int2(vector.x, vector.y);
		public static int3 ToInt3(this Vector3 vector) => new int3((int)vector.x, (int)vector.y, (int)vector.z);
		public static int3 ToInt3(this Vector3Int vector) => new int3(vector.x, vector.y, vector.z);
	}
}