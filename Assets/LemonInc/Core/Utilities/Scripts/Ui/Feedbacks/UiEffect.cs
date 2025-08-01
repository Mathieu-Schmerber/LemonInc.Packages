using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Ui.Feedbacks
{
    [Serializable]
    public abstract class UiEffect
    {
        public abstract void Initialize(Transform target);
        public abstract void Apply(float progress);
    }
}