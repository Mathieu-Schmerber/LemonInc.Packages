using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using LemonInc.Core.Utilities.Editor.Events;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using TreeView = UnityEngine.UIElements.TreeView;

namespace LemonInc.Tools.Panels.Controllers
{
	/// <summary>
	/// Handles the <see cref="PanelEditorWindow"/> sidebar.
	/// </summary>
	public class SidebarController : IDisposable
	{
		/// <summary>
		/// The root.
		/// </summary>
		private VisualElement _root;

		private readonly PanelEditorWindow _main;

		/// <summary>
		/// The target folder.
		/// </summary>
		private string _targetFolder;
		private Label _targetLabel;

		/// <summary>
		/// The search value.
		/// </summary>
		private string _search;
		private ToolbarSearchField _searchSearchField;

		/// <summary>
		/// The sidebar elements.
		/// </summary>
		private List<ISidebarElement> _sidebarElements;
		private TreeView _elementsView;

		/// <summary>
		/// The on selection changed.
		/// </summary>
		public Action<ISidebarElement> OnSelectionChanged;

		/// <summary>
		/// The on target folder changed.
		/// </summary>
		public Action<string> OnTargetFolderChanged;

		/// <summary>
		/// The currently selected element.
		/// </summary>
		[CanBeNull] private ISidebarElement _selectedItem;

		/// <summary>
		/// Field used for renaming entries
		/// </summary>
		private TextField _renameField;
        
        /// <summary>
        /// Flag indicating if we're currently reordering items
        /// </summary>
        private bool _isReordering = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="SidebarController"/> class.
		/// </summary>
		/// <param name="root">The root.</param>
		/// <param name="main">The main.</param>
		/// <param name="targetFolder">The target folder.</param>
		public SidebarController(VisualElement root, PanelEditorWindow main, string targetFolder)
		{
			_root = root.Q<VisualElement>("Sidebar");
			_searchSearchField = root.Q<ToolbarSearchField>("Search");
			_main = main;
			_main.OnElementDeleted += OnElementDeleted;
			_targetFolder = targetFolder;

			EditorEvents.Asset.OnAssetDeleted += OnAssetDeleted;
			EditorEvents.Asset.OnAssetImported += OnAssetImported;
			EditorEvents.Asset.OnAssetMoved += OnAssetMoved;
			
			BuildUi();
		}

		private void OnElementDeleted(ISidebarElement obj) => _sidebarElements.Remove(obj);

		/// <inheritdoc/>
		public void Dispose()
		{
			EditorEvents.Asset.OnAssetDeleted -= OnAssetDeleted;
			EditorEvents.Asset.OnAssetImported -= OnAssetImported;
			EditorEvents.Asset.OnAssetMoved -= OnAssetMoved;
		}

		/// <summary>
		/// Called when [asset moved].
		/// </summary>
		/// <param name="oldAssetPath">The old asset path.</param>
		/// <param name="newAssetPath">The new asset path.</param>
		private void OnAssetMoved(string oldAssetPath, string newAssetPath)
		{
			// Don't refresh if we're the ones doing the moving via reordering
            if (_isReordering)
                return;
                
			// TODO: optimize
			// TODO: if old in tree, remove entry, and if new in tree, add entry
			Refresh();
		}

		/// <summary>
		/// Called when [asset imported].
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		private void OnAssetImported(string assetPath)
		{
			// TODO: optimize
			// TODO: if asset path in tree, locate group and add entry to group
			Refresh();
		}

