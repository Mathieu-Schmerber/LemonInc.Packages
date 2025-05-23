using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.WSA;
using static System.Environment;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using Application = UnityEngine.Application;

namespace LemonInc.Tools.Packager.Editor
{
    public static class ProjectSetup {
        [MenuItem("Tools/LemonInc/Setup/Import essentials")]
        public static void ImportEssentials() {        
            Assets.ImportAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem");
            Assets.ImportAsset("Feel.unitypackage", "More Mountains/ScriptingEffects");
            Assets.ImportAsset("FMOD for Unity 202.unitypackage", "FMOD/Editor ExtensionsAudio");
            Assets.ImportAsset("PrimeTween High-Performance Animations and Sequences.unitypackage", "Kyrylo Kuzyk/Editor ExtensionsAnimation");
        }

        [MenuItem("Tools/LemonInc/Setup/Import packages")]
        public static void InstallPackages() {
            Packages.InstallPackages(new[] {
                "com.unity.2d.animation",
                "git+https://github.com/mob-sakai/GitDependencyResolverForUnity.git",
                "com.unity.inputsystem"
            });
        }

        [MenuItem("Tools/LemonInc/Setup/Create Folders")]
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
        
            EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableDomainReload | EnterPlayModeOptions.DisableSceneReload;
        }

        static class Assets {
            public static void ImportAsset(string asset, string folder) {
                string basePath;
                if (OSVersion.Platform is PlatformID.MacOSX or PlatformID.Unix) {
                    string homeDirectory = GetFolderPath(SpecialFolder.Personal);
                    basePath = Combine(homeDirectory, "Library/Unity/Asset Store-5.x");
                } else {
                    string defaultPath = Combine(GetFolderPath(SpecialFolder.ApplicationData), "Unity");
                    basePath = Combine(EditorPrefs.GetString("AssetStoreCacheRootPath", defaultPath), "Asset Store-5.x");
                }

                asset = asset.EndsWith(".unitypackage") ? asset : asset + ".unitypackage";

                string fullPath = Combine(basePath, folder, asset);

                if (!File.Exists(fullPath)) {
                    throw new FileNotFoundException($"The asset package was not found at the path: {fullPath}");
                }

                ImportPackage(fullPath, false);
            }
        }

        static class Packages {
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
        }

        static class Folders {
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