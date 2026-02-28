using LemonInc.Core.Utilities.Datatypes;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Datatypes
{
    /// <summary>
    /// Odin drawer for Observable&lt;T&gt;. Renders the inner value inline with full Odin support.
    /// </summary>
    public class ObservableDrawer<T> : OdinValueDrawer<Observable<T>>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var entry = this.ValueEntry;
            var observable = entry.SmartValue;

            EditorGUI.BeginChangeCheck();

            // Draw inner _value property using Odin's tree so all Odin attributes on T are respected
            var valueProperty = entry.Property.Children["_value"];
            if (valueProperty != null)
            {
                if (label != null)
                    valueProperty.Label = label;

                valueProperty.Draw(label);
            }
            else
            {
                SirenixEditorGUI.ErrorMessageBox($"Observable<{typeof(T).Name}>: '_value' field not found.");
            }

            if (!EditorGUI.EndChangeCheck()) 
                return;
            
            // Odin writes back to _value; nudge OnAfterDeserialize to fire subscriptions
            entry.SmartValue = observable;
            entry.ApplyChanges();
        }
    }
}