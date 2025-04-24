using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Tools.Packager.Editor.Extensions;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
	/// <summary>
	/// Package handler editor window
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class PackagerEditorWindow : EditorWindow
	{
		[SerializeField] private VisualTreeAsset _baseUxml;
		[SerializeField] private VisualTreeAsset _packageScopeTemplate;

		/// <summary>
		/// The title.
		/// </summary>
		internal const string TITLE = "LemonInc Packager";
		
		private ScrollView _packageView;
		private Label _stateLabel;
		private Button _installBtn;
		private Button _deleteBtn;
		
		/// <summary>
		/// The packages by scope.
		/// </summary>
		private Dictionary<string, List<LemonIncPackage>> _packagesByScope;
		
		[MenuItem("Tools/LemonInc/Packager", false, 1)]
		public static void OpenWindow()
		{
			var window = GetWindow<PackagerEditorWindow>(TITLE);
			window.Show();
		}

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
		{
			rootVisualElement.Clear();
			_baseUxml.CloneTree(rootVisualElement);
			_stateLabel = rootVisualElement.Q<Label>("State");
			_stateLabel.text = "Fetching packages...";
			_packageView = rootVisualElement.Q<ScrollView>("PackageList");
			_installBtn = rootVisualElement.Q<Button>("Install");
			_deleteBtn = rootVisualElement.Q<Button>("Delete");
			
			_installBtn.SetEnabled(false);
			_deleteBtn.SetEnabled(false);

			_installBtn.clicked += BatchInstall;
			_deleteBtn.clicked += BatchDelete;
		}
		
		private void BatchInstall()
		{
			var selection = _packagesByScope
				.SelectMany(x => x.Value)
				.Where(x => x.Selected)
				.ToArray();

			if (!selection.Any())
				return;

			foreach (var package in selection)
			{
				package.OnSelectionChanged -= UpdateSelectionDisplay;
				package.Selected = false;
			}

			_packageView.SetEnabled(false);
			EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.BatchInstall(selection, success =>
			{
				for (int i = 0; i < success.Count; i++)
				{
					var package = selection[i];
					if (success[i])
						package.Installed = true;
				}
				
				PopulatePackageView();
			}), this);
		}

		private void BatchDelete()
		{
			var selection = _packagesByScope
				.SelectMany(x => x.Value)
				.Where(x => x.Selected)
				.ToArray();

			if (!selection.Any())
				return;

			foreach (var package in selection)
			{
				package.OnSelectionChanged -= UpdateSelectionDisplay;
				package.Selected = false;
			}

			_packageView.SetEnabled(false);
			EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.BatchRemove(selection, success =>
			{
				for (int i = 0; i < success.Count; i++)
				{
					var package = selection[i];
					if (success[i])
						package.Installed = false;
				}
				
				PopulatePackageView();
			}), this);
		}
		
		/// <summary>
		/// Called when [enable].
		/// </summary>
		private async void OnEnable()
		{
			var branches = await GithubUtility.ListRepositoryBranches("Mathieu-Schmerber", "LemonInc.Packages");
			var installedPackages = await LemonIncPackageUtility.GetInstalledPackages();

			var packages = branches.Where(LemonIncPackageUtility.IsValidPackageName).Select(x => new LemonIncPackage()
			{
				BranchName = x,
				Scope = x.Split('.')[0].ToTitleCaseFromDashed(),
				Feature = x.Split('.')[1].ToTitleCaseFromDashed(),
				Installed = installedPackages.Any(y => y.name.Equals(x.ToLemonIncPackageName()))
			});

			_packagesByScope = packages.GroupBy(lemonIncPackage => lemonIncPackage.Scope)
				.ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());
			
			rootVisualElement.Remove(_stateLabel);
			PopulatePackageView();
		}

		private void OnDisable()
		{
			if (_packagesByScope == null) return;
			foreach (var (scope, packages) in _packagesByScope)
			{
				foreach (var package in packages)
					package.OnSelectionChanged -= UpdateSelectionDisplay;
			}
		}

		/// <summary>
		/// Populates the package view.
		/// </summary>
		private void PopulatePackageView()
		{
			_packageView.Clear();
			_packageView.SetEnabled(true);
			foreach (var scope in _packagesByScope.Keys)
			{
				var packages = _packagesByScope[scope];
				var entry = new PackageScope(_packageScopeTemplate)
				{
					InstallCallback = LemonIncPackageUtility.InstallPackage,
					DeleteCallback = LemonIncPackageUtility.RemovePackage
				};

				entry.Bind(packages);
				_packageView.Add(entry);

				foreach (var package in packages)
				{
					package.OnSelectionChanged -= UpdateSelectionDisplay;
					package.OnSelectionChanged += UpdateSelectionDisplay;
				}
			}

			UpdateSelectionDisplay();
		}

		private void UpdateSelectionDisplay()
		{
			var selection = _packagesByScope
				.SelectMany(x => x.Value)
				.Where(x => x.Selected)
				.ToArray();
			
			_installBtn.SetEnabled(selection.Any());
			_deleteBtn.SetEnabled(selection.Any() && selection.All(x => x.Installed));
		}
	}
}
