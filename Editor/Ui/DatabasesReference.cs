using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Ui {
	public class DatabasesReference 
	{
		private readonly VisualElement _root;

private VisualElement _BannerVisualElement;
public VisualElement BannerVisualElement => _BannerVisualElement ??= _root.Q<VisualElement>("Banner");
private VisualElement _DatabasesVisualElement;
public VisualElement DatabasesVisualElement => _DatabasesVisualElement ??= _root.Q<VisualElement>("Databases");
private VisualElement _SectionsVisualElement;
public VisualElement SectionsVisualElement => _SectionsVisualElement ??= _root.Q<VisualElement>("Sections");
private VisualElement _AssetsVisualElement;
public VisualElement AssetsVisualElement => _AssetsVisualElement ??= _root.Q<VisualElement>("Assets");

private ToolbarMenu _SelectToolbarMenu;
public ToolbarMenu SelectToolbarMenu => _SelectToolbarMenu ??= _root.Q<ToolbarMenu>("SelectedMenu");

private ToolbarButton _FetchToolbarButton;
public ToolbarButton FetchToolbarButton => _FetchToolbarButton ??= _root.Q<ToolbarButton>("Fetch");

		private Label _Path;
public Label Path => _Path ??= _root.Q<Label>("Path");
		public DatabasesReference(VisualElement root) => _root = root;
	}
}