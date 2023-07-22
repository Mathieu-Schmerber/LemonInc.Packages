using Assets.Testing.Script;
using LemonInc.Editor.Utilities;
using UnityEditor;

[CustomEditor(typeof(RotatingCube))]
public class RotatingCubeEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorMessageBox.Success("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
		EditorMessageBox.Success("This is a success !!!");

		EditorMessageBox.Error("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
		EditorMessageBox.Error("This is a success !!!");
	}
}
