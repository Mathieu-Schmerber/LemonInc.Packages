using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.SearchWindows
{
	/// <summary>
	/// Provides with a search window which can be open and configured without the need of creating a new class.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="UnityEditor.Experimental.GraphView.ISearchWindowProvider" />
	public class GenericSearchWindow : ScriptableObject, ISearchWindowProvider
	{
		public Func<List<SearchTreeEntry>> Build { get; set; }
		public Action<SearchTreeEntry, SearchWindowContext> OnEntrySelected { get; set; }

		/// <summary>
		/// Generates data to populate the search window.
		/// </summary>
		/// <param name="context">Contextual data initially passed the window when first created.</param>
		/// <returns>
		/// Returns the list of SearchTreeEntry objects displayed in the search window.
		/// </returns>
		/// <exception cref="System.Exception">The {nameof(GenericSearchWindow)} requires at least one entry.</exception>
		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			var entries = Build?.Invoke();

			if (entries.IsNullOrEmpty<SearchTreeEntry>() || !entries.Any(x => x.GetType() == typeof(SearchTreeGroupEntry)))
				throw new Exception($"The {nameof(GenericSearchWindow)} requires at least one group entry.");
			return entries;
		}

		/// <summary>
		/// Called when [select entry].
		/// </summary>
		/// <param name="searchTreeEntry">The search tree entry.</param>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			if (searchTreeEntry is SearchTreeGroupEntry group)
			{
				return false;
			}

			OnEntrySelected?.Invoke(searchTreeEntry, context);
			return true;
		}
	}
}
