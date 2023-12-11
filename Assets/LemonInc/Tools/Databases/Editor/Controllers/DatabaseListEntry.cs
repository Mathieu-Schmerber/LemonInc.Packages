using System;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEditor.UIElements;
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
		/// The object field.
		/// </summary>
		private readonly ObjectField _objectField;

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseListEntry"/> class.
		/// </summary>
		public DatabaseListEntry()
		{
			TitleLabel.parent.Insert(0, new ColoredSquare(Color.cyan));

			_objectField = new ObjectField();
			_objectField.AddToClassList("asset-field");
			Add(_objectField);

			AddToClassList("asset-entry");
		}

		/// <inheritdoc />
		public override void Bind(DatabaseData definition, Action<DatabaseData> onAddChild)
		{
			base.Bind(definition, onAddChild);

			_objectField.value = definition;
			_objectField.RegisterValueChangedCallback(evt =>
			{
				if (evt.newValue != null)
				{
					Data = evt.newValue as DatabaseData;
					TitleLabel.text = Data!.Name;
					SetError(!Validate.Invoke(Data, out var errorMessage), errorMessage);
				}
			});
		}
	}
}
