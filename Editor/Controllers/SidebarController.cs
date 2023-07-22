using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LemonInc.Editor.Utilities.Events;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.UIElements;
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
		/// Initializes a new instance of the <see cref="SidebarController"/> class.
		/// </summary>
		/// <param name="root">The root.</param>
		/// <param name="targetFolder">The target folder.</param>
		public SidebarController(VisualElement root, string targetFolder)
		{
			_root = root.Q<VisualElement>("Sidebar");
			_searchSearchField = root.Q<ToolbarSearchField>("Search");
			_targetFolder = targetFolder;

			EditorEvents.Asset.OnAssetDeleted += OnAssetDeleted;
			EditorEvents.Asset.OnAssetImported += OnAssetImported;
			EditorEvents.Asset.OnAssetMoved += OnAssetMoved;
			
			BuildUi();
		}
		
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
		/// Builds the UI.
		/// </summary>
		private void BuildUi()
		{
			_targetLabel = _root.Q<Label>("TargetDirectory");
			_targetLabel.SetEnabled(false);
			_targetLabel.text = $"Target: {_targetFolder.ToAssetPath()}";

			var settings = _root.Q<ToolbarMenu>("Settings");
			settings.Add(new Image
			{
				image = EditorIcons.SettingsCog.Active,
				style =
				{
					width = new StyleLength(25)
				}
			});
			settings.menu.AppendAction("Change target directory", ChangeTargetDirectory);

			_elementsView = _root.Q<TreeView>("Elements");
			_elementsView.makeItem = () => new SidebarEntry();
			_elementsView.bindItem = (element, index) => (element as SidebarEntry).Bind(_elementsView.GetItemDataForIndex<ISidebarElement>(index), _search);
			_elementsView.autoExpand = true;
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

			OnSelectionChanged?.Invoke(element as ISidebarElement);
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
				var id = Guid.NewGuid().GetHashCode();
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
				foreach (var subDir in subDirectories)
				{
					var branch = AnalyzeFileStructure(subDir);
					if (branch == null || !branch.Any())
						continue;

					foundObjectFile = true;
					var id = Guid.NewGuid().GetHashCode();
					fileStructure.Add(new TreeViewItemData<ISidebarElement>(id, new SidebarElementGroup(id)
					{
						DisplayName = Path.GetFileNameWithoutExtension(subDir),
						Path = subDir
					}, children: branch));
				}

				var files = Directory.GetFiles(path).Where(x => IsObject(x) && MatchSearch(x, _search));
				foreach (var file in files)
				{
					foundObjectFile = true;
					var id = Guid.NewGuid().GetHashCode();
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

			_elementsView.Clear();
			_elementsView.SetRootItems(roots);
			_elementsView.Rebuild();
		}
	}
}