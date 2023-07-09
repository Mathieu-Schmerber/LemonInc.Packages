using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Tools.Panels
{
	public class ResourcePanelMenuEditor : OdinMenuEditorWindow
	{
		/// <summary>
		/// Opens the window.
		/// </summary>
		[MenuItem("Tools/LemonInc/Resource Panel")]
		public static void OpenWindow() => GetWindow<ResourcePanelMenuEditor>("Resource Panel").Show();

		/// <summary>
		/// Building the side bar
		/// </summary>
		/// <returns></returns>
		protected override OdinMenuTree BuildMenuTree()
		{
			var tree = new OdinMenuTree
			{
				Config =
				{
					DrawSearchToolbar = true,
					DefaultMenuStyle =
					{
						Height = 18
					}
				}
			};

			tree.AddAllAssetsAtPath("", "Assets/Game/Resources/Data", typeof(ScriptableObject), true);
			return tree;
		}
	}
}