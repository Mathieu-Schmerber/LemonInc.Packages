using System;

namespace LemonInc.Editor.Utilities.Configuration
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ConfigurationAssetAttribute : Attribute
	{
		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		public string Path { get; }

		public ConfigurationAssetAttribute(string path)
		{
			Path = path;
		}
	}
}
