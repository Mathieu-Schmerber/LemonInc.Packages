using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Builtins
{
	/// <summary>
	/// Split view.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.TwoPaneSplitView" />
	public class SplitView : TwoPaneSplitView
    {
	    public new class UxmlFactory : UxmlFactory<SplitView, SplitView.UxmlTraits> {}

		/// <summary>
		/// Initializes a new instance of the <see cref="SplitView"/> class.
		/// </summary>
		public SplitView()
        {

        }

		/// <summary>
		/// Adds the style.
		/// </summary>
		/// <param name="styleSheet">The style.</param>
		public void AddStyle(StyleSheet styleSheet)
		{
			if (styleSheet != null)
				styleSheets.Add(styleSheet);
		}
	}
}
