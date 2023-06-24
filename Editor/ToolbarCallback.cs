using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Toolbar
{
	/// <summary>
	/// Provides callbacks for the toolbar GUI events.
	/// </summary>
	public static class ToolbarCallback
	{
		/// <summary>
		/// Constants.
		/// </summary>
		private static class Constants
		{
			public const string RootFieldName = "m_Root";
			public const string ToolbarZoneLeftAlign = "ToolbarZoneLeftAlign";
			public const string ToolbarZoneRightAlign = "ToolbarZoneRightAlign";
		}

		/// <summary>
		/// The toolbar type.
		/// </summary>
		private static readonly Type ToolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");

		/// <summary>
		/// The current toolbar.
		/// </summary>
		private static ScriptableObject _currentToolbar;

		/// <summary>
		/// Callback for the toolbar GUI.
		/// </summary>
		public static Action OnToolbarGui;

		/// <summary>
		/// Callback for the left-aligned toolbar GUI.
		/// </summary>
		public static Action OnToolbarGuiLeft;

		/// <summary>
		/// Callback for the right-aligned toolbar GUI.
		/// </summary>
		public static Action OnToolbarGuiRight;

		static ToolbarCallback()
		{
			EditorApplication.update -= OnUpdate;
			EditorApplication.update += OnUpdate;
		}

		/// <summary>
		/// Called when [update].
		/// </summary>
		private static void OnUpdate()
		{
			if (_currentToolbar == null)
			{
				var toolbar = Resources.FindObjectsOfTypeAll(ToolbarType);
				_currentToolbar = toolbar.Length > 0 ? (ScriptableObject)toolbar[0] : null;

				if (_currentToolbar != null)
				{
					var root = _currentToolbar.GetType().GetField(Constants.RootFieldName, BindingFlags.NonPublic | BindingFlags.Instance);
					var rawRoot = root.GetValue(_currentToolbar);
					var mRoot = rawRoot as VisualElement;
					RegisterCallback(Constants.ToolbarZoneLeftAlign, OnToolbarGuiLeft);
					RegisterCallback(Constants.ToolbarZoneRightAlign, OnToolbarGuiRight);

					void RegisterCallback(string localRoot, Action cb)
					{
						var toolbarZone = mRoot.Q(localRoot);

						var parent = new VisualElement
						{
							style = {
								flexGrow = 1,
								flexDirection = FlexDirection.Row,
							}
						};
						var container = new IMGUIContainer();
						container.style.flexGrow = 1;
						container.onGUIHandler += () => {
							cb?.Invoke();
						};
						parent.Add(container);
						toolbarZone.Add(parent);
					}
				}
			}
		}

		/// <summary>
		/// Called when [GUI].
		/// </summary>
		private static void OnGUI()
		{
			var handler = OnToolbarGui;

			handler?.Invoke();
		}
	}
}