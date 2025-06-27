using System.Collections.Generic;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
    public class SetupView : VisualElement
    {
        private SetupStep _folderStep;
        private SetupStep _essentialsStep;
        private SetupStep _packagesStep;

        public void Initialize(VisualTreeAsset template, VisualTreeAsset stepTemplate)
        {
            template.CloneTree(this);
			
            _folderStep = new SetupStep(stepTemplate);
            _essentialsStep = new SetupStep(stepTemplate);
            _packagesStep = new SetupStep(stepTemplate);
			
            Add(_folderStep);
            Add(_essentialsStep);
            Add(_packagesStep);
			
            _folderStep.Bind("1. Basics", new List<Step>()
            {
                new("Create folders", 
                    SetupUtils.CreateFolders,
                    () => true,
                    true),
                new("Editor settings",
                    SetupUtils.SetupEditorSettings,
                    () => true,
                    true)
            });
			
            _essentialsStep.Bind("2. Essentials", new List<Step>()
            {
                new("Odin Inspector", 
                    () => SetupUtils.Assets.ImportAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem"),
                    () => !SetupUtils.Assets.IsInstalled("Sirenix"),
                    true),
                new("Prime Tween", 
                    () => SetupUtils.Assets.ImportAsset("PrimeTween High-Performance Animations and Sequences.unitypackage", "Kyrylo Kuzyk/Editor ExtensionsAnimation"),
                    () => !SetupUtils.Assets.IsInstalled("PrimeTween"),
                    true),
                new("Feel", 
                    () => SetupUtils.Assets.ImportAsset("Feel.unitypackage", "More Mountains/ScriptingEffects"),
                    () => !SetupUtils.Assets.IsInstalled("Feel"),
                    true),
                new("FMOD", 
                    () => SetupUtils.Assets.ImportAsset("FMOD for Unity 202.unitypackage", "FMOD/Editor ExtensionsAudio"),
                    () => !SetupUtils.Assets.IsInstalled("FMOD"),
                    true),
            });
			
            _packagesStep.Bind("3. Packages", new List<Step>()
            {
                new("Install com.unity.2d.animation", 
                    () => SetupUtils.Packages.EnqueuePackageInstall("com.unity.2d.animation"),
                    () => SetupUtils.Packages.IsInstalled("com.unity.2d.animation"),
                    true),
                new("Install com.unity.inputsystem",
                    () => SetupUtils.Packages.EnqueuePackageInstall("com.unity.inputsystem"),
                    () => SetupUtils.Packages.IsInstalled("com.unity.inputsystem"),
                    true),
                new("Install GitDependencyResolverForUnity",
                    () => SetupUtils.Packages.EnqueuePackageInstall("git+https://github.com/mob-sakai/GitDependencyResolverForUnity.git"),
                    () => SetupUtils.Packages.IsInstalled("git+https://github.com/mob-sakai/GitDependencyResolverForUnity.git"),
                    true)
            });
        }
    }
}