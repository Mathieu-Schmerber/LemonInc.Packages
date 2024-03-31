using System;
using System.Collections.Generic;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.GraphView
{
	/// <summary>
	/// Simple search window listing nodes.
	/// </summary>
	/// <seealso cref="GraphViewSearchWindowBase" />
	public class GraphViewSearchWindow : GraphViewSearchWindowBase
	{
		/// <summary>
		/// The on selected.
		/// </summary>
		private Action<Type> _onSelected;

		/// <summary>
		/// The node types.
		/// </summary>
		private IEnumerable<Type> _nodeTypes;

		/// <summary>
		/// Initializes the search window.
		/// </summary>
		/// <param name="nodeTypes">The node types.</param>
		/// <param name="onItemSelected">The on item selected.</param>
		public void Initialize(IEnumerable<Type> nodeTypes, Action<Type> onItemSelected)
		{
			_nodeTypes = nodeTypes;
			_onSelected = onItemSelected;
		}

		/// <summary>
		/// Generates data to populate the search window.
		/// </summary>
		/// <param name="context">Contextual data initially passed the window when first created.</param>
		/// <returns>
		/// Returns the list of SearchTreeEntry objects displayed in the search window.
		/// </returns>
		public override List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
		{
			var result = new List<SearchTreeEntry> { new SearchTreeGroupEntry(new GUIContent("Nodes")) };

			_nodeTypes.ForEach(x => result.Add(new SearchTreeEntry(new GUIContent(x.Name))
			{
				level = 1,
				userData = x
			}));

			return result;
		}

		/// <summary>
		/// Called when [select entry].
		/// </summary>
		/// <param name="searchTreeEntry">The search tree entry.</param>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public override bool OnSelectEntry(SearchTreeEntry searchTreeEntry, SearchWindowContext context)
		{
			if (searchTreeEntry.userData is not Type nodeType) 
				return false;

			_onSelected?.Invoke(nodeType);
			return true;

		}
	}
}
