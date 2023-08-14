using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Node
{
    /// <summary>
    /// Basically same code as Unity's source.
    /// Here we just change how we detect that ports can be connected.
    /// <see href="https://github.com/Unity-Technologies/UnityCsReference/blob/master/Modules/GraphViewEditor/Manipulators/EdgeDragHelper.cs"/>
    /// </summary>
    /// <seealso cref="GraphNodeEdge" />
    public class GraphNodeEdgeDragHelper<TEdge> : EdgeDragHelper where TEdge : Edge, new()
    {
	    internal const int K_PAN_AREA_WIDTH = 100;
	    internal const int K_PAN_SPEED = 4;
	    internal const int K_PAN_INTERVAL = 10;
	    internal const float K_MIN_SPEED_FACTOR = 0.5f;
	    internal const float K_MAX_SPEED_FACTOR = 2.5f;
	    internal const float K_MAX_PAN_SPEED = K_MAX_SPEED_FACTOR * K_PAN_SPEED;

        protected List<Port> CompatiblePorts;
        private Edge _ghostEdge;
        protected UnityEditor.Experimental.GraphView.GraphView GraphView;
        protected static NodeAdapter NodeAdapter = new();
        protected readonly IEdgeConnectorListener MListener;

        private IVisualElementScheduledItem _mPanSchedule;
        private Vector3 _mPanDiff = Vector3.zero;
        private bool _mWasPanned;

        public bool ResetPositionOnPan { get; set; }

        public GraphNodeEdgeDragHelper(IEdgeConnectorListener listener)
        {
            MListener = listener;
            ResetPositionOnPan = true;
            Reset();
        }

        public override Edge edgeCandidate { get; set; }

        public override Port draggedPort { get; set; }

        public override void HandleMouseUp(MouseUpEvent evt) { }

        public override void Reset(bool didConnect = false)
        {
            if (CompatiblePorts != null)
            {
                // Reset the highlights.
                GraphView.ports.ForEach((p) => {
                    p.OnStopEdgeDragging();
                });
                CompatiblePorts = null;
            }

            // Clean up ghost edge.
            if ((_ghostEdge != null) && (GraphView != null))
            {
                GraphView.RemoveElement(_ghostEdge);
            }

            if (_mWasPanned)
            {
                if (!ResetPositionOnPan || didConnect)
                {
                    var p = GraphView.contentViewContainer.transform.position;
                    var s = GraphView.contentViewContainer.transform.scale;
                    GraphView.UpdateViewTransform(p, s);
                }
            }

            _mPanSchedule?.Pause();

            if (_ghostEdge != null)
            {
                _ghostEdge.input = null;
                _ghostEdge.output = null;
            }

            if (draggedPort != null && !didConnect)
            {
                draggedPort.portCapLit = false;
                draggedPort = null;
            }

            if (edgeCandidate != null)
            {
                edgeCandidate.SetEnabled(true);
            }

            _ghostEdge = null;
            edgeCandidate = null;

            GraphView = null;
        }

        public bool HandleMouseDown(Vector2 mousePosition)
        {
            if ((draggedPort == null) || (edgeCandidate == null))
            {
                return false;
            }

            GraphView = draggedPort.GetFirstAncestorOfType<UnityEditor.Experimental.GraphView.GraphView>();

            if (GraphView == null)
            {
                return false;
            }

            if (edgeCandidate.parent == null)
            {
                GraphView.AddElement(edgeCandidate);
            }

            var startFromOutput = (draggedPort.direction == Direction.Output);

            edgeCandidate.candidatePosition = mousePosition;
            edgeCandidate.SetEnabled(false);

            if (startFromOutput)
            {
                edgeCandidate.output = draggedPort;
                edgeCandidate.input = null;
            }
            else
            {
                edgeCandidate.output = null;
                edgeCandidate.input = draggedPort;
            }

            draggedPort.portCapLit = true;


            CompatiblePorts = GraphView.GetCompatiblePorts(draggedPort, NodeAdapter);

            // Only light compatible anchors when dragging an edge.
            GraphView.ports.ForEach((p) => {
                p.OnStartEdgeDragging();
            });

            foreach (var compatiblePort in CompatiblePorts)
            {
                compatiblePort.highlight = true;
            }

            edgeCandidate.UpdateEdgeControl();

            if (_mPanSchedule == null)
            {
                _mPanSchedule = GraphView.schedule.Execute(Pan).Every(K_PAN_INTERVAL).StartingIn(K_PAN_INTERVAL);
                _mPanSchedule.Pause();
            }
            _mWasPanned = false;

            edgeCandidate.layer = int.MaxValue;

            return true;
        }

        internal Vector2 GetEffectivePanSpeed(Vector2 mousePos)
        {
            var effectiveSpeed = Vector2.zero;

            if (mousePos.x <= K_PAN_AREA_WIDTH)
                effectiveSpeed.x = -(((K_PAN_AREA_WIDTH - mousePos.x) / K_PAN_AREA_WIDTH) + 0.5f) * K_PAN_SPEED;
            else if (mousePos.x >= GraphView.contentContainer.layout.width - K_PAN_AREA_WIDTH)
                effectiveSpeed.x = (((mousePos.x - (GraphView.contentContainer.layout.width - K_PAN_AREA_WIDTH)) / K_PAN_AREA_WIDTH) + 0.5f) * K_PAN_SPEED;

            if (mousePos.y <= K_PAN_AREA_WIDTH)
                effectiveSpeed.y = -(((K_PAN_AREA_WIDTH - mousePos.y) / K_PAN_AREA_WIDTH) + 0.5f) * K_PAN_SPEED;
            else if (mousePos.y >= GraphView.contentContainer.layout.height - K_PAN_AREA_WIDTH)
                effectiveSpeed.y = (((mousePos.y - (GraphView.contentContainer.layout.height - K_PAN_AREA_WIDTH)) / K_PAN_AREA_WIDTH) + 0.5f) * K_PAN_SPEED;

            effectiveSpeed = Vector2.ClampMagnitude(effectiveSpeed, K_MAX_PAN_SPEED);

            return effectiveSpeed;
        }

        public override bool HandleMouseDown(MouseDownEvent evt) => true;

        public override void HandleMouseMove(MouseMoveEvent evt)
        {
	        if (GraphView == null)
		        return;

	        var ve = (VisualElement)evt.target;
            var gvMousePos = ve.ChangeCoordinatesTo(GraphView.contentContainer, evt.localMousePosition);
            _mPanDiff = GetEffectivePanSpeed(gvMousePos);

            if (_mPanDiff != Vector3.zero)
            {
                _mPanSchedule.Resume();
            }
            else
            {
                _mPanSchedule.Pause();
            }

            var mousePosition = evt.mousePosition;

            edgeCandidate.candidatePosition = mousePosition;

            // Draw ghost edge if possible port exists.
            var endPort = GetEndPort(mousePosition);

            if (endPort != null)
            {
                if (_ghostEdge == null)
                {
	                _ghostEdge = new TEdge();
	                _ghostEdge.isGhostEdge = true;
	                _ghostEdge.pickingMode = PickingMode.Ignore;
	                GraphView.AddElement(_ghostEdge);
                }

                if (edgeCandidate.output == null)
                {
                    _ghostEdge.input = edgeCandidate.input;
                    if (_ghostEdge.output != null)
                        _ghostEdge.output.portCapLit = false;
                    _ghostEdge.output = endPort;
                    _ghostEdge.output.portCapLit = true;
                }
                else
                {
                    if (_ghostEdge.input != null)
                        _ghostEdge.input.portCapLit = false;
                    _ghostEdge.input = endPort;
                    _ghostEdge.input.portCapLit = true;
                    _ghostEdge.output = edgeCandidate.output;
                }
            }
            else if (_ghostEdge != null)
            {
                if (edgeCandidate.input == null)
                {
                    if (_ghostEdge.input != null)
                        _ghostEdge.input.portCapLit = false;
                }
                else
                {
                    if (_ghostEdge.output != null)
                        _ghostEdge.output.portCapLit = false;
                }
                GraphView.RemoveElement(_ghostEdge);
                _ghostEdge.input = null;
                _ghostEdge.output = null;
                _ghostEdge = null;
            }
        }

        private void Pan(TimerState ts)
        {
            GraphView.viewTransform.position -= _mPanDiff;
            // TODO: implement it, this is internal refer to open source code
            //edgeCandidate.ForceUpdateEdgeControl();
            _mWasPanned = true;
        }

        public void HandleMouseUp(Vector2 mousePosition)
        {
            var didConnect = false;

            // Reset the highlights.
            GraphView.ports.ForEach((p) => {
                p.OnStopEdgeDragging();
            });

            // Clean up ghost edges.
            if (_ghostEdge != null)
            {
                if (_ghostEdge.input != null)
                    _ghostEdge.input.portCapLit = false;
                if (_ghostEdge.output != null)
                    _ghostEdge.output.portCapLit = false;

                GraphView.RemoveElement(_ghostEdge);
                _ghostEdge.input = null;
                _ghostEdge.output = null;
                _ghostEdge = null;
            }

            var endPort = GetEndPort(mousePosition);

            if (endPort == null && MListener != null)
            {
                MListener.OnDropOutsidePort(edgeCandidate, mousePosition);
            }

            edgeCandidate.SetEnabled(true);

            if (edgeCandidate.input != null)
                edgeCandidate.input.portCapLit = false;

            if (edgeCandidate.output != null)
                edgeCandidate.output.portCapLit = false;

            // If it is an existing valid edge then delete and notify the model (using DeleteElements()).
            if (edgeCandidate.input != null && edgeCandidate.output != null)
            {
                // Save the current input and output before deleting the edge as they will be reset
                var oldInput = edgeCandidate.input;
                var oldOutput = edgeCandidate.output;

                GraphView.DeleteElements(new[] { edgeCandidate });

                // Restore the previous input and output
                edgeCandidate.input = oldInput;
                edgeCandidate.output = oldOutput;
            }
            // otherwise, if it is an temporary edge then just remove it as it is not already known my the model
            else
            {
                GraphView.RemoveElement(edgeCandidate);
            }

            if (endPort != null)
            {
                if (endPort.direction == Direction.Output)
                    edgeCandidate.output = endPort;
                else
                    edgeCandidate.input = endPort;

                MListener.OnDrop(GraphView, edgeCandidate);
                didConnect = true;
            }
            else
            {
                edgeCandidate.output = null;
                edgeCandidate.input = null;
            }

            edgeCandidate.ResetLayer();

            edgeCandidate = null;
            CompatiblePorts = null;
            Reset(didConnect);
        }

        private Port GetEndPort(Vector2 mousePosition)
        {
            if (GraphView == null)
                return null;

            Port endPort = null;

            foreach (var compatiblePort in CompatiblePorts)
            {
	            var bounds = compatiblePort.node.worldBound;
                
                // Check if mouse is over node.
                if (!bounds.Contains(mousePosition))
	                continue;

                endPort = compatiblePort;
                break;
            }

            return endPort;
        }
    }
}