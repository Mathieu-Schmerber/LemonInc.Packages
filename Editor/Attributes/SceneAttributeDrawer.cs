using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Utilities.Attributes;
using LemonInc.Core.Utilities.Editor.Helpers;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;  // Import ReorderableList namespace

namespace LemonInc.Core.Utilities.Editor.Attributes
{
    public class SceneAttributeDrawer : OdinAttributeDrawer<SceneAttribute>
    {
        private List<string> _sceneNames;
        private ReorderableList _reorderableList;

        protected override void Initialize()
        {
            base.Initialize();
            _sceneNames = SelectScene();
            InitializeReorderableList();
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            if (_sceneNames == null || _sceneNames.Count == 0)
            {
                _sceneNames = SelectScene();
                InitializeReorderableList(); // Reinitialize when scenes are empty
            }

            if (Property.ValueEntry.TypeOfValue == typeof(string))
            {
                DrawStringDropdown(label);
            }
            else if (Property.ValueEntry.TypeOfValue == typeof(string[]))
            {
                DrawReorderableList(label);
            }
            else
            {
                CallNextDrawer(label);
            }
        }

        private void DrawStringDropdown(GUIContent label)
        {
            var selectedScene = Property.ValueEntry.WeakSmartValue as string;
            Property.ValueEntry.WeakSmartValue = SirenixEditorFields.Dropdown(label, selectedScene, _sceneNames);
        }

        private void DrawReorderableList(GUIContent label)
        {
            var selectedScenes = Property.ValueEntry.WeakSmartValue as string[] ?? new string[0];
            _reorderableList.list = selectedScenes.ToList();

            _reorderableList.DoList(GUILayoutUtility.GetRect(200, 100));  // Define size

            // Convert the list back to an array and assign it to the property value
            Property.ValueEntry.WeakSmartValue = ((List<string>)_reorderableList.list).ToArray();
        }

        private void InitializeReorderableList()
        {
            _reorderableList = new ReorderableList(_sceneNames, typeof(string), true, true, true, true)
            {
                drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField(rect, "Select Scenes");
                },
                drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    if (index >= _sceneNames.Count) return;

                    // Draw the Popup for the scene name selection
                    var prev = index;
                    index = EditorGUI.Popup(rect, index, _sceneNames.ToArray());

                    // Handle the key event for deletion (SUPPR key)
                    if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Delete)
                    {
                        if (index >= 0 && index < _sceneNames.Count)
                        {
                            _sceneNames.RemoveAt(index); // Remove item from sceneNames
                            _reorderableList.list.RemoveAt(index); // Remove item from reorderableList
                            Property.ValueEntry.WeakSmartValue = _sceneNames.ToArray(); // Update the WeakSmartValue
                            Event.current.Use(); // Consume the event so it doesn't propagate
                        }
                    }

                    // Ensure that the scene name is updated
                    _sceneNames[prev] = _sceneNames[index];
                },
                onAddCallback = (ReorderableList list) =>
                {
                    list.list.Add(_sceneNames.FirstOrDefault() ?? ""); // Add a new empty scene string
                },
                onRemoveCallback = (ReorderableList list) =>
                {
                    // Remove the scene at the selected index from the list
                    int selectedIndex = list.index;
                    if (selectedIndex >= 0 && selectedIndex < _sceneNames.Count)
                    {
                        list.list.RemoveAt(selectedIndex);  // Remove from reorderable list

                        /*// Update the main sceneNames list
                        var tmp = list.list.Cast<string>().ToList();

                        // Update the WeakSmartValue to reflect the change in the property
                        Property.ValueEntry.WeakSmartValue = tmp.ToArray();*/
                    }
                }
            };
        }

        private static List<string> SelectScene()
        {
            var filesPath = SceneHelper.GetAllBuiltScene();
            return filesPath.Select(x => x.Name).Distinct().ToList();
        }
    }
}