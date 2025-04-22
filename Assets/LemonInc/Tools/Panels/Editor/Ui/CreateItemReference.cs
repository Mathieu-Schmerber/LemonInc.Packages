
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
namespace LemonInc.Tools.Panels.Ui {
	public class CreateItemReference 
	{
		private VisualElement _root;

private VisualElement _RootVisualElement;
public VisualElement RootVisualElement => _RootVisualElement ??= _root.Q<VisualElement>("Root");
private VisualElement _BannerVisualElement;
public VisualElement BannerVisualElement => _BannerVisualElement ??= _root.Q<VisualElement>("Banner");
private Label _TitleLabel;
public Label TitleLabel => _TitleLabel ??= _root.Q<Label>("Title");
private DropdownField _SectionDropdownField;
public DropdownField SectionDropdownField => _SectionDropdownField ??= _root.Q<DropdownField>("Section");
private Button _DataTypeButton;
public Button DataTypeButton => _DataTypeButton ??= _root.Q<Button>("DataType");
private TextField _NameTextField;
public TextField NameTextField => _NameTextField ??= _root.Q<TextField>("Name");
private Label _ErrorLabel;
public Label ErrorLabel => _ErrorLabel ??= _root.Q<Label>("Error");
private Button _CreateButton;
public Button CreateButton => _CreateButton ??= _root.Q<Button>("Create");
private Button _CancelButton;
public Button CancelButton => _CancelButton ??= _root.Q<Button>("Cancel");
		public CreateItemReference(VisualElement root) => _root = root;
	}
}