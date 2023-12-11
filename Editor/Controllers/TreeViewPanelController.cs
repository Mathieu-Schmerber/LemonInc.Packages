using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Tools.Databases.Editor.Interfaces;
using LemonInc.Tools.Databases.Editor.Models;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Handles a panel with a tree view.
	/// </summary>
	public class TreeViewPanelController : PanelControllerBase<TreeViewEntry<SectionDefinition>, SectionDefinition>
	{
		public override event Action<SectionDefinition> OnItemCreated;
		public override event Action<SectionDefinition> OnItemDeleted;
		public override event Action<SectionDefinition> OnItemSelected;

		/// <summary>
		/// The parent.
		/// </summary>
		private SectionDefinition _parent;

		/// <summary>
		/// The children.
		/// </summary>
		private List<SectionDefinition> _children;

		/// <summary>
		/// If items can hold children.
		/// </summary>
		private readonly bool _mightHoldChildren;

		/// <summary>
		/// The view entries.
		/// </summary>
		private readonly List<TreeViewEntry<SectionDefinition>> _viewEntries;

		/// <summary>
		/// The tree view.
		/// </summary>
		private readonly TreeView _treeView;

		/// <summary>
		/// The empty information.
		/// </summary>
		private readonly Label _emptyInfo;

		/// <summary>
		/// The selected item.
		/// </summary>
		public override TreeViewEntry<SectionDefinition> SelectedItem => GetSelectedItem();

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeViewPanelController"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="reference">The reference.</param>
		/// <param name="mightHoldChildren">if set to <c>true</c> [might hold children].</param>
		/// <param name="color">The color.</param>
		/// <param name="itemValidation">The item validation.</param>
		public TreeViewPanelController(string title, 
			PanelReference reference, 
			bool mightHoldChildren, 
			Color color, 
			IPanelItem<SectionDefinition>.OnValidate itemValidation) : base(reference)
		{
			_mightHoldChildren = mightHoldChildren;

			_viewEntries = new List<TreeViewEntry<SectionDefinition>>();
			_treeView = new TreeView();
			_treeView.AddToClassList("tree-view");
			_treeView.makeItem = () => new TreeViewEntry<SectionDefinition>(mightHoldChildren, color)
			{
				Validate = itemValidation
			};
			_treeView.bindItem = (element, index) =>
			{
				var entry = element as TreeViewEntry<SectionDefinition>;
				var data = _treeView.GetItemDataForIndex<SectionDefinition>(index);
				
				entry!.Bind(data, AddNewItem);
				entry.OnRenamed += OnItemRenamed;
				_viewEntries.Add(entry);
			};
			_treeView.selectionChanged += OnSelectionChanged;
			_treeView.itemsChosen += OnSelectionChanged;

			_emptyInfo = new Label
			{
				text = "No element to display"
			};
			_emptyInfo.AddToClassList("empty-info");
			_emptyInfo.style.display = DisplayStyle.Flex;
			Reference.PanelVisualElement.Add(_emptyInfo);
			_treeView.style.display = DisplayStyle.None;

			Reference.PanelVisualElement.Add(_treeView);
			Reference.TitleLabel.text = title;
			Reference.AddToolbarButton.clicked += AddNewItem;
		}

		/// <summary>
		/// Called when [item renamed].
		/// </summary>
		/// <param name="item">The item.</param>
		private void OnItemRenamed(SectionDefinition item) 
			=> Refresh();

		/// <summary>
		/// Adds the new item.
		/// </summary>
		/// <param name="parent">The parent.</param>
		private void AddNewItem(SectionDefinition parent)
		{
			var item = new SectionDefinition
			{
				Parent = parent
			};

			if (parent?.Id == _parent?.Id)
			{
				_children?.Add(item);
			}

			GetSelectedItem();
			OnItemCreated?.Invoke(item);
			Refresh();
			_viewEntries.FirstOrDefault(x => x.Data.Id == item.Id)?.StartRename();
		}

		/// <summary>
		/// Adds the new item.
		/// </summary>
		private void AddNewItem() => AddNewItem(_parent);

		/// <inheritdoc />
		protected override void OnDelete(TreeViewEntry<SectionDefinition> selectedItem)
		{
			OnItemDeleted?.Invoke(selectedItem.Data);
			_children?.Remove(selectedItem.Data);
			_viewEntries.Remove(selectedItem);
			Refresh();
			GetSelectedItem();
		}

		/// <inheritdoc />
		public override void SelectItem(string dataId)
		{
			if (!string.IsNullOrEmpty(dataId))
			{
				var id = dataId.GetHashCode();
				_treeView.ClearSelection();
				if (_treeView.GetItemDataForId<SectionDefinition>(id) != null)
				{
					_treeView.AddToSelectionById(dataId.GetHashCode());
				}
			}
		}

		/// <inheritdoc />
		public override void Refresh()
		{
			var children = _parent?.Sections.Values.ToList() ?? _children;
			var roots = children?
				.Select(x =>
				{
					x.Parent = _parent;
					return new TreeViewItemData<SectionDefinition>(x.Id.GetHashCode(), x, GetChildren(x));
				})
				.ToList();

			_emptyInfo.style.display = new StyleEnum<DisplayStyle>( roots?.Any() == true ? DisplayStyle.None : DisplayStyle.Flex);
			_treeView.style.display = new StyleEnum<DisplayStyle>(roots?.Any() == true ? DisplayStyle.Flex : DisplayStyle.None);

			Reference.PanelVisualElement.SetEnabled(roots != null);

			_treeView.Clear();
			_viewEntries.Clear();
			_treeView.SetRootItems(roots);
			_treeView.Rebuild();

			_viewEntries.ForEach(x => x.SetError(!x.Validate.Invoke(x.Data, out var error), error));
		}

		private List<TreeViewItemData<SectionDefinition>> GetChildren(SectionDefinition sectionDefinition)
		{
			if (_mightHoldChildren == false)
				return null;

			var result = new List<TreeViewItemData<SectionDefinition>>();
			foreach (var sectionsValue in sectionDefinition.Sections.Values)
			{
				sectionsValue.Parent = sectionDefinition;
				result.Add(new TreeViewItemData<SectionDefinition>(sectionsValue.Id.GetHashCode(), sectionsValue, GetChildren(sectionsValue)));
			}

			return result;
		}

		/// <summary>
		/// Gets the selected item.
		/// </summary>
		/// <returns>The selected item or null.</returns>
		private TreeViewEntry<SectionDefinition> GetSelectedItem()
		{
			
			var dataObject = _treeView.selectedItem as SectionDefinition;
			var view = _viewEntries.FirstOrDefault(x => x.Data.Id.Equals(dataObject?.Id));
			view?.OnSelected();
			OnItemSelected?.Invoke(dataObject);
			return view;
		}

		/// <summary>
		/// Called when [selection changed].
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnSelectionChanged(IEnumerable<object> obj) => GetSelectedItem();

		/// <summary>
		/// Sets the parent.
		/// </summary>
		/// <param name="parent"></param>
		public void SetParent(SectionDefinition parent) => _parent = parent;

		/// <summary>
		/// Sets the children.
		/// </summary>
		/// <param name="children"></param>
		public void SetChildren(List<SectionDefinition> children) => _children = children;

		/// <inheritdoc />
		public override void Dispose()
		{
			foreach (var treeViewEntry in _viewEntries)
			{
				treeViewEntry.OnRenamed -= OnItemRenamed;
			}
		}
	}
}
