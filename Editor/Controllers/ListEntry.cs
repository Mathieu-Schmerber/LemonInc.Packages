using System;
using LemonInc.Tools.Databases.Interfaces;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Describes a list entry.
	/// </summary>
	public class ListEntry<TData> : PanelItemBase<TData> 
		where TData : class, IIdentifiable
	{
		/// <inheritdoc />
		public override void Bind(TData data, Action<TData> onAddChild)
		{
			base.Bind(data, onAddChild);

			TitleLabel.text = data.Name;
		}

		/// <inheritdoc />
		public override void Dispose()
		{
			
		}
	}
}
