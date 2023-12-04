using System;
using System.Collections.Generic;
using LemonInc.Tools.Databases.Interfaces;

namespace LemonInc.Tools.Databases.Models
{
	/// <summary>
	/// Complete definition of section.
	/// </summary>
	/// <seealso cref="LemonInc.Tools.Databases.Interfaces.IIdentifiable" />
	public class SectionDefinition : IIdentifiable
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the parent.
		/// </summary>
		/// <value>
		/// The parent.
		/// </value>
		public SectionDefinition Parent { get; set; }

		/// <summary>
		/// Gets or sets the sections.
		/// </summary>
		/// <value>
		/// The sections.
		/// </value>
		public SectionDictionary Sections { get; set; }

		/// <summary>
		/// Gets or sets the assets.
		/// </summary>
		/// <value>
		/// The assets.
		/// </value>
		public List<AssetDefinition> Assets { get; set; }

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
