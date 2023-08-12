using LemonInc.Core.StateMachine.Scriptables;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
    [CustomEditor(typeof(ScriptableStateMachine))]
    public class ScriptableStateMachineEditor : UnityEditor.Editor
    {
		public override VisualElement CreateInspectorGUI()
		{
			var data = target as ScriptableStateMachine;
			var root = new VisualElement();
			var btn = new Button(() => ShowInEditor(data))
			{
				text = "Open"
			};

			root.Add(btn);
			return root;
		}

		[OnOpenAsset]
		public static bool OpenAsset(int instanceId, int line)
		{
			var stateMachine = EditorUtility.InstanceIDToObject(instanceId) as ScriptableStateMachine;
			if (stateMachine == null) 
				return false;

			ShowInEditor(stateMachine);
			return true;
		}

		private static void ShowInEditor(ScriptableStateMachine asset)
	    {
		    StateMachineEditorWindow.Open(asset);
	    }
    }
}
