﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codice.Client.Common;
using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Configuration.Extensions;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Editor.Utilities.Helpers;
using LemonInc.Tools.Databases.Editor.Controllers;
using LemonInc.Tools.Databases.Editor.Generators;
using LemonInc.Tools.Databases.Editor.Interfaces;
using LemonInc.Tools.Databases.Editor.Models;
using LemonInc.Tools.Databases.Editor.Policies;
using LemonInc.Tools.Databases.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using DatabaseConfiguration = LemonInc.Tools.Databases.Editor.Models.DatabaseConfiguration;

namespace LemonInc.Tools.Databases.Editor.Ui
{
	public class DatabaseEditorWindow : EditorWindow
	{
		/// <summary>
		/// The uxml.
		/// </summary>
		private VisualTreeAsset _uxml;

		/// <summary>
		/// The naming policy.
		/// </summary>
		private readonly INamingPolicy _namingPolicy = new AlphaNumericNamingPolicy();

		/// <summary>
		/// The references.
		/// </summary>
		private DatabasesReference _references;

		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		private DatabaseConfiguration Configuration => DatabaseConfiguration.Instance;

		/// <summary>
		/// The data.
		/// </summary>
		private Dictionary<DatabaseData, SectionDictionary> _data;

		/// <summary>
		/// The databases controller.
		/// </summary>
		private DatabasePanelController _databasesController;

		/// <summary>
		/// The sections controller.
		/// </summary>
		private TreeViewPanelController _sectionsController;

		/// <summary>
		/// The assets controller.
		/// </summary>
		private AssetPanelController _assetsController;

		/// <summary>
		/// The selected database.
		/// </summary>
		private DatabaseData _selectedDatabase;

		/// <summary>
		/// The selected section.
		/// </summary>
		private SectionDefinition _selectedSection;

		/// <summary>
		/// Opens the window.
		/// </summary>
		[MenuItem("Tools/LemonInc/Databases", false, 2)]
		public static void OpenWindow()
		{
			var window = GetWindow<DatabaseEditorWindow>();
			window.titleContent = new GUIContent("Databases", EditorIcons.DPrematcube.image);
			window.Focus();
			window.Show();
		}

		/// <summary>
		/// Initializes the window.
		/// </summary>
		private void Init()
		{
			_uxml = Resources.Load<VisualTreeAsset>("Databases");
			_data = ScaffoldDictionary();
			_uxml.CloneTree(rootVisualElement);
			_references = new DatabasesReference(rootVisualElement);

			// TODO: change UI
			//_references.Path.RegisterValueChangedCallback(evt =>
			//{
			//	var valid = !string.IsNullOrEmpty(evt.newValue) && Directory.Exists(Path.GetDirectoryName(evt.newValue));
			//	_references.Path.style.color = !valid ? Color.red : Color.white;
			//	_references.CompileToolbarButton.SetEnabled(valid);
			//});
			//_references.FolderToolbarButton.Insert(0, new Image { image = EditorIcons.DSettings.image });
			//_references.Path.text = string.IsNullOrEmpty(Configuration.ScriptPath) ? "No path set." : Configuration.ScriptPath;

			_databasesController = new DatabasePanelController(
				"Databases",
				new PanelReference(_references.DatabasesVisualElement),
				ValidateDatabase);

			_sectionsController = new TreeViewPanelController(
				"Sections",
				new PanelReference(_references.SectionsVisualElement),
				true,
				Color.yellow,
				ValidateItem);

			_assetsController = new AssetPanelController(
				"Assets",
				new PanelReference(_references.AssetsVisualElement),
				ValidateAsset);

			_databasesController.SetSource(GetAllDatabases().Values.ToList());

			_databasesController.Refresh();
			_sectionsController.Refresh();
			_assetsController.Refresh();

			Subscribe();

			//_databasesController.SelectItem(Configuration.LastSelectedDatabaseId);
			//_sectionsController.SelectItem(Configuration.LastSelectedSectionId);
			//_assetsController.SelectItem(Configuration.LastSelectedAssetId);
		}

