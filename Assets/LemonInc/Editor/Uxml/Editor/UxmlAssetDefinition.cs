using System;
using Sirenix.OdinInspector;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml asset definition
	/// </summary>
	[Serializable]
	public class UxmlAssetDefinition
	{
		/// <summary>
		/// Gets or sets the asset path.
		/// </summary>
		/// <value>
		/// The asset path.
		/// </value>
		public string AssetPath;

		/// <summary>
		/// Gets or sets the code reference class.
		/// </summary>
		/// <value>
		/// The reference class.
		/// </value>
		public string ReferenceClass;

		[Button]
		private void Refresh()
		{
			UxmlReferenceCodeGenerator.GenerateCode(this);
		}
	}
}