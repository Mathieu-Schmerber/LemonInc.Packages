using System;
using System.Collections.Generic;
using UnityEngine;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Serialized section.
	/// </summary>
	[Serializable]
	public class SectionDescription
	{
		[SerializeField] private string _id;
		[SerializeField] private string _name;
		[SerializeField] private List<string> _sections;
		[SerializeField] private List<string> _assets;

		public string Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public List<string> Sections { get => _sections; set => _sections = value; }
		public List<string> Assets { get => _assets; set => _assets = value; }
	}
}