using System;
using PrimeTween;

namespace LemonInc.Core.Utilities.Datatypes.Tween
{
    [Serializable]
    public struct TweenValue01
    {
        private float _from;
        private float _to;
        public float Duration;
        public Ease EaseIn;
        public Ease EaseOut;

        public TweenValue01(float duration)
        {
            _from = 0;
            _to = 1;
            Duration = duration;
            EaseIn = Ease.InQuad;
            EaseOut = Ease.OutQuad;
        }
        
        public PrimeTween.Tween Play(Action<float> callback)
        {
            return PrimeTween.Tween.Custom(_from, _to, Duration, callback, EaseIn);
        }
        
        public PrimeTween.Tween Reverse(Action<float> callback)
        {
            return PrimeTween.Tween.Custom(_from, _to, Duration, callback, EaseOut);
        }

        public Sequence PingPong(Action<float> callback, float inBetweenDelay = 0f)
        {
            var sequence = Sequence.Create().Chain(Play(callback));
            
            if (inBetweenDelay > 0)
                sequence.ChainDelay(inBetweenDelay);
            sequence.Chain(Reverse(callback));
            return sequence;
        }
    }
}