using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Ui {
	public class DatabasesReference 
	{
		private readonly VisualElement _root;

private VisualElement _BannerVisualElement;
public VisualElement BannerVisualElement => _BannerVisualElement ??= _root.Q<VisualElement>("Banner");
private ToolbarButton _CompileToolbarButton;
public ToolbarButton CompileToolbarButton => _CompileToolbarButton ??= _root.Q<ToolbarButton>("Compile");
private VisualElement _DatabasesVisualElement;
public VisualElement DatabasesVisualElement => _DatabasesVisualElement ??= _root.Q<VisualElement>("Databases");
private VisualElement _SectionsVisualElement;
public VisualElement SectionsVisualElement => _SectionsVisualElement ??= _root.Q<VisualElement>("Sections");
private VisualElement _AssetsVisualElement;
public VisualElement AssetsVisualElement => _AssetsVisualElement ??= _root.Q<VisualElement>("Assets");

private ToolbarButton _FolderToolbarButton;
public ToolbarButton FolderToolbarButton => _FolderToolbarButton ??= _root.Q<ToolbarButton>("Folder");
private Label _Path;
public Label Path => _Path ??= _root.Q<Label>("Path");
		public DatabasesReference(VisualElement root) => _root = root;
	}
}