using LemonInc.Core.Utilities.Extensions;
using LemonInc.Tools.Databases.Editor.Interfaces;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Controls the database panel.
	/// </summary>
	public class DatabasePanelController : ListPanelController<DatabaseListEntry, DatabaseData>
	{
		/// <summary>
		/// The empty information.
		/// </summary>
		private readonly Label _emptyInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabasePanelController"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="reference">The reference.</param>
		/// <param name="validateItem">The validate item.</param>
		public DatabasePanelController(string title, 
			PanelReference reference, 
			IPanelItem<DatabaseData>.OnValidate validateItem) : base(reference, validateItem)
		{
			reference.TitleLabel.text = title;
		
			_emptyInfo = new Label
			{
				text = "No element to display"
			};
			_emptyInfo.AddToClassList("empty-info");
			_emptyInfo.style.display = DisplayStyle.Flex;

			ListView.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<DatabaseData>()
					? DisplayStyle.None
					: DisplayStyle.Flex);

			Reference.PanelVisualElement.Add(_emptyInfo);
		}

		public override void Refresh()
		{
			base.Refresh();

			_emptyInfo.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<DatabaseData>()
					? DisplayStyle.Flex
					: DisplayStyle.None);

			ListView.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<DatabaseData>()
					? DisplayStyle.None
					: DisplayStyle.Flex);

			Reference.PanelVisualElement.SetEnabled(Source != null);
		}
	}
}