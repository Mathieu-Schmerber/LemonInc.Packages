using System.Collections.Generic;
using System.Linq;
using LemonInc.Tools.Packager.Editor.Extensions;
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
		internal const string Title = "LemonInc Packager";
		
		private ScrollView _packageView;
		private Label _stateLabel;

		/// <summary>
		/// The packages by scope.
		/// </summary>
		private Dictionary<string, List<LemonIncPackage>> _packagesByScope;


		[MenuItem("Tools/LemonInc/Packager", false, 1)]
		public static void OpenWindow()
		{
			var window = EditorWindow.GetWindow<PackagerEditorWindow>(Title);

			window.Show();
		}

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		private void CreateGUI()
		{
			Refresh();
		}

		/// <summary>
		/// Refresh.
		/// </summary>
		private void Refresh()
		{
			_baseUxml.CloneTree(rootVisualElement);
			_stateLabel = rootVisualElement.Q<Label>("State");
			_stateLabel.text = "Fetching packages...";
			_packageView = rootVisualElement.Q<ScrollView>("PackageList");
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
		
		/// <summary>
		/// Populates the package view.
		/// </summary>
		private void PopulatePackageView()
		{
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
			}
		}

		///// <summary>
		///// Draws the banner.
		///// </summary>
		//private static void DrawBanner()
		//{
		//	var width = EditorGUIUtility.currentViewWidth;
		//	GUI.DrawTexture(new Rect(0, 0, width, 50 + 20), Styles.GetBackground(new Color(106 / 255f, 146 / 255f, 80 / 255f)));
		//	var banner = AssetDatabase.LoadAssetAtPath<Texture>(BannerPath);
		//	GUILayout.Box(banner, Styles.Banner);
		//}

		///// <summary>
		///// Draws the package.
		///// </summary>
		///// <param name="package">The package.</param>
		//private void DrawPackage(LemonIncPackage package)
		//{
		//	var installContent = new GUIContent("Install", EditorGUIUtility.IconContent("Download-Available@2x").image);
		//	var updateContent = new GUIContent("Update", EditorGUIUtility.IconContent("d_Refresh@2x").image);
		//	var removeContent = new GUIContent("Remove", EditorGUIUtility.IconContent("CrossIcon").image);

		//	GUILayout.BeginHorizontal();
		//	{
		//		GUILayout.Label(package.BranchName);
		//		if (package.Installed)
		//		{
		//			if (GUILayout.Button(updateContent, Styles.Package.Button))
		//			{
		//				EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.UpdatePackage(package), this);
		//			}
		//			if (GUILayout.Button(removeContent, Styles.Package.Button))
		//			{
		//				EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.RemovePackage(package), this);
		//			}
		//		}
		//		else
		//		{
		//			if (GUILayout.Button(installContent, Styles.Package.Button))
		//			{
		//				EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.InstallPackage(package), this);
		//			}
		//		}
		//	}
		//	GUILayout.EndHorizontal();
		//}

		//private void OnGUI()
		//{
		//	DrawBanner();

		//	EditorGUILayout.Space(10);
		//	GUILayout.Label("LemonInc Packages", Styles.Title);

		//	if (_packages != null)
		//	{
		//		foreach (var package in _packages)
		//		{
		//			DrawPackage(package);
		//		}
		//	}
		//	else
		//	{
		//		GUILayout.Label("Fetching packages...");
		//	}
		//}
	}
}
