using System.Collections.Generic;
using System.Linq;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Tools.PackageHandler
{
	/// <summary>
	/// Package handler editor window
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class PackageHandlerEditorWindow : EditorWindow
	{
		/// <summary>
		/// The title.
		/// </summary>
		internal const string Title = "LemonInc Package Handler";

		/// <summary>
		/// The banner path.
		/// </summary>
		private const string ResourcePath = "Packages/com.lemon-inc.tools.packagehandler/Editor/Resources/";
		
		private const string LocalPath = "Assets/LemonInc/Tools/PackageHandler/Editor/Resources/";
		private const string BannerPath = ResourcePath + "Banner.png";

		/// <summary>
		/// The packages.
		/// </summary>
		private IEnumerable<LemonIncPackage> _packages;


		[MenuItem("Tools/LemonInc/Package Handler")]
		public static void OpenWindow()
		{
			var window = EditorWindow.GetWindow<PackageHandlerEditorWindow>(Title);

			window.maxSize = new Vector2(400, 300); 
			window.minSize = new Vector2(400, 300);
			window.Show();
		}

		private async void OnEnable()
		{
			var branches = await GithubUtility.ListRepositoryBranches("Mathieu-Schmerber", "LemonInc.Packages");
			var installedPackages = await LemonIncPackageUtility.GetInstalledPackages();
			
			_packages = branches.Where(LemonIncPackageUtility.IsValidPackageName).Select(x => new LemonIncPackage()
			{
				Name = x,
				Installed = installedPackages.Any(y => y.name.Equals(x.ToLemonIncPackageName()))
			});
		}

		/// <summary>
		/// Draws the banner.
		/// </summary>
		private static void DrawBanner()
		{
			var width = EditorGUIUtility.currentViewWidth;
			GUI.DrawTexture(new Rect(0, 0, width, 50 + 20), Styles.GetBackground(new Color(106 / 255f, 146 / 255f, 80 / 255f)));
			var banner = AssetDatabase.LoadAssetAtPath<Texture>(BannerPath);
			GUILayout.Box(banner, Styles.Banner);
		}

		/// <summary>
		/// Draws the package.
		/// </summary>
		/// <param name="package">The package.</param>
		private void DrawPackage(LemonIncPackage package)
		{
			var installContent = new GUIContent("Install", EditorGUIUtility.IconContent("Download-Available@2x").image);
			var updateContent = new GUIContent("Update", EditorGUIUtility.IconContent("d_Refresh@2x").image);
			var removeContent = new GUIContent("Remove", EditorGUIUtility.IconContent("CrossIcon").image);

			GUILayout.BeginHorizontal();
			{
				GUILayout.Label(package.Name);
				if (package.Installed)
				{
					if (GUILayout.Button(updateContent, Styles.Package.Button))
					{
						EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.UpdatePackage(package), this);
					}
					if (GUILayout.Button(removeContent, Styles.Package.Button))
					{
						EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.RemovePackage(package), this);
					}
				}
				else
				{
					if (GUILayout.Button(installContent, Styles.Package.Button))
					{
						EditorCoroutineUtility.StartCoroutine(LemonIncPackageUtility.InstallPackage(package), this);
					}
				}
			}
			GUILayout.EndHorizontal();
		}

		private void OnGUI()
		{
			DrawBanner();

			EditorGUILayout.Space(10);
			GUILayout.Label("LemonInc Packages", Styles.Title);

			if (_packages != null)
			{
				foreach (var package in _packages)
				{
					DrawPackage(package);
				}
			}
			else
			{
				GUILayout.Label("Fetching packages...");
			}
		}
	}
}
