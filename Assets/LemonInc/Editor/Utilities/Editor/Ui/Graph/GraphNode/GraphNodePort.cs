using System;
using System.Collections.Generic;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.Graph.GraphNode
{
	public class GraphNodePort : Port
	{
		private class DefaultEdgeConnectorListener : IEdgeConnectorListener
		{
			private GraphViewChange m_GraphViewChange;
			private List<Edge> m_EdgesToCreate;
			private List<GraphElement> m_EdgesToDelete;

			public DefaultEdgeConnectorListener()
			{
				m_EdgesToCreate = new List<Edge>();
				m_EdgesToDelete = new List<GraphElement>();

				m_GraphViewChange.edgesToCreate = m_EdgesToCreate;
			}

			public void OnDropOutsidePort(Edge edge, Vector2 position) { }
			public void OnDrop(GraphView graphView, Edge edge)
			{
				m_EdgesToCreate.Clear();
				m_EdgesToCreate.Add(edge);

				// We can't just add these edges to delete to the m_GraphViewChange
				// because we want the proper deletion code in GraphView to also
				// be called. Of course, that code (in DeleteElements) also
				// sends a GraphViewChange.
				m_EdgesToDelete.Clear();
				if (edge.input.capacity == Capacity.Single)
					foreach (Edge edgeToDelete in edge.input.connections)
						if (edgeToDelete != edge)
							m_EdgesToDelete.Add(edgeToDelete);
				if (edge.output.capacity == Capacity.Single)
					foreach (Edge edgeToDelete in edge.output.connections)
						if (edgeToDelete != edge)
							m_EdgesToDelete.Add(edgeToDelete);
				if (m_EdgesToDelete.Count > 0)
					graphView.DeleteElements(m_EdgesToDelete);

				var edgesToCreate = m_EdgesToCreate;
				if (graphView.graphViewChanged != null)
				{
					edgesToCreate = graphView.graphViewChanged(m_GraphViewChange).edgesToCreate;
				}

				foreach (Edge e in edgesToCreate)
				{
					graphView.AddElement(e);
					edge.input.Connect(e);
					edge.output.Connect(e);
				}
			}
		}

		/// <summary>
		/// Gets the edge connector.
		/// </summary>
		/// <value>
		/// The edge connector.
		/// </value>
		public EdgeConnector EdgeConnector => m_EdgeConnector;

		/// <summary>
		/// Initializes a new instance of the <see cref="GraphNodePort"/> class.
		/// </summary>
		/// <param name="portOrientation">The port orientation.</param>
		/// <param name="portDirection">The port direction.</param>
		/// <param name="portCapacity">The port capacity.</param>
		/// <param name="type">The type.</param>
		protected GraphNodePort(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type)
			: base(portOrientation, portDirection, portCapacity, type)
		{
			style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
			name = direction.ToString().ToSnakeCase();
			Remove(this.Q("type"));
		}

		public static GraphNodePort Create(Direction portDirection, Capacity capacity)
		{
			var port = new GraphNodePort(Orientation.Horizontal, portDirection, capacity, typeof(bool));

			port.m_EdgeConnector = new GraphNodeEdgeConnector<GraphNodeEdge>(new DefaultEdgeConnectorListener());
			port.AddManipulator(port.m_EdgeConnector);
			return port;
		}
	}
}