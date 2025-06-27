using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities.Components
{
     public class AdvancedParentConstraint : MonoBehaviour
    {
        public enum UpdateMode
        {
            Update,
            LateUpdate,
            FixedUpdate,
            EndOfFrame
        }

        [TitleGroup("Target Settings", "Main constraint settings")]
        [Required, SerializeField, Tooltip("The target transform to follow")]
        private Transform _target;
        
        [TitleGroup("Target Settings")]
        [SerializeField, Tooltip("Should position be constrained?")]
        private bool _constrainPosition = true;
        
        [TitleGroup("Target Settings")]
        [SerializeField, Tooltip("Should rotation be constrained?")]
        private bool _constrainRotation = true;

        [TitleGroup("Offset Settings", "Offset values applied to the target")]
        [SerializeField, Tooltip("Position offset in target's local space")]
        private Vector3 _positionOffset;
        
        [TitleGroup("Offset Settings")]
        [SerializeField, Tooltip("Rotation offset in euler angles")]
        private Vector3 _rotationOffset;

        [TitleGroup("Smoothing Settings", "Interpolation settings")]
        [SerializeField, Range(0f, 1f), Tooltip("Position follow smoothness (0=instant, 1=no follow)")]
        private float _positionSmoothing = 0.1f;
        
        [TitleGroup("Smoothing Settings")]
        [SerializeField, Range(0f, 1f), Tooltip("Rotation follow smoothness (0=instant, 1=no follow)")]
        private float _rotationSmoothing = 0.1f;

        [TitleGroup("Update Settings", "When should the constraint be applied?")]
        [EnumToggleButtons, SerializeField]
        private UpdateMode _updateMode = UpdateMode.LateUpdate;

        [TitleGroup("Actions")]
        [Button(ButtonSizes.Medium)]
        [Tooltip("Automatically sets offsets to maintain current position/rotation")]
        public void SetOffsetToCurrent()
        {
            if (_target == null)
            {
                Debug.LogWarning("No target set for AdvancedParentConstraint");
                return;
            }

            _positionOffset = _target.InverseTransformPoint(transform.position);
            _rotationOffset = (Quaternion.Inverse(_target.rotation) * transform.rotation).eulerAngles;
            
            #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
            #endif
        }

        private IEnumerator EndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            ApplyConstraint();
        }

        private void Update()
        {
            switch (_updateMode)
            {
                case UpdateMode.EndOfFrame:
                    StartCoroutine(EndOfFrame());
                    return;
                case UpdateMode.Update:
                    ApplyConstraint();
                    break;
            }
        }

        private void LateUpdate()
        {
            if (_updateMode == UpdateMode.LateUpdate)
            {
                ApplyConstraint();
            }
        }

        private void FixedUpdate()
        {
            if (_updateMode == UpdateMode.FixedUpdate)
            {
                ApplyConstraint();
            }
        }

        private void ApplyConstraint()
        {
            if (_target == null)
                return;

            if (_constrainPosition)
            {
                var targetPosition = _target.TransformPoint(_positionOffset);
                transform.position = _positionSmoothing == 0f ? targetPosition : Vector3.Lerp(transform.position, targetPosition, _positionSmoothing);
            }

            if (_constrainRotation)
            {
                var targetRotation = _target.rotation * Quaternion.Euler(_rotationOffset);
                transform.rotation = _rotationSmoothing == 0f ? targetRotation : Quaternion.Lerp(transform.rotation, targetRotation, _rotationSmoothing);
            }
        }

    }
}