		/// <summary>
		/// Subscribes this instance.
		/// </summary>
		private void Subscribe()
		{
			_references.FolderToolbarButton.clicked += SetScriptPath;
			_references.CompileToolbarButton.clicked += GenerateCode;

			_databasesController.OnItemCreated += AddDatabase;
			_databasesController.OnItemDeleted += DeleteDatabase;
			_databasesController.OnItemSelected += SelectDatabase;

			_sectionsController.OnItemCreated += AddSection;
			_sectionsController.OnItemDeleted += DeleteSection;
			_sectionsController.OnItemSelected += DisplayAssetsForSection;

			_assetsController.OnItemCreated += OnAssetAdded;
			_assetsController.OnItemDeleted += OnAssetRemoved;
		}

		/// <summary>
		/// Unsubscribes this instance.
		/// </summary>
		private void Unsubscribe()
		{
			_references.FolderToolbarButton.clicked -= SetScriptPath;
			_references.CompileToolbarButton.clicked -= GenerateCode;

			_databasesController.OnItemCreated -= AddDatabase;
			_databasesController.OnItemDeleted -= DeleteDatabase;
			_databasesController.OnItemSelected -= SelectDatabase;

			_sectionsController.OnItemCreated -= AddSection;
			_sectionsController.OnItemDeleted -= DeleteSection;
			_sectionsController.OnItemSelected -= DisplayAssetsForSection;

			_assetsController.OnItemCreated -= OnAssetAdded;
			_assetsController.OnItemDeleted -= OnAssetRemoved;
		}

		/// <summary>
		/// Called when [enable].
		/// </summary>
		private void OnEnable() => Init();

		/// <summary>
		/// Called when [disable].
		/// </summary>
		private void OnDisable()
		{
			SaveConfiguration();
			Unsubscribe();
		}

		/// <summary>
		/// Validates the asset.
		/// </summary>
		/// <param name="asset">The asset.</param>
		/// <param name="error">The error.</param>
		/// <returns>Whether the item is valid.</returns>
		private bool ValidateAsset(AssetDefinition asset, out string error)
		{
			var duplicate = _assetsController.Source.Count(x => x.Name == asset.Name) > 1;
			error = duplicate ? $"An asset is already named '{asset.Name}'." : "The name should be alphanumeric.";

			return !duplicate && _namingPolicy.Validate(asset.Name, out _);
		}

		/// <summary>
		/// Validates the item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="error">The error.</param>
		/// <returns>Whether the item is valid.</returns>
		private bool ValidateItem(SectionDefinition item, out string error)
		{
			var duplicate = item.Parent == null
				? _data[item.Database].Values.Count(x => x.Name == item.Name) > 1
				: item.Parent.Sections.Values.Count(x => x.Name == item.Name) > 1;

			var sameAsParent = item.Parent != null && item.Parent.Name.Equals(item.Name);
			var sameAsChild = item.Sections.Values.Any(x => x.Name.Equals(item.Name)); ;
			var taken = duplicate || sameAsChild || sameAsParent;

			error = taken ? $"'{item.Name}' is already taken." : "The name should be alphanumeric.";
			return !taken && _namingPolicy.Validate(item.Name, out _);
		}

		/// <summary>
		/// Validates the database.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="error">The error.</param>
		/// <returns>Whether the item is valid.</returns>
		private bool ValidateDatabase(DatabaseData data, out string error) => _namingPolicy.Validate(data.Name, out error);

		/// <summary>
		/// Selects a database.
		/// </summary>
		/// <param name="database">The database.</param>
		private void SelectDatabase(DatabaseData database)
		{
			_selectedDatabase = database;
			DisplayAssetsForSection(null);
			_sectionsController.SetChildren(_data[database].Values.ToList());
			_sectionsController.Refresh();
		}

