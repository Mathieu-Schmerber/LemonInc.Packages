using UnityEditor;
using UnityEngine;

namespace LemonInc.Test
{
    [CustomPropertyDrawer(typeof(TestSo.TestProp))]
    public class TestPropDrawer : EventBasedPropertyDrawer
    {
        public override void OnEnable(Rect position, SerializedProperty property, GUIContent label) { }

        public override void OnDisable() { }

        public override void OnDestroy() { }

        public override void OnGUIWithEvent(Rect position, SerializedProperty property, GUIContent label) {}
    }
}
