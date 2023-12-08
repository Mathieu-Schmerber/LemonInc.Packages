using System;
using System.IO;
using System.Text;
using LemonInc.Editor.Utilities.Configuration;
using LemonInc.Editor.Utilities.Configuration.Extensions;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Tools.Panels.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Panels
{
	/// <summary>
	/// Panel creator editor window.
	/// </summary>
	public class PanelCreatorEditorWindow : EditorWindow
	{
		/// <summary>
		/// The uxml.
		/// </summary>
		private VisualTreeAsset _uxml;

		/// <summary>
		/// Opens this instance.
		/// </summary>
		[MenuItem("Tools/LemonInc/Panels/Create New Panel...", priority = 1)]
		public static void Open()
		{
			var window = CreateWindow<PanelCreatorEditorWindow>();
			window.titleContent = new GUIContent("Create New Panel");
			
			window.Show();
			window.Focus();
		} 

		/// <summary>
		/// The panel name.
		/// </summary>
		private string _panelName;
		private TextField _panelNameTextField;

		/// <summary>
		/// The panel target folder.
		/// </summary>
		private string _panelTargetFolder;
		private TextField _panelTargetFolderTextField;
		private Button _panelTargetFolderButton;

		/// <summary>
		/// Error label.
		/// </summary>
		private Label _errorLabel;

		/// <summary>
		/// The create button.
		/// </summary>
		private Button _createButton;

		/// <summary>
		/// The cancel button.
		/// </summary>
		private Button _cancelButton;

		/// <summary>
		/// The root visual element.
		/// </summary>
		private VisualElement _root;

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
		private PanelsConfiguration Configuration => _configuration ??= PanelsConfiguration.instance;

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
		{
			_uxml = Resources.Load<VisualTreeAsset>("CreatePanel");
			_uxml.CloneTree(rootVisualElement);

			_root = rootVisualElement.Q<VisualElement>("Root");
			_panelNameTextField = rootVisualElement.Q<TextField>("PanelName");
			_panelTargetFolderTextField = rootVisualElement.Q<TextField>("TargetFolder");
			_panelTargetFolderButton = rootVisualElement.Q<Button>("SelectFolder");
			_errorLabel = rootVisualElement.Q<Label>("Error");
			_createButton = rootVisualElement.Q<Button>("Create");
			_cancelButton = rootVisualElement.Q<Button>("Cancel");

			_panelTargetFolderButton.clicked += SelectFolder;
			_createButton.clickable.clicked += CreatePanel;
			_cancelButton.clickable.clicked += Close;

			_root.RegisterCallback<GeometryChangedEvent>(FitToContent);
		}

		/// <summary>
		/// Called when [disable].
		/// </summary>
		private void OnDisable()
		{
			Configuration.Save();
		}

		/// <summary>
		/// Fits to content.
		/// </summary>
		/// <param name="event"></param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void FitToContent(GeometryChangedEvent @event)
		{
			minSize = new Vector2(
				_root.resolvedStyle.width,
				_root.resolvedStyle.height
			);
			maxSize = minSize;
		}

		/// <summary>
		/// Shows an error.
		/// </summary>
		/// <param name="errorMessage"></param>
		private void ShowError(string errorMessage = "")
		{
			if (string.IsNullOrEmpty(errorMessage))
			{
				_errorLabel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
				return;
			}

			_errorLabel.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
			_errorLabel.text = errorMessage;
		}

		/// <summary>
		/// Validates the form.
		/// </summary>
		/// <param name="error">The error message.</param>
		/// <returns>true if the form is valid.</returns>
		private bool ValidateForm(out string error)
		{
			_panelName = _panelNameTextField.value.Trim();
			_panelTargetFolder = _panelTargetFolderTextField.value.Trim();

			var builder = new StringBuilder();

			if (string.IsNullOrEmpty(_panelName))
				builder.AppendLine("The panel requires a name.");
			if (string.IsNullOrWhiteSpace(_panelTargetFolder))
				builder.AppendLine("The panel has no target folder defined.");
			else if (!Directory.Exists(_panelTargetFolder))
				builder.AppendLine("The defined target folder does not exist.");
			if (Configuration.Panels.ContainsKey(_panelName))
				builder.AppendLine($"A panel named '{_panelName}' already exists.");

			error = builder.ToString();
			return string.IsNullOrEmpty(error);
		}

		/// <summary>
		/// Selects the folder.
		/// </summary>
		private void SelectFolder()
		{
			_panelTargetFolder = EditorUtility.OpenFolderPanel("Select target folder", "Assets", "Assets");
			_panelTargetFolderTextField.value = _panelTargetFolder.ToAssetPath();
		}

		/// <summary>
		/// Creates the panel.
		/// </summary>
		private void CreatePanel()
		{
			if (ValidateForm(out string error))
			{
				Configuration.Panels.Add(_panelName, new PanelDefinition
				{
					TargetFolder = _panelTargetFolder
				});

				Configuration.Save();

				var output = Path.GetFullPath("Assets/Settings/LemonInc/Resources/Panels/Panels.cs");
				PanelCodeGenerator.GenerateScript(Configuration.Panels, output, true);
				Close();
			}
			else
			{
				ShowError(error);
			}
		}
	}
}
