using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Core.Utilities.Editor.Helpers;
using LemonInc.Core.Utilities.Editor.SearchWindows;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Ui;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Panels
{
    public class ItemCreatorEditorWindow : EditorWindow
    {
        private VisualTreeAsset _uxml;
        private CreateItemReference _references;
        [CanBeNull] private Type _selectedType;
        private string _targetFolder;
        private List<ISidebarElement> _sections;

        public static ItemCreatorEditorWindow Open(List<ISidebarElement> sections, string targetFolder, [CanBeNull] ISidebarElement section = null)
        {
            var window = CreateWindow<ItemCreatorEditorWindow>();
            window.titleContent = new GUIContent("Create New Item");
			window.Bind(sections, targetFolder, section);
            window.Show();
            window.Focus();
            return window;
        }

        private void Bind(List<ISidebarElement> sections, string targetFolder, [CanBeNull] ISidebarElement section = null)
        {
            var path = sections.Select(s => s.Path.Replace($"{targetFolder}\\", "")).ToList();
            path.Insert(0, "\\");

            _sections = sections;
            _targetFolder = targetFolder;
            _references.SectionDropdownField.choices = path;
            _references.SectionDropdownField.value = section == null ? path.FirstOrDefault() : section.Path.Replace($"{targetFolder}\\", "");

            _selectedType = TryGetDefaultType(_references.SectionDropdownField.value);
            _references.DataTypeButton.text = _selectedType == null ? "" : _selectedType.Name;
            
            _references.DataTypeButton.clicked += FetchTypes;
            _references.CreateButton.clicked += CreateItem;
            _references.CancelButton.clicked += Close;
        }

        [CanBeNull]
        private Type TryGetDefaultType(string path)
        {
            if (path.IsNullOrEmpty() || path == "\\")
                return null;
            
            var full = Path.Combine(_targetFolder, path);
            Debug.Log(_targetFolder);
            Debug.Log(path);
            Debug.Log(full);
            var assetPath = full.ToAssetPath();
            var assets = AssetHelper.FindAssetsByType<ScriptableObject>(assetPath);
            
            return assets.FirstOrDefault()?.GetType();
        }

        private bool ValidateForm(out string error)
        {
            error = string.Empty;
            if (_selectedType == null)
            {
                error = "Please select a data type";
                return false;
            }
            else if (string.IsNullOrEmpty(_references.NameTextField.text))
            {
                error = "Please enter a name";
                return false;
            }

            return true;
        }
        
        private void CreateItem()
        {
            if (ValidateForm(out string error))
            {
                var path = string.Empty;
                var index = _references.SectionDropdownField.index;
                if (index == 0)
                    path = _targetFolder;
                else
                    path = _sections[index - 1].Path;

                var assetName = $"{_references.NameTextField.text}.asset";
                var unique = assetName.ToUniquePathName(path);
                var assetPath = Path.Combine(path, unique);
                var item = CreateInstance(_selectedType);
                
                Close();
                AssetDatabase.CreateAsset(item, assetPath.ToAssetPath());
                AssetDatabase.SaveAssets();
            }
            else
                ShowError(error);
        }
        
        private void ShowError(string errorMessage = "")
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                _references.ErrorLabel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
                return;
            }

            _references.ErrorLabel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
            _references.ErrorLabel.text = errorMessage;
        }

        private void FetchTypes()
        {
            GenericSearchWindow.Open(
                build: () =>
                {
                    var entries = new List<SearchTreeEntry>();
                    var assemblies = AppDomain.CurrentDomain.GetUserCreatedAssemblies().ToArray();
                    var types = typeof(ScriptableObject).GetConcreteChildTypes(assemblies, typeof(Editor), typeof(EditorWindow), typeof(VisualElement));
                    var groupedByAssembly = types
                        .GroupBy(t => t.Assembly)
                        .ToDictionary(g => g.Key, g => g.ToList());
                    
                    entries.Add(new SearchTreeGroupEntry(new GUIContent("Data types")));
                    foreach (var kvp in groupedByAssembly)
                    {
                        entries.Add(new SearchTreeGroupEntry(new GUIContent(kvp.Key.GetName().Name)) { level = 1 });
                        foreach (var type in kvp.Value)
                            entries.Add(new SearchTreeEntry(new GUIContent(type.Name)) { level = 2, userData = type});
                    }

                    return entries;
                },
                onEntrySelected: (entry, _) =>
                {
                    _selectedType = entry.userData as Type;
                    _references.DataTypeButton.text = entry.content.text;
                    if (string.IsNullOrEmpty(_references.NameTextField.value))
                        _references.NameTextField.value = $"New {entry.content.text}";
                });
        }

        private void CreateGUI()
        {
            _uxml = Resources.Load<VisualTreeAsset>("CreateItem");
            _uxml.CloneTree(rootVisualElement);
            _references = new CreateItemReference(rootVisualElement);
            
            _references.RootVisualElement.RegisterCallback<GeometryChangedEvent>(FitToContent);
        }
        
        
        /// <summary>
        /// Fits to content.
        /// </summary>
        /// <param name="event"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void FitToContent(GeometryChangedEvent @event)
        {
            minSize = new Vector2(
                _references.RootVisualElement.resolvedStyle.width,
                _references.RootVisualElement.resolvedStyle.height
            );
            maxSize = minSize;
        }
    }
}