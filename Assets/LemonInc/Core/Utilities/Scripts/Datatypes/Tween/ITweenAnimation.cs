using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    public interface ITweenAnimation
    {
        PrimeTween.Tween Play(Transform target);
        PrimeTween.Tween Reverse(Transform target);
    }
}