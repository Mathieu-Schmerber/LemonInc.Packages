using System;
using System.Collections.Generic;
using LemonInc.Tools.Databases.Interfaces;
using UnityEngine;

namespace LemonInc.Tools.Databases.Models
{
	[Serializable]
	public class SectionDefinition : IIdentifiable
	{
		[SerializeField] private string _id;
		[SerializeField] private string _name;
		[SerializeField] private SectionDictionary _sections;
		[SerializeField] private List<AssetDefinition> _assets;

		public string Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public SectionDefinition Parent { get; set; }
		public SectionDictionary Sections { get => _sections; set => _sections = value; }
		public List<AssetDefinition> Assets { get => _assets; set => _assets = value; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SectionDefinition"/> class.
		/// </summary>
		public SectionDefinition()
		{
			Id = Guid.NewGuid().ToString();
			Sections = new SectionDictionary();
			Assets = new List<AssetDefinition>();
		}
	}
}
