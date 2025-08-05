using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Extends any IEnumerable implementation.
	/// </summary>
	public static class EnumerableExtensions
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

		/// <summary>
		/// Determines whether [is null or empty].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns>
		///   <c>true</c> if [is null or empty] [the specified source]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
		{
			return source == null || !source.Any();
		}

		/// <summary>
		/// Determines whether [is null or empty].
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns>
		///   <c>true</c> if [is null or empty] [the specified source]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty(this IList source)
		{
			return source == null || source.Count == 0;
		}

		/// <summary>
		/// Resizes the specified list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list">The list.</param>
		/// <param name="size">The size.</param>
		/// <param name="createItem">The function creating an item.</param>
		public static void Resize<T>(this List<T> list, int size, Func<int, T> createItem)
		{
			var count = list.Count;

			if (size < count)
			{
				list.RemoveRange(size, count - size);
			}
			else if (size > count)
			{
				if (size > list.Capacity)
					list.Capacity = size;

				for (var i = count; i < size; i++)
				{
					list.Add(createItem(i));
				}
			}
		}
	}
}