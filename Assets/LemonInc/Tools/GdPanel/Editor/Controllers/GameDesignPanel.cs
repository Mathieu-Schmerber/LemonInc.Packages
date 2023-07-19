using LemonInc.Tools.GdPanel.Interfaces;
using LemonInc.Tools.GdPanel.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.GdPanel.Controllers
{
	/// <summary>
	/// Game design panel.
	/// </summary>
	/// <seealso cref="UnityEditor.EditorWindow" />
	public class GameDesignPanel : EditorWindow
    {
		/// <summary>
		/// The uxml.
		/// </summary>
		[SerializeField] private VisualTreeAsset _uxml;

		[MenuItem("Tools/LemonInc/Game Design Panel")]
	    public static void Open() => GetWindow<GameDesignPanel>();

		/// <summary>
		/// The state.
		/// </summary>
		private GameDesignPanelState _state;
		
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		private GameDesignPanelState State => _state ??= GameDesignPanelState.Instance;

		/// <summary>
		/// The sidebar.
		/// </summary>
		private SidebarController _sidebarController;

		/// <summary>
		/// The inspector panel.
		/// </summary>
		private InspectorPanelController _inspectorPanelController;

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
	    {
		    _uxml.CloneTree(rootVisualElement);
		    _sidebarController = new SidebarController(rootVisualElement, State.TargetFolder)
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
			State.TargetFolder = path;
			State.Save();
		}

		/// <summary>
		/// Called when [element selected].
		/// </summary>
		/// <param name="element">The element.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnElementSelected(ISidebarElement element) => _inspectorPanelController.Bind(element);
	}
}
