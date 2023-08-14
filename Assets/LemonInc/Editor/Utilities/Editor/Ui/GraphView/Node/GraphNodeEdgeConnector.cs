using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Node
{
	/// <summary>
	/// Basically same code as Unity's source, but managed with public accesses and different mouse controls.
	/// <see href="https://github.com/Unity-Technologies/UnityCsReference/blob/master/Modules/GraphViewEditor/Manipulators/EdgeConnector.cs"/>
	/// </summary>
	public class GraphNodeEdgeConnector<TEdge> : EdgeConnector where TEdge : Edge, new()
	{
		private readonly GraphNodeEdgeDragHelper<TEdge> _edgeDragHelper;
		private Edge _edgeCandidate;
		private bool _active;
		private Vector2 _mouseDownPosition;

		internal const float CONNECTION_DISTANCE_THRESHOLD = 10f;

		public GraphNodeEdgeConnector(IEdgeConnectorListener listener)
		{
			_edgeDragHelper = new GraphNodeEdgeDragHelper<TEdge>(listener);
			_active = false;
			activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
		}

		public override EdgeDragHelper edgeDragHelper => _edgeDragHelper;

		protected override void RegisterCallbacksOnTarget()
		{
			target.RegisterCallback<MouseDownEvent>(OnMouseDown);
			target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
			target.RegisterCallback<MouseUpEvent>(OnMouseUp);
			target.RegisterCallback<KeyDownEvent>(OnKeyDown);
			target.RegisterCallback<MouseCaptureOutEvent>(OnCaptureOut);
		}

		protected override void UnregisterCallbacksFromTarget()
		{
			target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
			target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
			target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
			target.UnregisterCallback<KeyDownEvent>(OnKeyDown);
		}

		/// <summary>
		/// Called when [mouse down].
		/// Confirms whether to link ports.
		/// </summary>
		/// <param name="evt">The evt.</param>
		private void OnMouseDown(MouseDownEvent evt)
		{
			if (!_active || !CanStopManipulation(evt))
				return;

			if (CanPerformConnection(_edgeCandidate.candidatePosition))
				_edgeDragHelper.HandleMouseUp(_edgeCandidate.candidatePosition);
			else
				Abort();

			_active = false;
			_edgeCandidate = null;
			target.ReleaseMouse();
			evt.StopPropagation();
		}

		/// <summary>
		/// Starts the drag.
		/// </summary>
		public void StartDrag(Vector2 localMousePosition)
		{
			if (_active)
				return;
			
			if (target is not Port graphElement)
			{
				return;
			}

			_mouseDownPosition = localMousePosition;

			_edgeCandidate = new TEdge();
			_edgeDragHelper.draggedPort = graphElement;
			_edgeDragHelper.edgeCandidate = _edgeCandidate;

			if (_edgeDragHelper.HandleMouseDown(_mouseDownPosition))
			{
				_active = true;
				target.CaptureMouse();
			}
			else
			{
				_edgeDragHelper.Reset();
				_edgeCandidate = null;
			}
		}

		private void OnCaptureOut(MouseCaptureOutEvent e)
		{
			_active = false;
			if (_edgeCandidate != null)
				Abort();
		}

		protected virtual void OnMouseMove(MouseMoveEvent e)
		{
			if (!_active) return;

			_edgeDragHelper.HandleMouseMove(e);
			_edgeCandidate.candidatePosition = e.mousePosition;
			_edgeCandidate.UpdateEdgeControl();
			e.StopPropagation();
		}

		protected virtual void OnMouseUp(MouseUpEvent e)
		{
			
		}

		private void OnKeyDown(KeyDownEvent e)
		{
			if (e.keyCode != KeyCode.Escape || !_active)
				return;

			Abort();

			_active = false;
			target.ReleaseMouse();
			e.StopPropagation();
		}

		private void Abort()
		{
			var graphView = target?.GetFirstAncestorOfType<UnityEditor.Experimental.GraphView.GraphView>();
			graphView?.RemoveElement(_edgeCandidate);

			_edgeCandidate.input = null;
			_edgeCandidate.output = null;
			_edgeCandidate = null;

			_edgeDragHelper.Reset();
		}

		private bool CanPerformConnection(Vector2 mousePosition)
		{
			return Vector2.Distance(_mouseDownPosition, mousePosition) > CONNECTION_DISTANCE_THRESHOLD;
		}
	}
}