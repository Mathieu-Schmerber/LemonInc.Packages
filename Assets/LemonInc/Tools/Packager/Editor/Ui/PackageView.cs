using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Tools.Packager.Editor.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
    public class PackageView : VisualElement
    {
        private VisualTreeAsset _packageScopeTemplate;
        
        private ScrollView _packageScrollView;
        private Label _stateLabel;
        private Button _installBtn;
        private Button _deleteBtn;
        
        /// <summary>
        /// The packages by scope.
        /// </summary>
        private Dictionary<string, List<LemonIncPackage>> _packagesByScope;
        
        /// <summary>
        /// Event triggered when the view needs to start a coroutine
        /// </summary>
        public event Action<System.Collections.IEnumerator> OnCoroutineRequest;
        
        /// <summary>
        /// Initializes the PackageView with the required visual tree asset and UI elements
        /// </summary>
        public void Initialize(VisualTreeAsset template, VisualTreeAsset packageScopeTemplate)
        {
            _packageScopeTemplate = packageScopeTemplate;
            
            template.CloneTree(this);
            
            _stateLabel = this.Q<Label>("State");
            _stateLabel.text = "Fetching packages...";
            _packageScrollView = this.Q<ScrollView>("PackageList");
            _installBtn = this.Q<Button>("Install");
            _deleteBtn = this.Q<Button>("Delete");
            
            _installBtn.SetEnabled(false);
            _deleteBtn.SetEnabled(false);

            _installBtn.clicked += BatchInstall;
            _deleteBtn.clicked += BatchDelete;
        }
        
        /// <summary>
        /// Loads and displays packages asynchronously
        /// </summary>
        public async void LoadPackages()
        {
            try
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
                
                // Hide state label and populate the view
                _stateLabel?.RemoveFromHierarchy();
                PopulatePackageView();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to load packages: {ex.Message}");
                if (_stateLabel != null)
                    _stateLabel.text = "Failed to load packages";
            }
        }
        
        /// <summary>
        /// Cleans up event subscriptions
        /// </summary>
        public void Cleanup()
        {
            if (_packagesByScope == null) return;
            
            foreach (var (scope, packages) in _packagesByScope)
            {
                foreach (var package in packages)
                    package.OnSelectionChanged -= UpdateSelectionDisplay;
            }
        }
        
        private void BatchInstall()
        {
            var selection = GetSelectedPackages();
            if (!selection.Any()) return;

            ClearSelections(selection);
            _packageScrollView.SetEnabled(false);
            
            var coroutine = LemonIncPackageUtility.BatchInstall(selection, success =>
            {
                for (int i = 0; i < success.Count; i++)
                {
                    var package = selection[i];
                    if (success[i])
                        package.Installed = true;
                }
                
                PopulatePackageView();
            });
            
            OnCoroutineRequest?.Invoke(coroutine);
        }

        private void BatchDelete()
        {
            var selection = GetSelectedPackages();
            if (!selection.Any()) return;

            ClearSelections(selection);
            _packageScrollView.SetEnabled(false);
            
            var coroutine = LemonIncPackageUtility.BatchRemove(selection, success =>
            {
                for (int i = 0; i < success.Count; i++)
                {
                    var package = selection[i];
                    if (success[i])
                        package.Installed = false;
                }
                
                PopulatePackageView();
            });
            
            OnCoroutineRequest?.Invoke(coroutine);
        }
        
        private LemonIncPackage[] GetSelectedPackages()
        {
            return _packagesByScope?
                .SelectMany(x => x.Value)
                .Where(x => x.Selected)
                .ToArray() ?? new LemonIncPackage[0];
        }
        
        private void ClearSelections(LemonIncPackage[] packages)
        {
            foreach (var package in packages)
            {
                package.OnSelectionChanged -= UpdateSelectionDisplay;
                package.Selected = false;
            }
        }
        
        /// <summary>
        /// Populates the package view with scoped packages
        /// </summary>
        private void PopulatePackageView()
        {
            _packageScrollView.Clear();
            _packageScrollView.SetEnabled(true);
            
            if (_packagesByScope == null) return;
            
            foreach (var scope in _packagesByScope.Keys)
            {
                var packages = _packagesByScope[scope];
                var entry = new PackageScope(_packageScopeTemplate)
                {
                    InstallCallback = LemonIncPackageUtility.InstallPackage,
                    DeleteCallback = LemonIncPackageUtility.RemovePackage
                };

                entry.Bind(packages);
                _packageScrollView.Add(entry);

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
            var selection = GetSelectedPackages();
            
            _installBtn.SetEnabled(selection.Any());
            _deleteBtn.SetEnabled(selection.Any() && selection.All(x => x.Installed));
        }
    }
}