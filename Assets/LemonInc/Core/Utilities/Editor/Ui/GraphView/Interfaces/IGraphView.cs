using System;
using LemonInc.Core.Utilities.Graph;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Core.Utilities.Editor.Ui.GraphView.Interfaces
{
	public interface IGraphView<TNodeView, TNodeData>
		where TNodeView : UnityEditor.Experimental.GraphView.Node, INodeView<TNodeData>, new() 
		where TNodeData : ScriptableObject, INode
	{
		/// <summary>
		/// Gets or sets the on node created.
		/// </summary>
		/// <value>
		/// The on node created.
		/// </value>
		Action<TNodeView> OnNodeCreatedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node selected.
		/// </summary>
		/// <value>
		/// The on node selected.
		/// </value>
		Action<TNodeView> OnNodeSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node un selected.
		/// </summary>
		/// <value>
		/// The on node un selected.
		/// </value>
		Action<TNodeView> OnNodeUnSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node created.
		/// </summary>
		/// <value>
		/// The on node created.
		/// </value>
		Action<EdgeView> OnEdgeSelectedCallback { get; set; }

		/// <summary>
		/// Gets or sets the on node selected.
		/// </summary>
		/// <value>
		/// The on node selected.
		/// </value>
		Action<EdgeView> OnEdgeUnSelectedCallback { get; set; }

		/// <summary>
		/// Adds the style.
		/// </summary>
		/// <param name="styleSheet">The style.</param>
		void AddStyle(StyleSheet styleSheet);

		/// <summary>
		/// Populates the graph.
		/// </summary>
		void Populate();
	}
}