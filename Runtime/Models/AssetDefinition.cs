using System;
using LemonInc.Tools.Databases.Interfaces;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Describes an asset.
	/// </summary>
	[Serializable]
	public class AssetDefinition : IIdentifiable
	{
		[SerializeField] private string _id;
		[SerializeField] private string _name;
		[SerializeField] private UnityEngine.Object _data;

		/// <inheritdoc/>
		public string Id { get => _id; set => _id = value; }

		/// <inheritdoc/>
		public string Name { get => _name; set => _name = value; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public Object Data
		{
			get => _data;
			set => _data = value;
		}

		public AssetDefinition()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}
