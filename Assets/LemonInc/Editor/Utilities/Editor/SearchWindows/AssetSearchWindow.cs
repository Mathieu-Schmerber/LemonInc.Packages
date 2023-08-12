using System;
using System.Collections.Generic;
using LemonInc.Editor.Utilities.Helpers;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Editor.Utilities.SearchWindows
{
	/// <summary>
	/// Asset search provider to use in editor with the <see cref="SearchWindow"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="UnityEditor.Experimental.GraphView.ISearchWindowProvider" />
	public class AssetSearchWindow<T> : ScriptableObject, ISearchWindowProvider
		where T : UnityEngine.Object
	{
		private readonly IList<T> _assets;
		private readonly Action<T> _onEntrySelected;

		/// <summary>
		/// Initializes a new instance of the <see cref="AssetSearchWindow{T}"/> class.
		/// </summary>
		/// <param name="onEntrySelected">The on entry selected.</param>
		public AssetSearchWindow(Action<T> onEntrySelected)
		{
			_onEntrySelected = onEntrySelected;
			_assets = AssetHelper.FindAssetsByType<T>();
		}

		/// <summary>
		/// Generates data to populate the search window.
		/// </summary>
		/// <param name="context">Contextual data initially passed the window when first created.</param>
		/// <returns>
		/// Returns the list of SearchTreeEntry objects displayed in the search window.
		/// </returns>
		public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			var searchList = new List<SearchTreeEntry>();
			var group = new SearchTreeGroupEntry(new GUIContent("List"));

			searchList.Add(group);
			foreach (var item in _assets)
			{
				var entry = new SearchTreeEntry(new GUIContent(item.name, EditorGUIUtility.ObjectContent(item, item.GetType()).image))
				{
					level = 1,
					userData = item
				};

				searchList.Add(entry);
			}
			return searchList;
		}

		/// <summary>
		/// Selects an entry in the search tree list.
		/// </summary>
		/// <param name="searchTreeEntry">The selected entry.</param>
		/// <param name="context">Contextual data to pass to the search window when it is first created.</param>
		/// <returns></returns>
		public bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			_onEntrySelected?.Invoke(searchTreeEntry.userData as T);
			return true;
		}
	}
}