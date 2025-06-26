using System;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.Inputs
{
    public class TouchTester : MonoBehaviour
    {
        private IInputProvider _inputs;

        private void Awake()
        {
            _inputs = GetComponent<IInputProvider>();
        }

        private void OnEnable()
        {
            _inputs.Left.OnPressed += OnLeftPressed;
            _inputs.Right.OnPressed += OnRightPressed;
        }

        private void OnRightPressed()
        {
            Debug.Log("Right Pressed");
        }

        private void OnLeftPressed()
        {
            Debug.Log("Left Pressed");
        }

        private void OnDisable()
        {
            _inputs.Left.OnPressed -= OnLeftPressed;
            _inputs.Right.OnPressed -= OnRightPressed;
        }
    }
}