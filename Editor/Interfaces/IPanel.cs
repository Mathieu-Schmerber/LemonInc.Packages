using System;

namespace LemonInc.Tools.Databases.Interfaces
{
	/// <summary>
	/// Describes a panel.
	/// </summary>
	public interface IPanel<TItem, TData> : IDisposable
		where TItem : IPanelItem<TData>
	{
		/// <summary>
		/// Occurs when [on item created].
		/// </summary>
		public event Action<TData> OnItemCreated;

		/// <summary>
		/// Occurs when [on item deleted].
		/// </summary>
		public event Action<TData> OnItemDeleted;

		/// <summary>
		/// Occurs when [on item selected].
		/// </summary>
		public event Action<TData> OnItemSelected;

		/// <summary>
		/// Selects the item.
		/// </summary>
		/// <param name="dataId">The data identifier.</param>
		public void SelectItem(string dataId);

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh();
	}
}