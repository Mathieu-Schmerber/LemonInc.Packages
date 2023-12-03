using System.Collections.Generic;
using System.Linq;
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
		[SerializeField] private VisualTreeAsset _uxml;

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
		private PanelsConfiguration Configuration => _configuration ??= PanelsConfiguration.Instance;

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

		/// <inheritdoc/>
		public void Init(string panelName)
		{
			if (string.IsNullOrEmpty(panelName) || _uxml == null || Configuration == null)
				return;
			
			Configuration.Panels[panelName].OpenedInstances ??= new List<string>();
			Configuration.Panels[panelName].OpenedInstances.Add(GetInstanceID().ToString());
			PanelsConfiguration.Instance.Save();

			_name = panelName;

			_sidebarController ??= new SidebarController(rootVisualElement, PanelDefinition.TargetFolder)
			{
				OnSelectionChanged = OnElementSelected,
				OnTargetFolderChanged = SetTargetFolder
			};

			_inspectorPanelController ??= new InspectorPanelController(rootVisualElement);
			_sidebarController.SelectElement(PanelDefinition.LastSelectedElementId);
		}

		private void CreateGUI()
		{
			if (string.IsNullOrEmpty(_name) && titleContent?.text.Contains("PanelEditorWindow") == false)
			{
				Init(titleContent?.text);
			}
		}

		/// <summary>
		/// Called when [enable].
		/// </summary>
		private void OnEnable()
		{
			_uxml.CloneTree(rootVisualElement);

			var config = Configuration.Panels.FirstOrDefault(x => x.Value.OpenedInstances?.Contains(GetInstanceID().ToString()) == true);
			if (config.Value == null)
			{
				return;
			}

			Init(config.Key);
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

		private void OnDestroy()
		{
			Configuration.Panels[_name].OpenedInstances.Remove(GetInstanceID().ToString()); 
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
			_inspectorPanelController.Bind(element);
			PanelDefinition.LastSelectedElementId = element.Id;
		}
    }
}
