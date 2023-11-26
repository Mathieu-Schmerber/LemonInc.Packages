
				using UnityEditor;
				using UnityEngine;
				namespace LemonInc.Generated {
			        internal static class PanelMenuItems
			        {
			            
		        [MenuItem("Tools/LemonInc/Panels/TestPanel")]
		        public static void OpenTestPanel()
		        {
		            var window = UnityEditor.EditorWindow.CreateWindow<LemonInc.Tools.Panels.PanelEditorWindow>();
		            window.titleContent = new GUIContent("TestPanel");
					window.Init("TestPanel");
		            window.Show();
		            window.Focus();
		        }
		        
			        }
			    }