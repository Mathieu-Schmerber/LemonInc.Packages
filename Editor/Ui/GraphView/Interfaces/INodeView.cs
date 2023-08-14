using System;
using System.Collections.Generic;
using LemonInc.Editor.Utilities.Ui.GraphView.Node;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Interfaces
{
	/// <summary>
	/// Node view representation.
	/// </summary>
	/// <typeparam name="TNodeData">The type of the node data.</typeparam>
	public interface INodeView<TNodeData> where TNodeData : class, INode
	{
		/// <summary>
		/// Gets or sets the on selected event.
		/// </summary>
		/// <value>
		/// The on selected event.
		/// </value>
		Action<TNodeData> OnNodeSelectedEvent { get; set; }

		/// <summary>
		/// Gets or sets the on un selected event.
		/// </summary>
		/// <value>
		/// The on un selected event.
		/// </value>
		Action<TNodeData> OnNodeUnSelectedEvent { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		TNodeData Data { get; }
		
		/// <summary>
		/// Determines if a port can connect to its owner node.
		/// </summary>
		bool AllowSelfLinking { get; }
		
		/// <summary>
		/// Binds the specified data.
		/// </summary>
		/// <typeparam name="TNodeData"></typeparam>
		/// <param name="data">The data.</param>
		void Bind(TNodeData data);

		/// <summary>
		/// Links the ports.
		/// </summary>
		/// <param name="nodes">The nodes.</param>
		/// <returns>The list of edges to create.</returns>
		List<EdgeView> LinkPorts(List<NodeViewBase<TNodeData>> nodes);
	}
}