		/// <summary>
		/// Displays the assets for the selected section.
		/// </summary>
		/// <param name="section">The section.</param>
		private void DisplayAssetsForSection(SectionDefinition section)
		{
			_selectedSection = section;
			_assetsController.SetSource(section?.Assets);
			_assetsController.Refresh();
		}

		/// <summary>
		/// Adds the database.
		/// </summary>
		/// <param name="database">The database.</param>
		private void AddDatabase(DatabaseData database)
		{
			database.Name = $"New Database {_data.Count}";
			var path = EditorUtility.OpenFolderPanel("Select a folder where the Database scriptable should be placed.", "Assets", "Assets");

			if (!string.IsNullOrEmpty(path))
			{
				var relative = path.ToAssetPath();
				var instance = CreateInstance<DatabaseData>();
				instance.Name = database.Name;
				_data.TryAdd(instance, new SectionDictionary());
				AssetDatabase.CreateAsset(instance, Path.Combine(relative, $"{database.Name}.asset"));
				AssetDatabase.SaveAssets();
			}
		}

		/// <summary>
		/// Adds a sections.
		/// </summary>
		/// <param name="section">the section.</param>
		private void AddSection(SectionDefinition section)
		{
			if (section?.Parent == null && _selectedDatabase == null)
			{
				return;
			}
			else if (section.Parent == null)
			{
				section.Database = _selectedDatabase;
				section.Name = $"New Section {_data[_selectedDatabase].Values.Count}";
				_data[_selectedDatabase].Add(section.Id, section);
			}
			else if (section.Parent != null)
			{
				section.Name = $"New Section {section.Parent.Sections.Count}";
				section.Parent.Sections.TryAdd(section.Id, section);
				section.Database = section.Parent.Database;
			}
		}

		/// <summary>
		/// Deletes the database.
		/// </summary>
		/// <param name="database">The database.</param>
		private void DeleteDatabase(DatabaseData database)
		{
			Debug.Log("TODO: delete");
		}

		/// <summary>
		/// Deletes a section.
		/// </summary>
		/// <param name="section">The section.</param>
		private void DeleteSection(SectionDefinition section)
		{
			if (section.Parent != null)
			{
				_selectedSection.Parent.Sections.Remove(section.Id);
			}
			else
			{
				_selectedDatabase.SectionDefinitions.Remove(section.Id);
			}

			_sectionsController.Refresh();
		}

		/// <summary>
		/// Called when [asset removed].
		/// </summary>
		/// <param name="asset">The asset.</param>
		private void OnAssetRemoved(AssetDefinition asset)
		{
			_selectedSection.Assets.Remove(asset);
			DisplayAssetsForSection(_selectedSection);
		}

		/// <summary>
		/// Called when [asset added].
		/// </summary>
		/// <param name="asset">The asset.</param>
		private void OnAssetAdded(AssetDefinition asset)
		{
			asset.Name = "New asset";
			_selectedSection?.Assets.Add(asset);
			DisplayAssetsForSection(_selectedSection);
		}

		/// <summary>
		/// Sets the script path.
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		private void SetScriptPath()
		{
			// TODO:
			//var path = EditorUtility.OpenFolderPanel("Select script path", "Assets", "");
			//if (string.IsNullOrEmpty(path))
			//	return;

			//Configuration.ScriptPath = $"{path.ToAssetPath()}/Databases.cs" ;
			//_references.Path.text = string.IsNullOrEmpty(Configuration.ScriptPath) ? "No path set." : Configuration.ScriptPath;
			//Configuration.Save();
		}

		/// <summary>
		/// Generates the code.
		/// </summary>
		private void GenerateCode()
		{
			SaveConfiguration();
			// TODO:
			//if (!string.IsNullOrEmpty(Configuration.ScriptPath))
			//	DatabaseCodeGenerator.GenerateScript(Configuration, Configuration.ScriptPath, true);
		}

