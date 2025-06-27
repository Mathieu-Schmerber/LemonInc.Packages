using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LemonInc.Core.Utilities.Components
{
    public class Rotate : MonoBehaviour
    {
        [Title("Rotation Settings")]
        [SerializeField] private Vector3 _axis = Vector3.up;
        [SerializeField] private float _speed = 90f;
        [SerializeField] private bool _infinite = true;
        [SerializeField, HideIf(nameof(_infinite))] private float _duration = 0f;
        [SerializeField] private AnimationCurve _curve = AnimationCurve.Linear(0, 1, 1, 1);
        [SerializeField] private bool _useLocalAxis = true;
        
        [Title("Gizmos")]
        [SerializeField] private bool _showGizmos = true;
        [SerializeField, ShowIf(nameof(_showGizmos))] private bool _showOnlyWhenSelected = false;
        [SerializeField] private float _axisLength = 1f;
        [SerializeField] private float _rotationRadius = 1f;

        private float _elapsedTime;
        private float _estimatedTotalRotation = 0f;

        private void Awake()
        {
            RecalculateEstimatedRotation();
        }

        private void OnValidate()
        {
            RecalculateEstimatedRotation();
        }

        private void Update()
        {
            if (!_infinite && _elapsedTime >= _duration)
                return;

            _elapsedTime += Time.deltaTime;

            float t;
            if (!_infinite)
                t = Mathf.Clamp01(_elapsedTime / _duration);
            else
            {
                var loopDuration = _curve.length > 0 ? _curve[_curve.length - 1].time : 1f;
                t = Mathf.Repeat(_elapsedTime, loopDuration);
            }

            var curveValue = _curve.Evaluate(t);
            var rotationAxis = _useLocalAxis ? transform.TransformDirection(_axis.normalized) : _axis.normalized;
            transform.Rotate(rotationAxis, _speed * curveValue * Time.deltaTime, Space.World);
        }


        private void RecalculateEstimatedRotation()
        {
            _estimatedTotalRotation = 0f;

            if (_duration <= 0f || _speed == 0f)
                return;

            const int sampleCount = 100;
            var dt = _duration / sampleCount;
            for (var i = 0; i < sampleCount; i++)
            {
                var t = i / (float)sampleCount;
                var evaluated = _curve.Evaluate(t);
                _estimatedTotalRotation += _speed * evaluated * dt;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (_showGizmos && _showOnlyWhenSelected)
                RenderGizmos();
        }
        
        private void OnDrawGizmos()
        {
            if (_showGizmos && !_showOnlyWhenSelected)
                RenderGizmos();
        }

        private void RenderGizmos()
        {
            var origin = transform.position;
            var axisDir = _useLocalAxis ? transform.TransformDirection(_axis.normalized) : _axis.normalized;

            // Draw axis line
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(origin - axisDir * _axisLength, origin + axisDir * _axisLength);
            Gizmos.DrawSphere(origin + axisDir * _axisLength, 0.05f);
            Gizmos.DrawSphere(origin - axisDir * _axisLength, 0.05f);

            // Determine perpendicular starting vector
            Handles.color = Color.yellow;
            var perpendicular = Vector3.Cross(axisDir, Vector3.up).normalized;
            if (perpendicular == Vector3.zero)
                perpendicular = Vector3.Cross(axisDir, Vector3.right).normalized;

            var arcDegrees = !_infinite ? _estimatedTotalRotation : 360f;
            arcDegrees = Mathf.Min(arcDegrees, 360f);

            // Draw arc
            Handles.DrawWireArc(origin, axisDir, perpendicular, arcDegrees, _rotationRadius);

            // Arrow tangential to arc
            var arcEndDirection = Quaternion.AngleAxis(arcDegrees, axisDir) * perpendicular;
            var arcEndPosition = origin + arcEndDirection * _rotationRadius;
            var tangentRotation = Quaternion.LookRotation(Vector3.Cross(axisDir, arcEndDirection), arcEndDirection);

            Handles.ArrowHandleCap(0, arcEndPosition, tangentRotation, 0.2f, EventType.Repaint);
        }
#endif

    }
}
