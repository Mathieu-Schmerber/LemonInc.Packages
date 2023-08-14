using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Node
{
	/// <summary>
	/// Internal logic of the <see cref="EdgeControl"/> class, taken from unity's sources.
	/// Only the parts calculating the render points.
	/// <see href="https://github.com/Unity-Technologies/UnityCsReference/blob/master/Modules/GraphViewEditor/EdgeControl.cs"/>
	/// </summary>
	public class InternalEdgeControl
	{
		public struct EdgeCornerSweepValues
		{
			public Vector2 CircleCenter;
			public double SweepAngle;
			public double StartAngle;
			public double EndAngle;
			public Vector2 CrossPoint1;
			public Vector2 CrossPoint2;
			public float Radius;
		}

        private readonly GraphNodeEdgeControl _edgeControl;
        private static readonly Gradient Gradient = new Gradient();

        public InternalEdgeControl(GraphNodeEdgeControl edgeControl)
		{
			_edgeControl = edgeControl;
		}

		public const float K_MIN_EDGE_WIDTH = 1.75f;
		public const float K_EDGE_LENGTH_FROM_PORT = 12.0f;
		public const float K_EDGE_TURN_DIAMETER = 16.0f;
		public const float K_EDGE_SWEEP_RESAMPLE_RATIO = 4.0f;
		public const int K_EDGE_STRAIGHT_LINE_SEGMENT_DIVISOR = 5;

		public List<Vector2> RenderPoints { get; } = new List<Vector2>();
		public List<Vector2> LastLocalControlPoints { get; } = new List<Vector2>();

		public static bool Approximately(Vector2 v1, Vector2 v2)
		{
			return Mathf.Approximately(v1.x, v2.x) && Mathf.Approximately(v1.y, v2.y);
		}

		public void RenderStraightLines(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
		{
			float safeSpan = Mathf.Abs((p1.x + K_EDGE_LENGTH_FROM_PORT) - (p4.x - K_EDGE_LENGTH_FROM_PORT));

			float safeSpan3 = safeSpan / K_EDGE_STRAIGHT_LINE_SEGMENT_DIVISOR;
			float nodeToP2Dist = Mathf.Min(safeSpan3, K_EDGE_TURN_DIAMETER);
			nodeToP2Dist = Mathf.Max(0, nodeToP2Dist);

			var offset = new Vector2(K_EDGE_TURN_DIAMETER - nodeToP2Dist, 0);

			RenderPoints.Add(p1);
			RenderPoints.Add(p2 - offset);
			RenderPoints.Add(p3 + offset);
			RenderPoints.Add(p4);
		}

		private Vector2 GetCornerCircleCenter(Vector2 cornerPoint, Vector2 crossPoint1, Vector2 crossPoint2, float segment, float radius)
		{
			float dx = cornerPoint.x * 2 - crossPoint1.x - crossPoint2.x;
			float dy = cornerPoint.y * 2 - crossPoint1.y - crossPoint2.y;

			var cornerToCenterVector = new Vector2(dx, dy);

			float l = cornerToCenterVector.magnitude;

			if (Mathf.Approximately(l, 0))
			{
				return cornerPoint;
			}

			float d = new Vector2(segment, radius).magnitude;
			float factor = d / l;

			return new Vector2(cornerPoint.x - cornerToCenterVector.x * factor, cornerPoint.y - cornerToCenterVector.y * factor);
		}

        public EdgeCornerSweepValues GetCornerSweepValues(
            Vector2 p1, Vector2 cornerPoint, Vector2 p2, float diameter, Direction closestPortDirection)
        {
            EdgeCornerSweepValues corner = new EdgeCornerSweepValues();

            // Calculate initial radius. This radius can change depending on the sharpness of the corner.
            corner.Radius = diameter / 2;

            // Calculate vectors from p1 to cornerPoint.
            Vector2 d1Corner = (cornerPoint - p1).normalized;
            Vector2 d1 = d1Corner * diameter;
            float dx1 = d1.x;
            float dy1 = d1.y;

            // Calculate vectors from p2 to cornerPoint.
            Vector2 d2Corner = (cornerPoint - p2).normalized;
            Vector2 d2 = d2Corner * diameter;
            float dx2 = d2.x;
            float dy2 = d2.y;

            // Calculate the angle of the corner (divided by 2).
            float angle = (float)(Math.Atan2(dy1, dx1) - Math.Atan2(dy2, dx2)) / 2;

            // Calculate the length of the segment between the cornerPoint and where
            // the corner circle with given radius meets the line.
            float tan = (float)Math.Abs(Math.Tan(angle));
            float segment = corner.Radius / tan;

            // If the segment is larger than the diameter, we need to cap the segment
            // to the diameter and reduce the radius to match the segment. This is what
            // makes the corner turn radii get smaller as the edge corners get tighter.
            if (segment > diameter)
            {
                segment = diameter;
                corner.Radius = diameter * tan;
            }

            // Calculate both cross points (where the circle touches the p1-cornerPoint line
            // and the p2-cornerPoint line).
            corner.CrossPoint1 = cornerPoint - (d1Corner * segment);
            corner.CrossPoint2 = cornerPoint - (d2Corner * segment);

            // Calculation of the coordinates of the circle center.
            corner.CircleCenter = GetCornerCircleCenter(cornerPoint, corner.CrossPoint1, corner.CrossPoint2, segment, corner.Radius);

            // Calculate the starting and ending angles.
            corner.StartAngle = Math.Atan2(corner.CrossPoint1.y - corner.CircleCenter.y, corner.CrossPoint1.x - corner.CircleCenter.x);
            corner.EndAngle = Math.Atan2(corner.CrossPoint2.y - corner.CircleCenter.y, corner.CrossPoint2.x - corner.CircleCenter.x);

            // Get the full sweep angle from the starting and ending angles.
            corner.SweepAngle = corner.EndAngle - corner.StartAngle;

            // If we are computing the second corner (into the input port), we want to start
            // the sweep going backwards.
            if (closestPortDirection == Direction.Input)
            {
                double endAngle = corner.EndAngle;
                corner.EndAngle = corner.StartAngle;
                corner.StartAngle = endAngle;
            }

            // Validate the sweep angle so it turns into the correct direction.
            if (corner.SweepAngle > Math.PI)
                corner.SweepAngle = -2 * Math.PI + corner.SweepAngle;
            else if (corner.SweepAngle < -Math.PI)
                corner.SweepAngle = 2 * Math.PI + corner.SweepAngle;

            return corner;
        }

        public bool ValidateCornerSweepValues(ref EdgeCornerSweepValues corner1, ref EdgeCornerSweepValues corner2)
        {
            // Get the midpoint between the two corner circle centers.
            Vector2 circlesMidpoint = (corner1.CircleCenter + corner2.CircleCenter) / 2;

            // Find the angle to the corner circles midpoint so we can compare it to the sweep angles of each corner.
            Vector2 p2CenterToCross1 = corner1.CircleCenter - corner1.CrossPoint1;
            Vector2 p2CenterToCirclesMid = corner1.CircleCenter - circlesMidpoint;
            double angleToCirclesMid = Math.Atan2(p2CenterToCross1.y, p2CenterToCross1.x) - Math.Atan2(p2CenterToCirclesMid.y, p2CenterToCirclesMid.x);

            if (double.IsNaN(angleToCirclesMid))
                return false;

            // We need the angle to the circles midpoint to match the turn direction of the first corner's sweep angle.
            angleToCirclesMid = Math.Sign(angleToCirclesMid) * 2 * Mathf.PI - angleToCirclesMid;
            if (Mathf.Abs((float)angleToCirclesMid) > 1.5 * Mathf.PI)
                angleToCirclesMid = -1 * Math.Sign(angleToCirclesMid) * 2 * Mathf.PI + angleToCirclesMid;

            // Calculate the maximum sweep angle so that both corner sweeps and with the tangents of the 2 circles meeting each other.
            float h = p2CenterToCirclesMid.magnitude;
            float p2AngleToMidTangent = Mathf.Acos(corner1.Radius / h);

            if (double.IsNaN(p2AngleToMidTangent))
                return false;

            float maxSweepAngle = Mathf.Abs((float)corner1.SweepAngle) - p2AngleToMidTangent * 2;

            // If the angle to the circles midpoint is within the sweep angle, we need to apply our maximum sweep angle
            // calculated above, otherwise the maximum sweep angle is irrelevant.
            if (Mathf.Abs((float)angleToCirclesMid) < Mathf.Abs((float)corner1.SweepAngle))
            {
                corner1.SweepAngle = Math.Sign(corner1.SweepAngle) * Mathf.Min(maxSweepAngle, Mathf.Abs((float)corner1.SweepAngle));
                corner2.SweepAngle = Math.Sign(corner2.SweepAngle) * Mathf.Min(maxSweepAngle, Mathf.Abs((float)corner2.SweepAngle));
            }

            return true;
        }

        public void GetRoundedCornerPoints(List<Vector2> points, EdgeCornerSweepValues corner, Direction closestPortDirection)
        {
            // Calculate the number of points that will sample the arc from the sweep angle.
            int pointsCount = Mathf.CeilToInt((float)Math.Abs(corner.SweepAngle * K_EDGE_SWEEP_RESAMPLE_RATIO));
            int sign = Math.Sign(corner.SweepAngle);
            bool backwards = (closestPortDirection == Direction.Input);

            for (int i = 0; i < pointsCount; ++i)
            {
                // If we are computing the second corner (into the input port), the sweep is going backwards
                // but we still need to add the points to the list in the correct order.
                float sweepIndex = backwards ? i - pointsCount : i;

                double sweepedAngle = corner.StartAngle + sign * sweepIndex / K_EDGE_SWEEP_RESAMPLE_RATIO;

                var pointX = (float)(corner.CircleCenter.x + Math.Cos(sweepedAngle) * corner.Radius);
                var pointY = (float)(corner.CircleCenter.y + Math.Sin(sweepedAngle) * corner.Radius);

                // Check if we overlap the previous point. If we do, we skip this point so that we
                // don't cause the edge polygons to twist.
                if (i == 0 && backwards)
                {
	                if (corner.SweepAngle < 0 && points[points.Count - 1].y > pointY)
		                continue;
	                else if (corner.SweepAngle >= 0 && points[points.Count - 1].y < pointY)
		                continue;
                }

                points.Add(new Vector2(pointX, pointY));
            }
        }

        public void UpdateRenderPoints(Vector2[] controlPoints, Orientation outputOrientation, Orientation inputOrientation, VisualElement parent)
        {
			if (controlPoints == null)
			{
				return;
			}

			var p1 = parent.ChangeCoordinatesTo(_edgeControl, controlPoints[0]);
			var p2 = parent.ChangeCoordinatesTo(_edgeControl, controlPoints[1]);
			var p3 = parent.ChangeCoordinatesTo(_edgeControl, controlPoints[2]);
			var p4 = parent.ChangeCoordinatesTo(_edgeControl, controlPoints[3]);

			// Only compute this when the "local" points have actually changed
			if (LastLocalControlPoints.Count == 4)
			{
				if (Approximately(p1, LastLocalControlPoints[0]) &&
					Approximately(p2, LastLocalControlPoints[1]) &&
					Approximately(p3, LastLocalControlPoints[2]) &&
					Approximately(p4, LastLocalControlPoints[3]))
				{
					return;
				}
			}

			LastLocalControlPoints.Clear();
			LastLocalControlPoints.Add(p1);
			LastLocalControlPoints.Add(p2);
			LastLocalControlPoints.Add(p3);
			LastLocalControlPoints.Add(p4);

			RenderPoints.Clear();

			var diameter = K_EDGE_TURN_DIAMETER;

			// We have to handle a special case of the edge when it is a straight line, but not
			// when going backwards in space (where the start point is in front in y to the end point).
			// We do this by turning the line into 3 linear segments with no curves. This also
			// avoids possible NANs in later angle calculations.
			var sameOrientations = outputOrientation == inputOrientation;
			if (sameOrientations &&
				((outputOrientation == Orientation.Horizontal && Mathf.Abs(p1.y - p4.y) < 2 && p1.x + K_EDGE_LENGTH_FROM_PORT < p4.x - K_EDGE_LENGTH_FROM_PORT) ||
				 (outputOrientation == Orientation.Vertical && Mathf.Abs(p1.x - p4.x) < 2 && p1.y + K_EDGE_LENGTH_FROM_PORT < p4.y - K_EDGE_LENGTH_FROM_PORT)))
			{
				RenderStraightLines(p1, p2, p3, p4);
				return;
			}

			var renderBothCorners = true;

			var corner1 = GetCornerSweepValues(p1, p2, p3, diameter, Direction.Output);
			var corner2 = GetCornerSweepValues(p2, p3, p4, diameter, Direction.Input);

			if (!ValidateCornerSweepValues(ref corner1, ref corner2))
			{
				if (sameOrientations)
				{
					RenderStraightLines(p1, p2, p3, p4);
					return;
				}

				renderBothCorners = false;

				//we try to do it with a single corner instead
				var px = (outputOrientation == Orientation.Horizontal) ? new Vector2(p4.x, p1.y) : new Vector2(p1.x, p4.y);

				corner1 = GetCornerSweepValues(p1, px, p4, diameter, Direction.Output);
			}

			RenderPoints.Add(p1);

			if (!sameOrientations && renderBothCorners)
			{
				//if the 2 corners or endpoints are too close, the corner sweep angle calculations can't handle different orientations
				var minDistance = 2 * diameter * diameter;
				if ((p3 - p2).sqrMagnitude < minDistance ||
					(p4 - p1).sqrMagnitude < minDistance)
				{
					var px = (p2 + p3) * 0.5f;
					corner1 = GetCornerSweepValues(p1, px, p4, diameter, Direction.Output);
					renderBothCorners = false;
				}
			}

			GetRoundedCornerPoints(RenderPoints, corner1, Direction.Output);
			if (renderBothCorners)
				GetRoundedCornerPoints(RenderPoints, corner2, Direction.Input);

			RenderPoints.Add(p4);
		}

        public Painter2D SetupPainter(MeshGenerationContext mgc, UnityEditor.Experimental.GraphView.GraphView graphView)
        {
	        var inColor = _edgeControl.inputColor;
	        var outColor = _edgeControl.outputColor;
	        var painter2D = mgc.painter2D;

	        float width = _edgeControl.edgeWidth;
	        var alpha = _edgeControl.Edge.isGhostEdge ? 0.5f : 1.0f;
	        var zoom = graphView?.scale ?? 1.0f;

	        if (_edgeControl.edgeWidth * zoom < K_MIN_EDGE_WIDTH)
	        {
		        alpha = _edgeControl.edgeWidth * zoom / K_MIN_EDGE_WIDTH;
		        width = K_MIN_EDGE_WIDTH / zoom;
	        }

	        Gradient.SetKeys(new[] { new GradientColorKey(outColor, 0), new GradientColorKey(inColor, 1) },
		        new[] { new GradientAlphaKey(alpha, 0) });
	        painter2D.BeginPath();
	        painter2D.strokeGradient = Gradient;
	        painter2D.lineWidth = width;
	        return painter2D;
        }
	}
}
