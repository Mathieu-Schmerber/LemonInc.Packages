using System;
using LemonInc.Core.Utilities.Editor;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Tools.Panels.Controllers;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using IPanel = LemonInc.Tools.Panels.Interfaces.IPanel;

namespace LemonInc.Tools.Panels
{
	/// <summary>
	/// Game design panel.
	/// </summary>
	/// <seealso cref="UnityEditor.EditorWindow" />
	public class PanelEditorWindow : EditorWindow, IPanel
    {
		/// <summary>
		/// The uxml.
		/// </summary>
		private VisualTreeAsset _uxml;

		/// <summary>
		/// The state.
		/// </summary>
		private PanelsConfiguration _configuration;

		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		private PanelsConfiguration Configuration => PanelsConfiguration.Instance;

		/// <summary>
		/// Gets the panel definition.
		/// </summary>
		/// <value>
		/// The panel definition.
		/// </value>
		private PanelDefinition PanelDefinition
		{
			get
			{
				if (!string.IsNullOrEmpty(_name) && Configuration?.Panels?.TryGetValue(_name, out PanelDefinition definition) == true)
					return definition;

				Debug.LogError($"LemonInc Configuration Error: Panel '{_name}' doesn't exist within the configuration.");
				return null;
			}
		}

		/// <summary>
		/// The name.
		/// </summary>
		private string _name;
		
		/// <summary>
		/// The sidebar.
		/// </summary>
		private SidebarController _sidebarController;

		/// <summary>
		/// The inspector panel.
		/// </summary>
		private InspectorPanelController _inspectorPanelController;

		public event Action<ISidebarElement> OnElementDeleted; 

		/// <inheritdoc/>
		public void Init(string panelName)
		{
			_uxml = Resources.Load<VisualTreeAsset>("Panel");
			titleContent = new GUIContent(panelName, EditorIcons.DScaletool.image);
			if (string.IsNullOrEmpty(panelName) || Configuration == null)
				return;

			_uxml.CloneTree(rootVisualElement);
			_name = panelName;

			_sidebarController ??= new SidebarController(rootVisualElement, this, PanelDefinition.TargetFolder)
			{
				OnSelectionChanged = OnElementSelected,
				OnTargetFolderChanged = SetTargetFolder
			};

			_inspectorPanelController ??= new InspectorPanelController(rootVisualElement, this);
			_sidebarController.SelectElement(PanelDefinition.LastSelectedElementId);
		}

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
		{
			if (string.IsNullOrEmpty(_name) && titleContent?.text.Contains("PanelEditorWindow") == false)
			{
				Init(titleContent?.text);
			}
			else
			{
				Init(_name);
			}
		}

		/// <summary>
		/// Called when [disable].
		/// </summary>
		private void OnDisable()
		{
			_sidebarController?.Dispose();
			_inspectorPanelController?.Dispose();
			Configuration.Save();
		}

		/// <summary>
		/// Updates this instance.
		/// </summary>
		private void Update()
		{
			_inspectorPanelController?.RepaintIfNeeded();
		}

		/// <summary>
		/// Sets the target folder.
		/// </summary>
		/// <param name="path">The path.</param>
		private void SetTargetFolder(string path)
		{
			PanelDefinition.TargetFolder = path;
			Configuration.Save();
		}

		/// <summary>
		/// Called when [element selected].
		/// </summary>
		/// <param name="element">The element.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnElementSelected(ISidebarElement element)
		{
			if (element == null) 
				return;
			
			_inspectorPanelController.Bind(element);
			PanelDefinition.LastSelectedElementId = element.Id;
		}

		public void RequestElementDeletion(ISidebarElement element)
		{
			if (EditorUtility.DisplayDialog($"Delete {element.DisplayName}", "You cannot undo the delete action",
				    "Delete", "Cancel"))
			{
				AssetDatabase.DeleteAsset(element.Path.ToAssetPath());
				OnElementDeleted?.Invoke(element);
			}
		}
    }
}
