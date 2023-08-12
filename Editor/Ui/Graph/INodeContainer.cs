using System;
using System.Collections.Generic;

namespace LemonInc.Editor.Utilities.Ui.Graph
{
	/// <summary>
	/// Represents a node container.
	/// </summary>
	public interface INodeContainer<TNodeData>
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
		/// Adds the node.
		/// </summary>
		/// <param name="node">The node.</param>
		void AddNode(TNodeData node);

		/// <summary>
		/// Deletes the node.
		/// </summary>
		/// <param name="node">The node.</param>
		void DeleteNode(TNodeData node);

		/// <summary>
		/// Links the nodes.
		/// </summary>
		/// <param name="inputNode">The input node.</param>
		/// <param name="outputNode">The output node.</param>
		void LinkNodes(TNodeData inputNode, TNodeData outputNode);

		/// <summary>
		/// Unlinks the nodes.
		/// </summary>
		/// <param name="inputNode">The input node.</param>
		/// <param name="outputNode">The output node.</param>
		void UnlinkNodes(TNodeData inputNode, TNodeData outputNode);

		/// <summary>
		/// Gets the children of a node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		IEnumerable<TNodeData> GetChildren(TNodeData node);
	}
}
