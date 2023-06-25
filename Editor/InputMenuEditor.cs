using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Input.Editor
{
	/// <summary>
	/// Input menu editor.
	/// </summary>
	public class InputMenuEditor
    {
		/// <summary>
		/// Locates the input asset.
		/// </summary>
		[MenuItem("Tools/LemonInc/Open Input Asset")]
	    public static void LocateInputAsset()
	    {
		    var obj = AssetDatabase.LoadAssetAtPath($"Packages/com.lemon-inc.core.input/Scripts/Controls.inputactions", typeof(Object));
		    Selection.activeObject = obj;
		    EditorGUIUtility.PingObject(obj);
	    }
    }
}
