using LemonInc.Core.StateMachine.Scriptables;
using LemonInc.Editor.Utilities.Events;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	/// <summary>
	/// State machine editor window.
	/// </summary>
	/// <seealso cref="UnityEditor.EditorWindow" />
	public class StateMachineEditorWindow : EditorWindow
	{
		[SerializeField] private VisualTreeAsset _visualTreeAsset = default;
		[SerializeField] private StyleSheet _styleSheet = default;

		private StateMachineEditorWindowReference _references;
		private string _assetPath;
		private ScriptableStateMachine _scriptableStateMachine;

		/// <summary>
		/// Shows the specified state machine asset.
		/// </summary>
		/// <param name="stateMachineAsset">The state machine asset.</param>
		public static void Open(ScriptableStateMachine stateMachineAsset)
		{
			var window = GetWindow<StateMachineEditorWindow>();
			
			window.titleContent = new GUIContent("State Machine", EditorGUIUtility.IconContent("d_AnimatorStateMachine Icon").image);
			
			window.Init(stateMachineAsset);
			window.Show();
		}

		/// <summary>
		/// Initializes the window.
		/// </summary>
		/// <param name="stateMachineAsset">The state machine asset.</param>
		private void Init(ScriptableStateMachine stateMachineAsset)
		{
			if (stateMachineAsset == null)
				return;

			_scriptableStateMachine = stateMachineAsset;
			_assetPath = AssetDatabase.GetAssetPath(_scriptableStateMachine);
			_references.GraphViewTitleLabel.text = $"State Machine: {_assetPath}";

			_references.GraphStateMachineGraphView.Initialize(_scriptableStateMachine);
			_references.GraphStateMachineGraphView.Populate();
		}

		/// <summary>
		/// Creates the GUI.
		/// </summary>
		public void CreateGUI()
		{
			_visualTreeAsset.CloneTree(rootVisualElement);
			_references = new StateMachineEditorWindowReference(rootVisualElement);

			if (_styleSheet)
				_references.GraphStateMachineGraphView.AddStyle(_styleSheet);

			_references.GraphStateMachineGraphView.OnNodeSelectedCallback = _references.InspectorInspectorView.Inspect;
			_references.GraphStateMachineGraphView.OnNodeUnSelectedCallback = _ => _references.InspectorInspectorView.ClearInspector();
			_references.GraphStateMachineGraphView.OnEdgeSelectedCallback = _references.InspectorInspectorView.Inspect;
			_references.GraphStateMachineGraphView.OnEdgeUnSelectedCallback = _ => _references.InspectorInspectorView.ClearInspector();
			Init(_scriptableStateMachine);

			EditorEvents.Asset.OnAssetMoved += OnAssetMoved;
			EditorEvents.Asset.OnAssetDeleted += OnAssetDeleted;
		}

		/// <summary>
		/// Called when [asset moved].
		/// </summary>
		/// <param name="oldAssetPath">The oldAssetPath.</param>
		/// <param name="newAssetPath">The newAssetPath.</param>
		private void OnAssetMoved(string oldAssetPath, string newAssetPath)
		{
			if (!_assetPath.Equals(oldAssetPath)) 
				return;

			_assetPath = newAssetPath;
			_references.GraphViewTitleLabel.text = $"State Machine: {_assetPath}";
		}

		/// <summary>
		/// Called when [asset deleted].
		/// </summary>
		/// <param name="assetPath">The asset path.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnAssetDeleted(string assetPath)
		{
			if (!_assetPath.Equals(assetPath)) 
				return;

			_assetPath = string.Empty;
			_scriptableStateMachine = null;
			_references.GraphViewTitleLabel.text = "State Machine: No state machine selected.";
			_references.InspectorInspectorView.ClearInspector();
			_references.GraphStateMachineGraphView.ClearGraph();
		}
	}
}
