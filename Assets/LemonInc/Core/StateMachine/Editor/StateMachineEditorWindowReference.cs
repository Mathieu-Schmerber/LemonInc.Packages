
using UnityEngine;
using UnityEngine.UIElements;
namespace LemonInc.Core.StateMachine.Editor {
	public class StateMachineEditorWindowReference 
	{
		private VisualElement _root;

private TemplateContainer _LemonIncBannerTemplateContainer;
public TemplateContainer LemonIncBannerTemplateContainer => _LemonIncBannerTemplateContainer ??= _root.Q<TemplateContainer>("LemonInc.Banner");
private VisualElement _LeftPanelVisualElement;
public VisualElement LeftPanelVisualElement => _LeftPanelVisualElement ??= _root.Q<VisualElement>("LeftPanel");
private LemonInc.Core.StateMachine.Editor.InspectorView _InspectorInspectorView;
public LemonInc.Core.StateMachine.Editor.InspectorView InspectorInspectorView => _InspectorInspectorView ??= _root.Q<LemonInc.Core.StateMachine.Editor.InspectorView>("Inspector");
private VisualElement _RightPanelVisualElement;
public VisualElement RightPanelVisualElement => _RightPanelVisualElement ??= _root.Q<VisualElement>("RightPanel");
private Label _GraphViewTitleLabel;
public Label GraphViewTitleLabel => _GraphViewTitleLabel ??= _root.Q<Label>("GraphViewTitle");
private LemonInc.Core.StateMachine.Editor.StateMachineGraphView _GraphStateMachineGraphView;
public LemonInc.Core.StateMachine.Editor.StateMachineGraphView GraphStateMachineGraphView => _GraphStateMachineGraphView ??= _root.Q<LemonInc.Core.StateMachine.Editor.StateMachineGraphView>("Graph");
		public StateMachineEditorWindowReference(VisualElement root) => _root = root;
	}
}