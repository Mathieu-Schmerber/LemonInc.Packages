using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// <see cref="Bounds"/> extensions.
	/// </summary>
	public static class BoundsExtensions
	{
		/// <summary>
		/// Gets a random point.
		/// </summary>
		/// <param name="bounds">The bounds.</param>
		/// <returns>The <see cref="Vector3"/> point.</returns>
		public static Vector3 GetRandomPoint(this Bounds bounds)
		{
			return new Vector3(
				Random.Range(bounds.min.x, bounds.max.x),
				Random.Range(bounds.min.y, bounds.max.y),
				Random.Range(bounds.min.z, bounds.max.z)
			);
		}

		/// <summary>
		/// Gets a random edge point.
		/// </summary>
		/// <param name="bounds">The bounds.</param>
		/// <returns>The <see cref="Vector3"/> edge point.</returns>
		public static Vector3 GetRandomEdgePoint(this Bounds bounds)
		{
			const int max = 1;
			const int min = 0;
			const int free = 2;
			int[] limitAxis = { Random.Range(min, max + 1), Random.Range(min, max + 1), Random.Range(min, max + 1) };

			limitAxis[Random.Range(0, 3)] = free;

			return new Vector3(
				limitAxis[0] == max ? bounds.max.x : limitAxis[0] == min ? bounds.min.x : Random.Range(bounds.min.x, bounds.max.x),
				limitAxis[1] == max ? bounds.max.y : limitAxis[1] == min ? bounds.min.y : Random.Range(bounds.min.y, bounds.max.y),
				limitAxis[2] == max ? bounds.max.z : limitAxis[2] == min ? bounds.min.z : Random.Range(bounds.min.z, bounds.max.z)
			);
		}
	}
}