﻿using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Ui.Graph
{
	/// <summary>
	/// GraphViewSearchWindowBase.
	/// </summary>
	/// <seealso cref="UnityEngine.ScriptableObject" />
	/// <seealso cref="UnityEditor.Experimental.GraphView.ISearchWindowProvider" />
	public abstract class GraphViewSearchWindowBase : ScriptableObject, ISearchWindowProvider
	{
		public abstract List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context);

		public abstract bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context);
	}
}