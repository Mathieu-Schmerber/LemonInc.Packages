using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Core.Utilities.Editor;
using LemonInc.Core.Utilities.Editor.SearchWindows;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	public class TitledList<TData, TWidget> : VisualElement
		where TData : ScriptableObject
		where TWidget : VisualElement, IWidget<TData>, new()
	{
		private TWidget _selected;
		private readonly ListView _list;
		private readonly List<TData> _data;
		private readonly GenericSearchWindow _searchWindow;
		private Vector2 _mousePosition;
		
		public Action<TData> OnCreate { get; set; }
		public Action<string> OnRenamed { get; set; }
		public Action<TData> OnDeleted { get; set; }
		public Action OnBind { get; set; }

		public TitledList(List<TData> sourceData, string title, Texture icon)
		{
			_searchWindow = ScriptableObject.CreateInstance<GenericSearchWindow>();
			_searchWindow.Build = BuildSearchWindow;
			_searchWindow.OnEntrySelected = OnSearchWindowEntrySelected;

			_data = sourceData;

			var titleArea = new Toolbar { name = "titleArea" };
			var titleLabel = new Label(title);
			var addAction = new ToolbarButton { name = "addAction" };
			addAction.Add(new Image { image = EditorIcons.Menu.image });

			titleLabel.AddToClassList("title");
			titleArea.Add(new Image { name = $"{title}_icon", image = icon });
			titleArea.Add(titleLabel);
			titleArea.Add(addAction);
			Add(titleArea);

			_list = new ListView(_data)
			{
				selectionType = SelectionType.Single,
				makeItem = () => new TWidget(),
				bindItem = BindActionListItem,
				virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight
			};

			_list.selectionChanged += selections => ChangeSelection(selections.Cast<TData>());

			_list.RegisterCallback<KeyDownEvent>(OnKeyDown, TrickleDown.TrickleDown);
			_list.RegisterCallback<FocusOutEvent>(_ => _list.ClearSelection());
			this.RegisterCallback<MouseMoveEvent>(evt => _mousePosition = evt.mousePosition);

			addAction.clicked += OpenActionSearchWindow;
			_list.AddToClassList("list");
			Add(_list);
		}

		private void BindActionListItem(VisualElement element, int index)
		{
			if (element is not TWidget widget || _data.Count <= index || _data[index] is not TData data)
				return;

			widget.Bind(data, newName =>
			{
				data.name = newName;
				EditorUtility.SetDirty(data);
				AssetDatabase.SaveAssets();
			}, deleted =>
			{
				OnDeleted?.Invoke(deleted);
				_data.Remove(deleted);
				_list.RefreshItems();
			}, toggled =>
			{
				_list.SetSelection(index);
			});
			if (!string.IsNullOrWhiteSpace(data.name))
				return;

			_selected = widget;
			_selected.Select();
			_selected.StartRenaming();
		}

		private void ChangeSelection(IEnumerable<TData> selections)
		{
			_selected?.Unselect();
			if (selections.IsNullOrEmpty())
				return;

			var actions = _data.ToList();
			var index = actions.IndexOf(selections.First());
			var element = _list.GetRootElementForIndex(index);
			if (element is not TWidget widget)
				return;

			_selected = widget;
			widget.Select();
		}

		private void OnKeyDown(KeyDownEvent evt)
		{
			if (_selected == null)
				return;

			switch (evt.keyCode)
			{
				case KeyCode.F2:
					_selected.StartRenaming();
					break;
				case KeyCode.Return:
					if (_selected.IsRenaming)
						_selected.StopRenaming(true);
					break;
				case KeyCode.Delete:
					_selected.Delete();
					break;
			}
		}

		private void OpenActionSearchWindow()
		{
			SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(_mousePosition)), _searchWindow);
		}

		/// <summary>
		/// Called when [search window entry selected].
		/// </summary>
		/// <param name="entry">The entry.</param>
		/// <param name="context">The context.</param>
		private void OnSearchWindowEntrySelected(SearchTreeEntry entry, SearchWindowContext context)
		{
			if (entry.userData is Type actionType)
			{
				var data = ScriptableObject.CreateInstance(actionType) as TData;
				_data.Add(data);
				_list.RefreshItems();
				OnCreate?.Invoke(data);
			}
		}

		/// <summary>
		/// Builds the search window.
		/// </summary>
		/// <returns></returns>
		private List<SearchTreeEntry> BuildSearchWindow()
		{
			var existingTypes = TypeCache.GetTypesDerivedFrom<TData>().Where(x => !x.IsAbstract);
			var entries = new List<SearchTreeEntry>
			{
				new SearchTreeGroupEntry(new GUIContent($"{typeof(TData).Name}")),
			};

			entries.AddRange(existingTypes.Select(x => new SearchTreeEntry(new GUIContent(x.Name))
			{
				level = 1,
				userData = x
			}));

			return entries;
		}
	}
}