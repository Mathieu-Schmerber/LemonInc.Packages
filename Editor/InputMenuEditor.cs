using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Input.Editor
{
	/// <summary>
	/// Input menu editor.
	/// </summary>
	public class InputMenuEditor
    {
		[MenuItem("Tools/LemonInc/Open Input Asset")]
	    public static void LocateInputAsset()
	    {
		    var obj = AssetDatabase.LoadAssetAtPath($"Packages/com.lemon-inc.input/Scripts/Controls.asset", typeof(Object));
		    Selection.activeObject = obj;
		    EditorGUIUtility.PingObject(obj);
	    }
    }
}
