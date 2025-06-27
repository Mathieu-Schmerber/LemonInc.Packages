using LemonInc.Core.Utilities.Components;
using LemonInc.Core.Utilities.Datatypes;
using UnityEngine;

namespace LemonInc.Test.ComponentsDemo
{
    public class CubeHandler : MonoBehaviour
    {
        public Lockable<bool> ShouldRotate = new(true);
        private Rotate _rotate;
        
        private void Awake()
        {
            _rotate = GetComponent<Rotate>();
        }
        
        private void OnEnable()
        {
            ShouldRotate.OnValueChanged += OnShouldRotateChanged;
        }

        private void OnDisable()
        {
            ShouldRotate.OnValueChanged += OnShouldRotateChanged;
        }

        private void OnShouldRotateChanged(bool value)
        {
            _rotate.enabled = value;
        }
    }
}