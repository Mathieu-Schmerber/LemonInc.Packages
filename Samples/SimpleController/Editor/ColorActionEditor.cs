using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine._Samples.SimpleController.Editor
{
	/// <summary>
	/// Color action editor.
	/// </summary>
	/// <seealso cref="UnityEditor.Editor" />
	[CustomEditor(typeof(ColorAction))]
	public class ColorActionEditor : UnityEditor.Editor
	{
		public override VisualElement CreateInspectorGUI()
		{
			return new ColorField
			{
				bindingPath = "_color"
			};
		}
	}
}
