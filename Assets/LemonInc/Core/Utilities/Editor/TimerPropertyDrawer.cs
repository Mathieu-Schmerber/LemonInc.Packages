using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(Timer))]
    public class TimerPropertyDrawer : PropertyDrawer
    {
        private const float LINE_HEIGHT = 18f;
        private const float INTERVAL_FIELD_WIDTH = 50f;
        private const float PROGRESS_BAR_PADDING = 5f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, LINE_HEIGHT);
            var intervalRect = new Rect(position.x + EditorGUIUtility.labelWidth, position.y, INTERVAL_FIELD_WIDTH, LINE_HEIGHT);
            var progressBarRect = new Rect(
                intervalRect.x + intervalRect.width + PROGRESS_BAR_PADDING,
                position.y,
                position.width - EditorGUIUtility.labelWidth - INTERVAL_FIELD_WIDTH - PROGRESS_BAR_PADDING,
                LINE_HEIGHT);

            EditorGUI.LabelField(labelRect, label);
            
            var intervalProp = property.FindPropertyRelative("_interval");
            EditorGUI.PropertyField(intervalRect, intervalProp, GUIContent.none);

            var elapsedTimeProp = property.FindPropertyRelative("_elapsedTime");
            var elapsedTime = elapsedTimeProp.floatValue;
            var intervalValue = intervalProp.floatValue;
            var progress = intervalValue > 0 ? Mathf.Clamp01(elapsedTime / intervalValue) : 0;

            EditorGUI.ProgressBar(progressBarRect, progress, $"{elapsedTime:0.00} / {intervalValue:0.00}s");
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            => LINE_HEIGHT;
    }
}