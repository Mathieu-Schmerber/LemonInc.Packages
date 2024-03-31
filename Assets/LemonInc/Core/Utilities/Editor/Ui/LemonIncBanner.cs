using UnityEditor;
using UnityEngine.UIElements;

namespace LemonInc.Core.Utilities.Editor.Ui
{
	/// <summary>
	/// LemonIncBanner, programmatically add the banner UI.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.VisualElement" />
	public class LemonIncBanner : VisualElement
    {
	    /// <summary>
		/// The resource path.
		/// </summary>
		private const string RESOURCE_PATH = "Packages/com.lemon-inc.core.utilities/Editor/Ui/LemonInc.Banner.uxml";

		/// <summary>
		/// Initializes a new instance of the <see cref="LemonIncBanner"/> class.
		/// </summary>
		public LemonIncBanner()
	    {
			var bannerUxml = EditorGUIUtility.LoadRequired(RESOURCE_PATH) as VisualTreeAsset;

			bannerUxml!.CloneTree(this);
	    }
    }
}
