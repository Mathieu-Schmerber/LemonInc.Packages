using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Ui {
	public class PanelReference 
	{
		private readonly VisualElement _root;

private VisualElement _PanelVisualElement;
public VisualElement PanelVisualElement => _PanelVisualElement ??= _root.Q<VisualElement>("Panel");
private Label _TitleLabel;
public Label TitleLabel => _TitleLabel ??= _root.Q<Label>("Title");
private ToolbarButton _AddToolbarButton;
public ToolbarButton AddToolbarButton => _AddToolbarButton ??= _root.Q<ToolbarButton>("Add");

		public PanelReference(VisualElement root) => _root = root;
	}
}