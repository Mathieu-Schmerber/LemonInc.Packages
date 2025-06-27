using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
    /// <summary>
    /// Package handler editor window
    /// </summary>
    public class PackagerEditorWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset _baseUxml;
        [SerializeField] private VisualTreeAsset _packageScopeTemplate;
        [SerializeField] private VisualTreeAsset _packageViewTemplate;
        [SerializeField] private VisualTreeAsset _setupViewTemplate;

        /// <summary>
        /// The title.
        /// </summary>
        private const string TITLE = "LemonInc Packager";
        
        /// <summary>
        /// The package view.
        /// </summary>
        private PackageView _packageView;
        
        /// <summary>
        /// The tab view.
        /// </summary>
        private TabView _tabView;

        /// <summary>
        /// The setup view.
        /// </summary>
        private SetupView _setupView;

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

            _tabView = rootVisualElement.Q<TabView>();
            
            var packagesTab = new Tab("Packages");
            _tabView.Add(packagesTab);
            
            var setupTab = new Tab("Setup");
            _tabView.Add(setupTab);
            
            _packageView = new PackageView();
            _packageView.Initialize(_packageViewTemplate, _packageScopeTemplate);
            _packageView.OnCoroutineRequest += StartEditorCoroutine;
            _packageView?.LoadPackages();
            packagesTab.Add(_packageView);
            
            _setupView = new SetupView();
            _setupView.Initialize(_setupViewTemplate, _packageScopeTemplate);
            setupTab.Add(_setupView);
        }
        
        /// <summary>
        /// Called when [enable].
        /// </summary>
        private void OnEnable()
        {
            _packageView?.LoadPackages();
        }

        private void OnDisable()
        {
            if (_packageView != null)
            {
                _packageView.OnCoroutineRequest -= StartEditorCoroutine;
                _packageView.Cleanup();
            }
        }
        
        /// <summary>
        /// Starts an editor coroutine on behalf of the package view
        /// </summary>
        private void StartEditorCoroutine(System.Collections.IEnumerator coroutine)
        {
            EditorCoroutineUtility.StartCoroutine(coroutine, this);
        }
    }
}