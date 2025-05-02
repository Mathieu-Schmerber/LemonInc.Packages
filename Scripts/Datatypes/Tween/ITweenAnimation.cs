using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    public interface ITweenAnimation
    {
        PrimeTween.Tween Play(Transform target, bool useTimeScale = true);
        PrimeTween.Tween Reverse(Transform target, bool useTimeScale = true);
    }
}