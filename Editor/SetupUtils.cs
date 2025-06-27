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
        public static void ImportEssentials() {        
            Assets.ImportAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem");
            Assets.ImportAsset("Feel.unitypackage", "More Mountains/ScriptingEffects");
            Assets.ImportAsset("FMOD for Unity 202.unitypackage", "FMOD/Editor ExtensionsAudio");
            Assets.ImportAsset("PrimeTween High-Performance Animations and Sequences.unitypackage", "Kyrylo Kuzyk/Editor ExtensionsAnimation");
        }

        public static void InstallPackages() {
            Packages.InstallPackages(new[] {
                "com.unity.2d.animation",
                "git+https://github.com/mob-sakai/GitDependencyResolverForUnity.git",
                "com.unity.inputsystem"
            });
        }

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
            public static void ImportAsset(string asset, string folder, string moveTo = null)
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

                var assetsBeforeImport = GetAllAssetPaths().ToHashSet();
                ImportPackage(fullPath, false);
                Refresh();

                if (!string.IsNullOrEmpty(moveTo))
                {
                    // Get newly imported assets
                    var assetsAfterImport = GetAllAssetPaths();
                    var newAssets = assetsAfterImport.Where(path => !assetsBeforeImport.Contains(path)).ToList();

                    if (newAssets.Any())
                    {
                        // Ensure the destination folder exists
                        var destinationPath = Combine("Assets", moveTo);
                        if (!Directory.Exists(destinationPath))
                        {
                            Directory.CreateDirectory(destinationPath);
                            Refresh();
                        }

                        // Move each new asset to the destination folder
                        foreach (var assetPath in newAssets)
                        {
                            if (assetPath.StartsWith("Assets/") && !assetPath.StartsWith(destinationPath))
                            {
                                var fileName = GetFileName(assetPath);
                                var newPath = Combine(destinationPath, fileName);

                                // Handle name conflicts by adding a number suffix
                                var counter = 1;
                                var originalNewPath = newPath;
                                while (File.Exists(newPath) || Directory.Exists(newPath))
                                {
                                    var nameWithoutExtension = GetFileNameWithoutExtension(originalNewPath);
                                    var extension = GetExtension(originalNewPath);
                                    newPath = Combine(destinationPath, $"{nameWithoutExtension}_{counter}{extension}");
                                    counter++;
                                }

                                var error = MoveAsset(assetPath, newPath);
                                if (!string.IsNullOrEmpty(error))
                                    Debug.LogError($"Failed to move asset {assetPath} to {newPath}: {error}");
                            }
                        }

                        Refresh();
                    }
                }
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

        public static class Packages {
            private static AddRequest _request;
            private static readonly Queue<string> PackagesToInstall = new();

            public static void InstallPackages(string[] packages) {
                foreach (var package in packages) {
                    PackagesToInstall.Enqueue(package);
                }

                if (PackagesToInstall.Count > 0) {
                    StartNextPackageInstallation();
                }
            }
            
            public static void InstallPackageQueue() {
                if (PackagesToInstall.Count > 0)
                    StartNextPackageInstallation();
            }

            static async void StartNextPackageInstallation() {
                _request = Client.Add(PackagesToInstall.Dequeue());
            
                while (!_request.IsCompleted) await Task.Delay(10);
            
                if (_request.Status == StatusCode.Success) Debug.Log("Installed: " + _request.Result.packageId);
                else if (_request.Status >= StatusCode.Failure) Debug.LogError(_request.Error.message);

                if (PackagesToInstall.Count > 0) {
                    await Task.Delay(1000);
                    StartNextPackageInstallation();
                }
            }

            public static void EnqueuePackageInstall(string package)
            {
                PackagesToInstall.Enqueue(package);
            }

            private static async Task WaitUntil(Func<bool> check, Action then)
            {
                while (!check())
                    await Task.Yield();

                then.Invoke();
            }

            public static async Task<bool> IsInstalledAsync(string package)
            {
                var listRequest = Client.List(true);

                while (!listRequest.IsCompleted)
                {
                    await Task.Delay(10);
                }

                if (listRequest.Status == StatusCode.Success)
                {
                    return listRequest.Result.Any(p => p.name == package);
                }
                    
                Debug.LogError($"Error checking installed packages: {listRequest.Error.message}");
                return false;
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