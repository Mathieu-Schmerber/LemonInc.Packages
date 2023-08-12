using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui
{
	public class TypedListView<T> : ListView
		where T : class
	{
		private ObservableCollection<T> _collection;

		public TypedListView(IEnumerable<T> source) : base()
		{
			_collection = new ObservableCollection<T>(source);
			this.itemsSource = _collection;
		} }
}
