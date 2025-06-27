using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
    public class SetupView : VisualElement
    {
        private SetupStep _folderStep;
        private SetupStep _essentialsStep;
        private SetupStep _packagesStep;
        private Button _applyButton;

        public void Initialize(VisualTreeAsset template, VisualTreeAsset stepTemplate)
        {
            template.CloneTree(this);
            
            _folderStep = new SetupStep(stepTemplate);
            _essentialsStep = new SetupStep(stepTemplate);
            _packagesStep = new SetupStep(stepTemplate);
            
            _applyButton = this.Q<Button>("Apply");
            _applyButton.clicked += Apply;
			
            Add(_folderStep);
            Add(_essentialsStep);
            Add(_packagesStep);
			
            _folderStep.Bind("1. Basics", new List<Step>
            {
                new("Create folders", 
                    SetupUtils.CreateFolders,
                    true),
                new("Editor settings",
                    SetupUtils.SetupEditorSettings,
                    true)
            });
			
            _essentialsStep.Bind("2. Essentials", new List<Step>
            {
                new("Odin Inspector", 
                    () => SetupUtils.Assets.ImportAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem"),
                    !SetupUtils.Assets.IsInstalled("Sirenix")),
                new("Prime Tween", 
                    () => SetupUtils.Assets.ImportAsset("PrimeTween High-Performance Animations and Sequences.unitypackage", "Kyrylo Kuzyk/Editor ExtensionsAnimation"),
                    !SetupUtils.Assets.IsInstalled("PrimeTween")),
                new("Feel", 
                    () => SetupUtils.Assets.ImportAsset("Feel.unitypackage", "More Mountains/ScriptingEffects"),
                    !SetupUtils.Assets.IsInstalled("Feel")),
                new("FMOD", 
                    () => SetupUtils.Assets.ImportAsset("FMOD for Unity 202.unitypackage", "FMOD/Editor ExtensionsAudio"),
                    !SetupUtils.Assets.IsInstalled("FMOD")),
            });
            
            _packagesStep.Bind("3. Packages", new List<Step>
            {
                new("Install GitDependencyResolverForUnity",
                    () => SetupUtils.Packages.EnqueuePackageInstall("git+https://github.com/mob-sakai/GitDependencyResolverForUnity.git"),
                    true),
                new("Install com.unity.2d.animation", 
                    () => SetupUtils.Packages.EnqueuePackageInstall("com.unity.2d.animation"),
                    true),
                new("Install com.unity.inputsystem",
                    () => SetupUtils.Packages.EnqueuePackageInstall("com.unity.inputsystem"),
                    true),
                new("Install com.unity.textmeshpro",
                    () => SetupUtils.Packages.EnqueuePackageInstall("com.unity.textmeshpro"),
                    true)
            });
        }

        private void Apply()
        {
            // Basics
            var basics = _folderStep.GetSteps();
            foreach (var step in basics)
                Debug.Log(step.Name);
            foreach (var step in basics)
                step.Action?.Invoke();
            
            // Essentials
            var essentials = _essentialsStep.GetSteps();
            foreach (var step in essentials)
                Debug.Log(step.Name);
            foreach (var step in essentials)
                step.Action?.Invoke();
            
            // Packages (might require restart)
            var packages = _packagesStep.GetSteps();
            foreach (var step in packages)
                Debug.Log(step.Name);
            foreach (var step in packages)
                step.Action?.Invoke();
            SetupUtils.Packages.InstallPackageQueue();
        }
    }
}