using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor {
	public class StateMachineEditorWindowReference 
	{
		private VisualElement _root;

private VisualElement _LemonIncBannerVisualElement;
public VisualElement LemonIncBannerVisualElement => _LemonIncBannerVisualElement ??= _root.Q<VisualElement>("LemonInc.Banner");
private VisualElement _LeftPanelVisualElement;
public VisualElement LeftPanelVisualElement => _LeftPanelVisualElement ??= _root.Q<VisualElement>("LeftPanel");
private InspectorView _InspectorInspectorView;
public InspectorView InspectorInspectorView => _InspectorInspectorView ??= _root.Q<LemonInc.Core.StateMachine.Editor.InspectorView>("Inspector");
private VisualElement _RightPanelVisualElement;
public VisualElement RightPanelVisualElement => _RightPanelVisualElement ??= _root.Q<VisualElement>("RightPanel");
private Label _GraphViewTitleLabel;
public Label GraphViewTitleLabel => _GraphViewTitleLabel ??= _root.Q<Label>("GraphViewTitle");
private LemonInc.Core.StateMachine.Editor.Graph.StateMachineGraphView _GraphStateMachineGraphView;
public LemonInc.Core.StateMachine.Editor.Graph.StateMachineGraphView GraphStateMachineGraphView => _GraphStateMachineGraphView ??= _root.Q<LemonInc.Core.StateMachine.Editor.Graph.StateMachineGraphView>("Graph");
		public StateMachineEditorWindowReference(VisualElement root) => _root = root;
	}
}