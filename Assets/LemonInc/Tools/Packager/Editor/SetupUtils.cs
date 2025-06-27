using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static System.Environment;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using Application = UnityEngine.Application;

namespace LemonInc.Tools.Packager.Editor
{
    public static class SetupUtils {

        public static void CreateFolders()
        {
            Folders.Create("Externals");
            Folders.Create("Plugins");
            Folders.Create("Game", new []
            {
                "Animations", 
                "Models", 
                "Materials", 
                "Prefabs", 
                "Resources",
                "Textures",
                "Shaders",
                "Models",
                "Sprites",
                "Scripts/Entities", 
                "Scripts/Entities/Shared", 
                "Scripts/Entities/Player", 
                "Scripts/Editor", 
                "Scripts/Systems", 
                "Scripts/Systems/Inputs", 
                "Scripts/Utilities"
            });
            Refresh();
            Folders.Move("Game", "Scenes");
            Folders.Move("Game", "Settings");
            Folders.Delete("TutorialInfo");
            Refresh();

            MoveAsset("Assets/InputSystem_Actions.inputactions", "Assets/Game/Settings/Controls.inputactions");
            DeleteAsset("Assets/Readme.asset");
            Refresh();
        }

        public static void SetupEditorSettings()
        {
            EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableDomainReload | EnterPlayModeOptions.DisableSceneReload;
        }

        public static class Assets {
            public static void ImportAsset(string asset, string folder)
            {
                string basePath;
                if (OSVersion.Platform is PlatformID.MacOSX or PlatformID.Unix)
                {
                    var homeDirectory = GetFolderPath(SpecialFolder.Personal);
                    basePath = Combine(homeDirectory, "Library/Unity/Asset Store-5.x");
                }
                else
                {
                    var defaultPath = Combine(GetFolderPath(SpecialFolder.ApplicationData), "Unity");
                    basePath = Combine(EditorPrefs.GetString("AssetStoreCacheRootPath", defaultPath),
                        "Asset Store-5.x");
                }

                asset = asset.EndsWith(".unitypackage") ? asset : asset + ".unitypackage";

                var fullPath = Combine(basePath, folder, asset);

                if (!File.Exists(fullPath))
                    throw new FileNotFoundException($"The asset package was not found at the path: {fullPath}");

                ImportPackage(fullPath, false);
                Refresh();
            }

            public static bool IsInstalled(string keyword)
            {
                if (string.IsNullOrEmpty(keyword))
                    return false;

                var assetsPath = "Assets";
                string[] foldersToCheck = { "Plugins", "Externals" };

                foreach (var folderName in foldersToCheck)
                {
                    var folderPath = Combine(assetsPath, folderName);
            
                    if (Directory.Exists(folderPath))
                    {
                        var subdirectories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);
                
                        if (subdirectories.Any(dir => GetFileName(dir).IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                            return true;
                
                        if (Directory.GetDirectories(folderPath)
                            .Any(dir => GetFileName(dir).IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                            return true;
                    }
                }

                return false;
            }
        }

        public static class Packages
        {
            private static AddRequest _request;
            private static readonly Queue<string> PackagesToInstall = new();

            public static void InstallPackages(string[] packages)
            {
                foreach (var package in packages)
                {
                    PackagesToInstall.Enqueue(package);
                }

                if (PackagesToInstall.Count > 0)
                {
                    StartNextPackageInstallation();
                }
            }

            public static void InstallPackageQueue()
            {
                if (PackagesToInstall.Count > 0)
                    StartNextPackageInstallation();
            }

            static async void StartNextPackageInstallation()
            {
                _request = Client.Add(PackagesToInstall.Dequeue());

                while (!_request.IsCompleted) await Task.Delay(10);

                if (_request.Status == StatusCode.Success) Debug.Log("Installed: " + _request.Result.packageId);
                else if (_request.Status >= StatusCode.Failure) Debug.LogError(_request.Error.message);

                if (PackagesToInstall.Count > 0)
                {
                    await Task.Delay(1000);
                    StartNextPackageInstallation();
                }
            }

            public static void EnqueuePackageInstall(string package)
            {
                PackagesToInstall.Enqueue(package);
            }

            public static bool IsInstalled(string package)
            {
                try
                {
                    // Path to the manifest.json file in the Unity project
                    var manifestPath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Packages",
                        "manifest.json");

                    if (!File.Exists(manifestPath))
                    {
                        Debug.LogError("manifest.json not found at: " + manifestPath);
                        return false;
                    }

                    var manifestText = File.ReadAllText(manifestPath);
                    var manifestJson = JsonUtility.FromJson<ManifestWrapper>(FixJson(manifestText));

                    return manifestJson.dependencies.ContainsKey(package);
                }
                catch (Exception ex)
                {
                    Debug.LogError("Failed to read manifest.json: " + ex.Message);
                    return false;
                }
            }

            // Helper class to parse dependencies dictionary
            [Serializable]
            private class ManifestWrapper
            {
                public Dictionary<string, string> dependencies = new();
            }

            // Unity's JsonUtility can't parse top-level dictionaries, so we wrap the "dependencies" object
            private static string FixJson(string json)
            {
                var dependenciesIndex = json.IndexOf("\"dependencies\"", StringComparison.Ordinal);
                if (dependenciesIndex == -1) return "{}";

                var braceStart = json.IndexOf('{', dependenciesIndex);
                var braceEnd = json.IndexOf('}', braceStart);
                var dependenciesJson = json.Substring(braceStart, braceEnd - braceStart + 1);

                return $"{{\"dependencies\": {dependenciesJson}}}";
            }
        }

        public static class Folders {
            public static void Create(string root, params string[] folders) {
                var fullpath = Combine(Application.dataPath, root);
                if (!Directory.Exists(fullpath)) {
                    Directory.CreateDirectory(fullpath);
                }

                foreach (var folder in folders) {
                    CreateSubFolders(fullpath, folder);
                }
            }
        
            static void CreateSubFolders(string rootPath, string folderHierarchy) {
                var folders = folderHierarchy.Split('/');
                var currentPath = rootPath;

                foreach (var folder in folders) {
                    currentPath = Combine(currentPath, folder);
                    if (!Directory.Exists(currentPath)) {
                        Directory.CreateDirectory(currentPath);
                    }
                }
            }
        
            public static void Move(string newParent, string folderName) {
                var sourcePath = $"Assets/{folderName}";
                if (IsValidFolder(sourcePath)) {
                    var destinationPath = $"Assets/{newParent}/{folderName}";
                    var error = MoveAsset(sourcePath, destinationPath);

                    if (!string.IsNullOrEmpty(error)) {
                        Debug.LogError($"Failed to move {folderName}: {error}");
                    }
                }
            }
        
            public static void Delete(string folderName) {
                var pathToDelete = $"Assets/{folderName}";

                if (IsValidFolder(pathToDelete)) {
                    DeleteAsset(pathToDelete);
                }
            }
        }
    }
}