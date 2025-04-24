using System;
/*
namespace LemonInc.Core.Utilities.Datatypes
{
    [Serializable]
    public struct TweenParams<TValue>
    {
        public TValue From;
        public TValue To;
        public float Duration;
        public float Delay;
        public Ease EaseIn;
        public Ease EaseOut;

        public TweenParams(TValue from, TValue to, float duration)
        {
            From = from;
            To = to;
            Duration = duration;
            Delay = 0f;
            EaseIn = Ease.InQuad;
            EaseOut = Ease.OutQuad;
        }
        
        public delegate Tween TweenFromToDelegate<in TTarget>(
            TTarget target, 
            TValue startValue, 
            TValue endValue, 
            float duration, 
            Ease ease = Ease.Default, 
            int cycles = 1, 
            CycleMode cycleMode = CycleMode.Restart, 
            float startDelay = 0, 
            float endDelay = 0, 
            bool useUnscaledTime = false);
        
        public Tween Play<TTarget>(TTarget transform, TweenFromToDelegate<TTarget> call)
        {
            return call(transform, From, To, Duration, EaseIn, 1, CycleMode.Restart, Delay);
        }
        
        public Tween Reverse<TU>(TU transform, TweenFromToDelegate<TU> call)
        {
            return call(transform, To, From, Duration, EaseOut, 1, CycleMode.Restart, Delay);
        }
    }
}*/