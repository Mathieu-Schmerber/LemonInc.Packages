using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Core.Utilities.Datatypes
{
    [Serializable, InlineProperty]
    public struct MinMax
    {
        [SerializeField, HorizontalGroup, LabelWidth(25)] private float _min;
        [SerializeField, HorizontalGroup, LabelWidth(25)] private float _max;
        
        public float Min { get => _min; set => _min = value; }
        public float Max { get => _max; set => _max = value; }

        public float InverseLerp(float value)
        {
            var eval = Mathf.Clamp(value, _min, _max);
            return Mathf.InverseLerp(_min, _max, eval);
        }
        
        public float Lerp(float ratio) => Mathf.Lerp(_min, _max, ratio);
        
        public float Clamp(float value) => Mathf.Clamp(value, _min, _max);
        
        public MinMax(float min, float max)
        {
            _min = min;
            _max = max;
        }
    }
    
    [Serializable, InlineProperty]
    public struct MinMaxInt
    {
        [SerializeField, HorizontalGroup, LabelWidth(25)] private int _min;
        [SerializeField, HorizontalGroup, LabelWidth(25)] private int _max;
        
        public int Min { get => _min; set => _min = value; }
        public int Max { get => _max; set => _max = value; }

        public float InverseLerp(float value)
        {
            var eval = Mathf.Clamp(value, _min, _max);
            return Mathf.InverseLerp(_min, _max, eval);
        }
        
        public float Lerp(float ratio) => Mathf.Lerp(_min, _max, ratio);
        
        public int Clamp(int value) => Mathf.Clamp(value, _min, _max);
        
        public MinMaxInt(int min, int max)
        {
            _min = min;
            _max = max;
        }
    }
}