		/// <summary>
		/// Called when [asset deleted].
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		private void OnAssetDeleted(string assetPath)
		{
			// TODO: optimize
			// TODO: if asset path in tree, remove entry
			Refresh();
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh()
		{
			PopulateTree();
		}

		/// <summary>
		/// Selects the element.
		/// </summary>
		/// <param name="elementId">The element identifier.</param>
		public void SelectElement(int elementId)
		{
			_elementsView.AddToSelectionById(elementId);
		}

		/// <summary>
		/// Builds the UI.
		/// </summary>
		private void BuildUi()
		{
			_targetLabel = _root.Q<Label>("TargetDirectory");
			_targetLabel.SetEnabled(false);
			_targetLabel.text = $"Target: {_targetFolder.ToAssetPath()}";

			var settings = _root.Q<ToolbarMenu>("Settings");
			settings.menu.AppendAction("Create section", CreateRootSection);
			settings.menu.AppendAction("Create item", CreateRootItem);
			settings.menu.AppendSeparator();
			settings.menu.AppendAction("Change target directory", ChangeTargetDirectory);

			_sidebarElements = new List<ISidebarElement>();
			_elementsView = _root.Q<TreeView>("Elements");
			_elementsView.makeItem = () => new SidebarEntry();
			_elementsView.bindItem = (element, index) =>
			{
				var entry = element as SidebarEntry;
				var sidebarElement = _elementsView.GetItemDataForIndex<ISidebarElement>(index);
				entry!.Bind(sidebarElement, _search);
				entry.OnRenameSuccess = (id, newName) => RenameEntry(sidebarElement, sidebarElement.DisplayName, newName);
				entry.OnDeleteRequested = () => _main.RequestElementDeletion(sidebarElement);
				entry.OnCreateItemRequested = () => CreateSubItem(sidebarElement);
				entry.OnCreateSectionRequested = () => CreateSubSection(sidebarElement);
				_sidebarElements.Add(sidebarElement);
			};
			_elementsView.autoExpand = true;
			_elementsView.reorderable = false;
			_elementsView.selectionChanged += SelectionChanged;
			
			_searchSearchField.RegisterCallback<ChangeEvent<string>>(Search);

			if (!string.IsNullOrEmpty(_targetFolder))
				PopulateTree();
		}
		
		/// <summary>
		/// Executes a search.
		/// </summary>
		/// <param name="searchString"></param>
		private void Search(ChangeEvent<string> searchString)
		{
			var prev = _search ?? string.Empty;
			_search = searchString.newValue.Trim();

			if (!prev.Equals(_search ?? string.Empty))
				Refresh();
		}

		/// <summary>
		/// Selections the changed.
		/// </summary>
		/// <param name="obj">The object.</param>
		private void SelectionChanged(IEnumerable<object> obj)
		{
			var element = obj.FirstOrDefault(x => x is ISidebarElement);

			_selectedItem = element as ISidebarElement;
			OnSelectionChanged?.Invoke(_selectedItem);
		}

		/// <summary>
		/// Changes the target directory.
		/// </summary>
		/// <param name="obj">The object.</param>
		private void ChangeTargetDirectory(DropdownMenuAction obj)
		{
			_targetFolder = EditorUtility.OpenFolderPanel("Select target folder", "", "");
			_targetLabel.text = $"Target: {_targetFolder.ToAssetPath()}";
			OnTargetFolderChanged?.Invoke(_targetFolder);
			PopulateTree();
		}
		
		/// <summary>
		/// Creates a new item at the root.
		/// </summary>
		private void CreateRootItem(DropdownMenuAction obj)
		{
			var sections = _sidebarElements
				.Where(x => x.Type == SidebarElementType.GROUP)
				.ToList();
			
			ItemCreatorEditorWindow.Open(sections, _targetFolder);
		}

		/// <summary>
		/// Creates a new section at the root.
		/// </summary>
		private void CreateRootSection(DropdownMenuAction obj)
		{
			var folder = _targetFolder;
			var name = "New Section";
			var path = Path.Combine(folder, name.ToUniquePathName(folder));
    
			Directory.CreateDirectory(path);
			AssetDatabase.Refresh();
		}
		
		private void CreateSubSection(ISidebarElement sidebarElement)
		{
			var folder = sidebarElement.Path;
			var name = "New Section";
			var path = Path.Combine(folder, name.ToUniquePathName(folder));
    
			Directory.CreateDirectory(path);
			AssetDatabase.Refresh();
		}

		private void CreateSubItem(ISidebarElement sidebarElement)
		{
			var sections = _sidebarElements
				.Where(x => x.Type == SidebarElementType.GROUP)
				.ToList();
			
			ItemCreatorEditorWindow.Open(sections, _targetFolder, sidebarElement);
		}

		private void RenameEntry(ISidebarElement sidebarElement, string oldName, string newName)
		{
			var extension = Path.GetExtension(sidebarElement.Path);
			var current = $"{newName}{extension}";
			var name = current.ToUniquePathName(Path.GetDirectoryName(sidebarElement.Path));
			
			Debug.Log($"{current} => {name}");
			AssetDatabase.RenameAsset(sidebarElement.Path.ToAssetPath(), name);
			AssetDatabase.Refresh();
		}
		
		/// <summary>
		/// Determines whether the specified path is an object.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns>
		///   <c>true</c> if the specified path is object; otherwise, <c>false</c>.
		/// </returns>
		private static bool IsObject(string path) => Path.GetExtension(path) == ".asset";

		/// <summary>
		/// Returns true if the path matches the search.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="search"></param>
		/// <returns></returns>
		private static bool MatchSearch(string path, string search)
		{
			return string.IsNullOrEmpty(search) || Path.GetFileNameWithoutExtension(path).Contains(search, StringComparison.InvariantCultureIgnoreCase);
		}

		/// <summary>
		/// Analyzes the file structure.
		/// </summary>
		/// <param name="path">The path.</param>
		public List<TreeViewItemData<ISidebarElement>> AnalyzeFileStructure(string path)
		{
			var foundObjectFile = false;
			var fileStructure = new List<TreeViewItemData<ISidebarElement>>();

			if (File.Exists(path) && IsObject(path) && MatchSearch(path, _search))
			{
				foundObjectFile = true;
				var id = path.GetHashCode();
				fileStructure.Add(new TreeViewItemData<ISidebarElement>(id, new SidebarElement(id)
				{
					DisplayName = Path.GetFileNameWithoutExtension(path),
					Object = AssetDatabase.LoadAssetAtPath(path.ToAssetPath(), typeof(Object)),
					Path = path
				}));
			}
			else if (Directory.Exists(path))
			{
				// Path points to a directory
				var subDirectories = Directory.GetDirectories(path);
				foundObjectFile = true;
				foreach (var subDir in subDirectories)
				{
					var branch = AnalyzeFileStructure(subDir);
					if (branch == null)
						continue;

					var id = subDir.GetHashCode();
					fileStructure.Add(new TreeViewItemData<ISidebarElement>(id, new SidebarElementGroup(id)
					{
						DisplayName = Path.GetFileNameWithoutExtension(subDir),
						Path = subDir,
						Empty = !branch.Any()
					}, children: branch));
				}

				var files = Directory.GetFiles(path).Where(x => IsObject(x) && MatchSearch(x, _search));
				foreach (var file in files)
				{
					var id = file.GetHashCode();
					fileStructure.Add(new TreeViewItemData<ISidebarElement>(id, new SidebarElement(id)
					{
						DisplayName = Path.GetFileNameWithoutExtension(file),
						Object = AssetDatabase.LoadAssetAtPath(file.ToAssetPath(), typeof(Object)),
						Path = file
					}));
				}

			}

			return foundObjectFile ? fileStructure : null;
		}

		/// <summary>
		/// Populates the tree.
		/// </summary>
		private void PopulateTree()
		{
			var roots = AnalyzeFileStructure(_targetFolder);

			_sidebarElements.Clear();
			_elementsView.Clear();
			_elementsView.SetRootItems(roots);
			_elementsView.Rebuild();
		}
	}
}