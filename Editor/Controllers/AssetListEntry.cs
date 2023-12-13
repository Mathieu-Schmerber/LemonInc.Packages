using System;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Describes a list entry containing an assset.
	/// </summary>
	public class AssetListEntry : ListEntry<AssetDefinition>
	{
		/// <summary>
		/// The object field.
		/// </summary>
		private readonly ObjectField _objectField;

		/// <summary>
		/// Initializes a new instance of the <see cref="AssetListEntry"/> class.
		/// </summary>
		public AssetListEntry()
		{
			TitleLabel.parent.Insert(0, new ColoredSquare(Color.magenta));

			_objectField = new ObjectField();
			_objectField.AddToClassList("asset-field");
			Add(_objectField);

			AddToClassList("asset-entry");
		}

		/// <inheritdoc />
		public override void Bind(AssetDefinition definition, Action<AssetDefinition> onAddChild)
		{
			base.Bind(definition, onAddChild);

			_objectField.value = definition.Data;
			_objectField.RegisterValueChangedCallback(evt =>
			{
				if (evt.newValue != null)
				{
					var nameChanged = evt.previousValue?.name != evt.newValue?.name;
					Data.Name = !nameChanged ? evt.newValue.name : Data.Name;
					Data.Data = evt.newValue;
					TitleLabel.text = Data.Name;
					SetError(!Validate.Invoke(Data, out var errorMessage), errorMessage);
				}
			});
		}
	}
}
