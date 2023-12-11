using LemonInc.Editor.Utilities;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Describes a list entry containing a database.
	/// </summary>
	public class DatabaseListEntry : ListEntry<DatabaseData>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseListEntry"/> class.
		/// </summary>
		public DatabaseListEntry()
		{
			TitleLabel.parent.Insert(0, new ColoredSquare(Color.cyan));
			AddToClassList("asset-entry");

			var locateBtn = new Button();
			locateBtn.AddToClassList("entry-btn");
			locateBtn.Add(new Image
			{
				image = EditorIcons.DAnimationvisibilitytoggleon.image,
				style =
				{
					width = new StyleLength(18)
				}
			});
			Add(locateBtn);
			locateBtn.clicked += LocateBtn_clicked;
		}

		private void LocateBtn_clicked()
		{
			Selection.SetActiveObjectWithContext(Data, Data);
			EditorGUIUtility.PingObject(Data);
		}

		/// <summary>
		/// Called when [item renamed].
		/// </summary>
		protected override void OnItemRenamed()
		{
			var path = Data.GetPath();
			AssetDatabase.RenameAsset(path, Data.Name);
			Data.name = Data.Name;
		}
	}
}
