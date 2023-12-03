using System;
using System.Collections.Generic;
using System.Linq;
using LemonInc.Tools.Databases.Interfaces;
using LemonInc.Tools.Databases.Ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Controllers
{
	/// <summary>
	/// Controls a panel containing a list.
	/// </summary>
	public class ListPanelController<TEntry, TData> : PanelControllerBase<TEntry, TData>
		where TEntry : ListEntry<TData>, new()
		where TData : class, IIdentifiable, new()
	{
		public override event Action<TData> OnItemCreated;
		public override event Action<TData> OnItemDeleted;
		public override event Action<TData> OnItemSelected;
		public override event Action<TData> OnItemDeSelected;

		/// <summary>
		/// The selected item.
		/// </summary>
		public override TEntry SelectedItem => GetSelectedItem();

		/// <summary>
		/// The entry views.
		/// </summary>
		protected List<TEntry> _entryViews;

		/// <summary>
		/// The source.
		/// </summary>
		public List<TData> Source { get; protected set; }

		/// <summary>
		/// The ListView.
		/// </summary>
		protected ListView ListView;

		/// <summary>
		/// Initializes a new instance of the <see cref="ListPanelController{TEntry, TData}"/> class.
		/// </summary>
		/// <param name="reference">The reference.</param>
		/// <param name="validateItem">The validate item.</param>
		public ListPanelController(PanelReference reference, 
			IPanelItem<TData>.OnValidate validateItem
			) : base(reference)
		{
			_entryViews = new List<TEntry>();

			ListView = new ListView
			{
				makeItem = () => new TEntry()
				{
					Validate = validateItem
				},
				bindItem = (element, index) =>
				{
					if (element is not TEntry entry) 
						return;
					_entryViews.Add(entry);
					entry.Bind(Source?.Count > index ? Source[index] : null, null);
					entry.OnRenamed += OnItemRenamed;
				},
				style =
				{
					flexGrow = 1
				},
			};
			ListView.RegisterCallback<KeyDownEvent>(evt =>
			{
				if (evt.keyCode == KeyCode.Delete && ListView.selectedItem != null)
				{
					OnItemRemoved(new List<int> { ListView.selectedIndex });
				}
			});
			ListView.itemsAdded += OnItemsAdded;
			ListView.itemsRemoved += OnItemRemoved;
			reference.AddToolbarButton.clicked += OnItemAdded;
			reference.PanelVisualElement.Add(ListView);
		}

		/// <summary>
		/// Triggers whenever an item is renamed.
		/// </summary>
		/// <param name="item"></param>
		private void OnItemRenamed(TData item)
			// Re triggers the validation
			=> Refresh();

		/// <summary>
		/// Gets the selected item.
		/// </summary>
		/// <returns></returns>
		private TEntry GetSelectedItem()
		{
			if (ListView.selectedItem is not TData selected || _entryViews.Count == 0)
				return null;
			return _entryViews.FirstOrDefault(x => x?.Data?.Id?.Equals(selected.Id) == true);
		}

		/// <summary>
		/// Called when [item added].
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		protected void OnItemAdded()
		{
			var item = new TData();

			OnItemCreated?.Invoke(item);
			Refresh();
		}

		/// <summary>
		/// Called when [item added].
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		protected void OnItemAdded(TData data)
		{
			OnItemCreated?.Invoke(data);
			Refresh();
		}

		/// <summary>
		/// Called when [item removed].
		/// </summary>
		/// <param name="indexes">The indexes.</param>
		private void OnItemRemoved(IEnumerable<int> indexes)
		{
			foreach (var index in indexes)
			{
				OnItemDeleted?.Invoke(Source[index]);
			}

			Refresh();
		}

		/// <summary>
		/// Called when [items added].
		/// </summary>
		private void OnItemsAdded(IEnumerable<int> indexes)
		{
			foreach (var index in indexes)
			{
				OnItemCreated?.Invoke(Source[index]);
			}

			Refresh();
		}

		/// <summary>
		/// Sets the source.
		/// </summary>
		/// <param name="sectionAssets">The section assets.</param>
		public void SetSource(List<TData> sectionAssets) => Source = sectionAssets;

		/// <inheritdoc/>
		protected override void OnDelete(TEntry selectedItem)
		{
		}

		/// <inheritdoc/>
		public override void SelectItem(string dataId)
		{
			if (!string.IsNullOrEmpty(dataId))
				ListView.AddToSelection(Source.FindIndex(x => x.Id.Equals(dataId)));
		}

		/// <inheritdoc/>
		public override void Refresh()
		{
			_entryViews.Clear();
			ListView.itemsSource = Source;
			ListView.Rebuild();
		}

		/// <inheritdoc/>
		public override void Dispose()
		{
			ListView.itemsAdded -= OnItemsAdded;
			ListView.itemsRemoved -= OnItemRemoved;
			foreach (var entryView in _entryViews)
			{
				entryView.OnRenamed -= OnItemRenamed;
			}
		}
	}
}
