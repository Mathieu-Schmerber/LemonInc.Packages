using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.Graph.GraphNode
{
	/// <summary>
	/// Graph node edge control.
	/// </summary>
	/// <seealso cref="UnityEditor.Experimental.GraphView.EdgeControl" />
	public class GraphNodeEdgeControl : EdgeControl
	{
		private readonly Edge _edge;

		public Edge Edge => _edge;

		private Port Input => _edge.input;
		private Port Output => _edge.output;

		/// <summary>
		/// The internal edge control logic.
		/// </summary>
		private readonly InternalEdgeControl _internal;
		
		/// <summary>
		/// The graph view.
		/// </summary>
		private GraphView _graphView;

		/// <summary>
		/// Offset to apply in order to distinguish connection between same ports.
		/// </summary>
		public float DirectionalOffset => 5f;

		/// <summary>
		/// Initializes a new instance of the <see cref="GraphNodeEdgeControl"/> class.
		/// </summary>
		/// <param name="edge">The edge.</param>
		public GraphNodeEdgeControl(Edge edge)
		{
			_internal = new InternalEdgeControl(this);
			_edge = edge;
			_graphView = GetFirstAncestorOfType<GraphView>();
			generateVisualContent = Draw;
		}

		/// <summary>
		/// Draws the specified MGC.
		/// </summary>
		/// <param name="mgc">The MGC.</param>
		private void Draw(MeshGenerationContext mgc)
		{
			UpdateRenderPoints();
			if (_internal.RenderPoints.Count == 0)
				return;

			var painter2D = _internal.SetupPainter(mgc, _graphView);

			// Straight line from end to finish, don't care about the points midway
			painter2D.MoveTo(_internal.RenderPoints[0]);
			painter2D.LineTo(_internal.RenderPoints[^1]);
			painter2D.Stroke();
		}

		/// <summary>
		/// Update the edge's render points.
		/// </summary>
		protected override void UpdateRenderPoints()
		{
			base.UpdateRenderPoints();
			_internal.UpdateRenderPoints(controlPoints, outputOrientation, inputOrientation, parent);
		}

		/// <summary>
		/// Compute the edge's control points.
		/// </summary>
		protected override void ComputeControlPoints()
		{
			base.ComputeControlPoints();
			if (Output == null || Input == null)
			{
				controlPoints[0] = Output?.node.GetPosition().center ?? from;
				controlPoints[1] = controlPoints[0];
				controlPoints[2] = Input?.node.GetPosition().center ?? to;
				controlPoints[3] = controlPoints[2];
				return;
			}

			var outPos = Output.node.GetPosition().center;
			var inPos = Input.node.GetPosition().center;

			controlPoints[0] = outPos;
			controlPoints[1] = controlPoints[0];
			controlPoints[2] = inPos;
			controlPoints[3] = controlPoints[2];

			var perpendicular = Vector2.Perpendicular(controlPoints[^1] - controlPoints[0]).normalized;
			var offset = perpendicular * DirectionalOffset;
			for (var i = 0; i < controlPoints.Length; i++)
				controlPoints[i] += offset;

			if (GetIntersectionsWithRect(controlPoints[0], controlPoints[^1], Input.node.GetPosition(), out var intersections))
				controlPoints[1] = intersections.First();
			if (GetIntersectionsWithRect(controlPoints[^1], controlPoints[0], Output.node.GetPosition(), out intersections))
				controlPoints[2] = intersections.First();
		}

		/// <summary>
		/// Gets the intersections with rect.
		/// </summary>
		/// <param name="pointA">The point a.</param>
		/// <param name="pointB">The point b.</param>
		/// <param name="rectangle">The rectangle.</param>
		/// <param name="intersections">The intersections.</param>
		/// <returns></returns>
		public static bool GetIntersectionsWithRect(Vector2 pointA, Vector2 pointB, Rect rectangle, out IEnumerable<Vector2> intersections)
		{
			var topLeft = new Vector2(rectangle.xMin, rectangle.yMax);
			var topRight = new Vector2(rectangle.xMax, rectangle.yMax);
			var bottomLeft = new Vector2(rectangle.xMin, rectangle.yMin);
			var bottomRight = new Vector2(rectangle.xMax, rectangle.yMin);

			var intersectionPoints = new List<Vector2>();

			if (LineIntersect(pointA, pointB, topLeft, topRight, out var intersection))
				intersectionPoints.Add(intersection);
			if (LineIntersect(pointA, pointB, topRight, bottomRight, out intersection))
				intersectionPoints.Add(intersection);
			if (LineIntersect(pointA, pointB, bottomRight, bottomLeft, out intersection))
				intersectionPoints.Add(intersection);
			if (LineIntersect(pointA, pointB, bottomLeft, topLeft, out intersection))
				intersectionPoints.Add(intersection);

			intersections = intersectionPoints;
			return intersectionPoints.Count > 0;
		}

		/// <summary>
		/// Lines the intersect.
		/// </summary>
		/// <param name="start1">The start1.</param>
		/// <param name="end1">The end1.</param>
		/// <param name="start2">The start2.</param>
		/// <param name="end2">The end2.</param>
		/// <param name="intersection">The intersection.</param>
		/// <returns></returns>
		private static bool LineIntersect(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2, out Vector2 intersection)
		{
			var dir1 = end1 - start1;
			var dir2 = end2 - start2;

			var denominator = dir1.x * dir2.y - dir1.y * dir2.x;

			if (Mathf.Approximately(denominator, 0))
			{
				intersection = Vector2.zero;
				return false;
			}

			var numerator1 = (start1.y - start2.y) * dir2.x - (start1.x - start2.x) * dir2.y;
			var numerator2 = (start1.y - start2.y) * dir1.x - (start1.x - start2.x) * dir1.y;

			var t1 = numerator1 / denominator;
			var t2 = numerator2 / denominator;

			if (t1 is >= 0 and <= 1 && t2 is >= 0 and <= 1)
			{
				intersection = start1 + t1 * dir1;
				return true;
			}

			intersection = Vector2.zero;
			return false;
		}
	}
}