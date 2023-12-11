using LemonInc.Core.Utilities.Graph;
using System;
using System.Collections.Generic;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Interfaces
{
	/// <summary>
	/// Handles a node collection.
	/// </summary>
	public interface INodeController<TNodeData>
		where TNodeData : INode
	{
		/// <summary>
		/// Gets all nodes.
		/// </summary>
		/// <returns></returns>
		IEnumerable<TNodeData> GetAllNodes();

		/// <summary>
		/// Creates a new node of the specified type and add it.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		TNodeData CreateNodeOfType(Type type);

		/// <summary>
		/// Adds a node.
		/// </summary>
		/// <param name="node">The node.</param>
		void Add(TNodeData node);

		/// <summary>
		/// Deletes a node.
		/// </summary>
		/// <param name="node">The node.</param>
		void Delete(TNodeData node);

		/// <summary>
		/// Duplicates the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		TNodeData Duplicate(TNodeData node);

		/// <summary>
		/// Links the nodes.
		/// </summary>
		/// <param name="inputNode">The input node.</param>
		/// <param name="outputNode">The output node.</param>
		void Link(TNodeData inputNode, TNodeData outputNode);

		/// <summary>
		/// Unlinks the nodes.
		/// </summary>
		/// <param name="inputNode">The input node.</param>
		/// <param name="outputNode">The output node.</param>
		void Unlink(TNodeData inputNode, TNodeData outputNode);

		/// <summary>
		/// Gets the related nodes of a node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		IEnumerable<TNodeData> GetRelated(TNodeData node);
	}
}