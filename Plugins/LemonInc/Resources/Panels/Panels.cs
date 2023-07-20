
				using UnityEditor;
				using UnityEngine;
				namespace LemonInc.Tools.Panels {
			        internal static class PanelMenuItems
			        {
			            
		        [MenuItem("Tools/LemonInc/Panels/TestPanel")]
		        public static void OpenTestPanel()
		        {
		            var window = CreateWindow<PanelEditorWindow>();
		            window.titleContent = new GUIContent("TestPanel");
		            window.Show();
		            window.Focus();
		        }
		        
			        }
			    }