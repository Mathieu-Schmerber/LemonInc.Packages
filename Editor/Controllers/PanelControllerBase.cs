using System;
using LemonInc.Tools.Databases.Editor.Interfaces;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Controls a panel.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	/// <typeparam name="TData">The type of the data.</typeparam>
	/// <seealso cref="IPanel{TItem,TData}" />
	public abstract class PanelControllerBase<TItem, TData> : IPanel<TItem, TData>
		where TItem : IPanelItem<TData>
		where TData : class, IIdentifiable
	{
		/// <inheritdoc/>
		public abstract event Action<TData> OnItemCreated;

		/// <inheritdoc/>
		public abstract event Action<TData> OnItemDeleted;

		/// <inheritdoc/>
		public abstract event Action<TData> OnItemSelected;

		/// <summary>
		/// The selected item.
		/// </summary>
		public abstract TItem SelectedItem { get; }

		/// <summary>
		/// The reference.
		/// </summary>
		protected readonly PanelReference Reference;

		/// <summary>
		/// Initializes a new instance of the <see cref="PanelControllerBase{TItem, TData}"/> class.
		/// </summary>
		/// <param name="reference">The reference.</param>
		protected PanelControllerBase(PanelReference reference)
		{
			Reference = reference;

			Reference.PanelVisualElement.RegisterCallback<KeyDownEvent>(OnKeyDown);
		}

		/// <summary>
		/// Called when [key down].
		/// </summary>
		/// <param name="evt">The evt.</param>
		private void OnKeyDown(KeyDownEvent evt)
		{
			if (SelectedItem == null)
				return;

			if (evt.keyCode == KeyCode.F2)
			{
				SelectedItem.StartRename();
			}
			else if (evt.keyCode == KeyCode.Delete)
			{
				OnDelete(SelectedItem);
			}
		}

		/// <summary>
		/// Called when [delete].
		/// </summary>
		/// <param name="selectedItem">The selected item.</param>
		/// <returns></returns>
		protected abstract void OnDelete(TItem selectedItem);

		/// <inheritdoc/>
		public abstract void SelectItem(string dataId);

		/// <inheritdoc/>
		public abstract void Refresh();

		/// <inheritdoc/>
		public abstract void Dispose();
	}
}