		/// <summary>
		/// Saves the configuration.
		/// </summary>
		private void SaveConfiguration()
		{
			foreach (var database in _data.Keys)
			{
				foreach (var root in _data[database].Values)
				{
					FlattenData(database, root);
				}
				
				database.Save();
			}
			
			Configuration.LastSelectedDatabaseId = _databasesController.SelectedItem?.Data.Id;
			Configuration.LastSelectedSectionId = _sectionsController.SelectedItem?.Data.Id;
			Configuration.LastSelectedAssetId = _assetsController.SelectedItem?.Data.Id;
			
			Configuration.Save();
		}

		/// <summary>
		/// Flattens the data.
		/// </summary>
		/// <param name="rootSection">The root section.</param>
		private void FlattenData(DatabaseData database, SectionDefinition rootSection)
		{
			foreach (var (_, section) in rootSection.Sections)
			{
				if (database.SectionDefinitions.TryGetValue(section.Id, out var existing))
				{
					existing.Name = section.Name;
					existing.Assets = section.Assets.Select(asset => asset.Id).ToList();
					existing.Sections = section.Sections.Keys.ToList();
				}
				else
				{
					database.SectionDefinitions.Add(section.Id, new SectionDescription()
					{
						Id = section.Id,
						Name = section.Name,
						Assets = section.Assets.Select(asset => asset.Id).ToList(),
						Sections = section.Sections.Keys.ToList(),
					});
				}

				foreach (var assetDefinition in section.Assets)
				{
					if (database.AssetDefinitions.TryGetValue(assetDefinition.Id, out var asset))
					{
						asset.Name = assetDefinition.Name;
						asset.Data = assetDefinition.Data;
					}
					else
					{
						database.AssetDefinitions.Add(assetDefinition.Id, assetDefinition);
					}
				}

				FlattenData(database, section);
			}
		}

		/// <summary>
		/// Scaffolds a dictionary.
		/// </summary>
		/// <returns>The translated data.</returns>
		private Dictionary<DatabaseData, SectionDictionary> ScaffoldDictionary()
		{
			var result = new Dictionary<DatabaseData, SectionDictionary>();

			foreach (var (_, databaseData) in GetAllDatabases())
			{
				result.Add(databaseData, new SectionDictionary());

				foreach (var (id, section) in databaseData.SectionDefinitions)
				{
					var rootSection = new SectionDefinition
					{
						Id = id,
						Name = section.Name,
						Parent = null,
						Database = databaseData,
						Assets = new List<AssetDefinition>()
					};

					rootSection.Sections = ScaffoldSectionDictionary(databaseData, rootSection);
					result[databaseData].Add(rootSection.Id, rootSection);
				}
			}

			return result;
		}

		/// <summary>
		/// Scaffolds the section dictionary.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="parent">The parent.</param>
		/// <returns>The section dictionary.</returns>
		private SectionDictionary ScaffoldSectionDictionary(DatabaseData database, SectionDefinition parent)
		{
			var result = new SectionDictionary();

			foreach (var sectionId in database.SectionDefinitions[parent.Id].Sections)
			{
				var definition = database.SectionDefinitions[sectionId];
				var section = new SectionDefinition()
				{
					Id = sectionId,
					Name = definition.Name,
					Database = database,
					Parent = parent,
					Assets = definition.Assets.Select(x => database.AssetDefinitions[x]).ToList()
				};

				section.Sections = ScaffoldSectionDictionary(database, section);
				result.Add(sectionId, section);
			}

			return result;
		}

		/// <summary>
		/// Gets all databases.
		/// </summary>
		/// <returns>The databases.</returns>
		private Dictionary<string, DatabaseData> GetAllDatabases()
		{
			var databases = AssetHelper.FindAssetsByType<DatabaseData>();
			return databases.ToDictionary(x => x.Id);
		}
	}
}