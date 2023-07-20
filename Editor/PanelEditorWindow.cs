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
				if (Configuration.Panels.TryGetValue(_name, out PanelDefinition definition))
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
			_name = panelName;

			_uxml.CloneTree(rootVisualElement);
			_sidebarController = new SidebarController(rootVisualElement, PanelDefinition.TargetFolder)
			{
				OnSelectionChanged = OnElementSelected,
				OnTargetFolderChanged = SetTargetFolder
			};

			_inspectorPanelController = new InspectorPanelController(rootVisualElement);
		}

		/// <summary>
		/// Called when [disable].
		/// </summary>
		private void OnDisable()
		{
			_sidebarController?.Dispose();
			_inspectorPanelController?.Dispose();
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
		private void OnElementSelected(ISidebarElement element) => _inspectorPanelController.Bind(element);
    }
}
