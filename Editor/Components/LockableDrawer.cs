using System;
using System.Reflection;
using LemonInc.Core.Utilities.Datatypes;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Components
{
    [CustomPropertyDrawer(typeof(LockableBase), true)]
    public class LockableDrawer : PropertyDrawer
    {
        public static class Styles
        {
            private static GUIStyle _lockButton;
            public static GUIStyle LockButton => _lockButton ??= new GUIStyle(GUIStyle.none)
            {
                fixedWidth = 20,
                fixedHeight = 20,
                alignment = TextAnchor.MiddleCenter,
                margin = new RectOffset(2, 2, 2, 2),
                padding = new RectOffset(0, 0, 0, 0)
            };
        }
        
        private const float BUTTON_SIZE = 20f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var lockedProp = property.FindPropertyRelative("_locked");
            var valueProp = property.FindPropertyRelative("_value");

            const float buttonSize = 20f;
            const float spacing = 4f;

            // Rects
            var buttonRect = new Rect(position.x, position.y + (position.height - buttonSize) * 0.5f, buttonSize,
                buttonSize);
            var labelRect = new Rect(buttonRect.xMax + spacing, position.y,
                EditorGUIUtility.labelWidth - buttonSize - spacing, position.height);
            var fieldRect = new Rect(position.x + EditorGUIUtility.labelWidth, position.y,
                position.width - EditorGUIUtility.labelWidth, position.height);

            var icon = lockedProp.boolValue ? EditorIcons.P4Lockedlocal2X.image : EditorIcons.P4Lockedremote2X.image;
            var originalColor = GUI.color;
            if (lockedProp.boolValue)
                GUI.color = new Color(0.8f, 0.36f, 0.36f);

            var iconContent = new GUIContent(icon, lockedProp.boolValue ? "UnLock" : "Lock");
            if (GUI.Button(buttonRect, iconContent, Styles.LockButton))
                lockedProp.boolValue = !lockedProp.boolValue;
            GUI.color = originalColor;

            // Label
            EditorGUI.LabelField(labelRect, label);

            // Editable field
            EditorGUI.BeginChangeCheck();
            var wasEnabled = GUI.enabled;
            GUI.enabled = !lockedProp.boolValue;
            EditorGUI.PropertyField(fieldRect, valueProp, GUIContent.none);
            GUI.enabled = wasEnabled;

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                (GetTargetObject(property) as LockableBase)?.TriggerValuedChanged();
            }

            EditorGUI.EndProperty();
        }

        private object GetTargetObject(SerializedProperty property)
        {
            object obj = property.serializedObject.targetObject;
            var path = property.propertyPath.Replace(".Array.data[", "[");
            var elements = path.Split('.');

            foreach (var element in elements)
            {
                if (element.Contains("["))
                {
                    var elementName = element.Substring(0, element.IndexOf("["));
                    var index = Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                    var field = obj.GetType().GetField(elementName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    var list = field.GetValue(obj) as System.Collections.IList;
                    obj = list[index];
                }
                else
                {
                    var field = obj.GetType().GetField(element, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    if (field == null) return null;
                    obj = field.GetValue(obj);
                }
            }

            return obj;
        }
    }
}