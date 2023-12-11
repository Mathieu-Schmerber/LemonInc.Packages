using System;
using LemonInc.Tools.Databases.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Database data.
	/// </summary>
	public class DatabaseData : ScriptableObject, IIdentifiable
	{
		[ReadOnly] public string _id;
		[ReadOnly] public string _name;

		/// <inheritdoc/>
		public string Id { get => _id; set => _id = value; }

		/// <inheritdoc/>
		public string Name
		{
			get => _name; 
			set => _name = value;
		}

		/// <summary>
		/// The sections definitions.
		/// </summary>
		public SectionDescriptionDictionary SectionDefinitions;

		/// <summary>
		/// The asset definitions.
		/// </summary>
		public AssetDictionary AssetDefinitions;

		/// <summary>
		/// The script path.
		/// </summary>
		public string ScriptPath;

		/// <summary>
		/// On enable.
		/// </summary>
		private void OnEnable()
		{
			if (string.IsNullOrEmpty(Id))
				Id = Guid.NewGuid().ToString();
			if (string.IsNullOrEmpty(Name))
				Name = name;
			SectionDefinitions ??= new SectionDescriptionDictionary();
			AssetDefinitions ??= new AssetDictionary();
		}
	}
}
