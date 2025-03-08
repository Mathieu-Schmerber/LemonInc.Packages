using LemonInc.Core.Input;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts.Inputs
{
    public interface IInputProvider
    {
        public InputStateValue<Vector3> Movement { get; }
        public InputState Jump { get; }
    }
}