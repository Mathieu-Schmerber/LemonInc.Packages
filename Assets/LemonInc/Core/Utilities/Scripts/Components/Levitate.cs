using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LemonInc.Core.Utilities.Components
{
    public class Levitate : MonoBehaviour
    {
        [Title("Levitation Settings")]
        [SerializeField] private float _amplitude = 1f;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private bool _infinite = true;
        [SerializeField, HideIf(nameof(_infinite))] private float _duration = 2f;
        [SerializeField] private bool _useLocalSpace = true;
        [SerializeField] private bool _relativePositioning = false;
        [SerializeField] private Vector3 _direction = Vector3.up;

        [Title("Gizmos")]
        [SerializeField] private bool _showGizmos = true;
        [SerializeField, ShowIf(nameof(_showGizmos))] private bool _showOnlyWhenSelected = false;
        [SerializeField] private Color _gizmoColor = Color.magenta;
        [SerializeField] private float _gizmoSphereRadius = 0.05f;

        private Vector3 _startPosition;
        private float _elapsedTime;
        private float _previousOffset;

        private void Awake()
        {
            _startPosition = _useLocalSpace ? transform.localPosition : transform.position;
            _previousOffset = 0f;
        }

        private void Update()
        {
            if (!_infinite && _elapsedTime >= _duration)
                return;

            _elapsedTime += Time.deltaTime;

            float t = _infinite ? _elapsedTime * _speed : Mathf.Min(_elapsedTime * _speed, _duration * _speed);

            // Sine wave oscillates between -1 and 1; normalize to 0..1 for smoother behavior or use directly
            // Here we use Mathf.Sin(t) for oscillation and scale by amplitude
            float offsetMagnitude = _amplitude * Mathf.Sin(t);

            Vector3 direction = _direction.normalized;

            if (_relativePositioning)
            {
                float deltaOffset = offsetMagnitude - _previousOffset;
                Vector3 delta = direction * deltaOffset;

                if (_useLocalSpace)
                    transform.Translate(delta, Space.Self);
                else
                    transform.Translate(delta, Space.World);

                _previousOffset = offsetMagnitude;
            }
            else
            {
                Vector3 offset = direction * offsetMagnitude;

                if (_useLocalSpace)
                    transform.localPosition = _startPosition + offset;
                else
                    transform.position = _startPosition + offset;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_showGizmos && !_showOnlyWhenSelected)
                RenderGizmos();
        }

        private void OnDrawGizmosSelected()
        {
            if (_showGizmos && _showOnlyWhenSelected)
                RenderGizmos();
        }

        private void RenderGizmos()
        {
            Vector3 origin = Application.isPlaying
                ? (_useLocalSpace ? transform.parent?.TransformPoint(_startPosition) ?? transform.position : _startPosition)
                : (_useLocalSpace ? transform.parent?.position ?? transform.position : transform.position);

            Vector3 dir = _useLocalSpace ? transform.TransformDirection(_direction.normalized) : _direction.normalized;

            Gizmos.color = _gizmoColor;
            Gizmos.DrawLine(origin - dir * _amplitude, origin + dir * _amplitude);
            Gizmos.DrawSphere(origin + dir * _amplitude, _gizmoSphereRadius);
            Gizmos.DrawSphere(origin - dir * _amplitude, _gizmoSphereRadius);
        }
#endif
    }
}
