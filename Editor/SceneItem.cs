using System.IO;

namespace LemonInc.Tools.SceneSwitcher.Editor
{
	/// <summary>
	/// Describes a scene item.
	/// </summary>
	[System.Serializable]
	public struct SceneItem
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);

		/// <summary>
		/// Gets the display name.
		/// </summary>
		public string DisplayName => $"{Directory.GetParent(Path).Parent.Name}\\{System.IO.Path.GetFileNameWithoutExtension(Path)}";

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="SceneItem"/> is active.
		/// </summary>
		/// <value>
		///   <c>true</c> if active; otherwise, <c>false</c>.
		/// </value>
		public bool Active { get; set; }

		/// <summary>
		/// Gets or sets the index of the build.
		/// </summary>
		public int BuildIndex { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SceneItem"/> struct.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="buildIndex">Index of the build.</param>
		public SceneItem(string path, int buildIndex)
		{
			Path = path;
			BuildIndex = buildIndex;
			Active = false;
		}
	}
}