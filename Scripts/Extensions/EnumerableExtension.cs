using System;
using System.Collections.Generic;
using System.Linq;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Extends any IEnumerable implementation.
	/// </summary>
	public static class EnumerableExtension
	{
		/// <summary>
		/// The random.
		/// </summary>
		private static readonly Random random = new Random();

		/// <summary>
		/// Get random element of an enumerable.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static T Random<T>(this IList<T> list)
		{
			int index = random.Next(0, list.Count);
			return list[index];
		}

		/// <summary>
		/// Get random element of an enumerable.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static T Random<T>(this IEnumerable<T> list) => list.ElementAt(random.Next(0, list.Count()));

		/// <summary>
		/// Executes an action for each element of an enumerable.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
				action(item);
		}
	}
}