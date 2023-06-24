using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Editor.Toolbar
{
	/// <summary>
	/// Toolbar extender.
	/// </summary>
	[InitializeOnLoad]
	public static class ToolbarExtender
	{
		/// <summary>
		/// The tool count.
		/// </summary>
		private static readonly int ToolCount;

		/// <summary>
		/// The command style.
		/// </summary>
		private static GUIStyle _commandStyle;

		/// <summary>
		/// The left toolbar GUI.
		/// </summary>
		public static readonly List<Action> LeftToolbarGui = new();

		/// <summary>
		/// The right toolbar GUI.
		/// </summary>
		public static readonly List<Action> RightToolbarGui = new();

		/// <summary>
		/// Initializes the <see cref="ToolbarExtender"/> class.
		/// </summary>
		static ToolbarExtender()
		{
			var toolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
			const string fieldName = "k_ToolCount";

			var toolIcons = toolbarType.GetField(fieldName,
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

			ToolCount = toolIcons != null ? ((int)toolIcons.GetValue(null)) : 8;

			ToolbarCallback.OnToolbarGui = OnGUI;
			ToolbarCallback.OnToolbarGuiLeft = GuiLeft;
			ToolbarCallback.OnToolbarGuiRight = GuiRight;
		}

		public const float Space = 8;
		public const float ButtonWidth = 32;
		public const float DropdownWidth = 80;
		public const float PlayPauseStopWidth = 140;

		/// <summary>
		/// Called when [GUI].
		/// </summary>
		private static void OnGUI()
		{
			_commandStyle ??= new GUIStyle("CommandLeft");

			var screenWidth = EditorGUIUtility.currentViewWidth;
			float playButtonsPosition = Mathf.RoundToInt((screenWidth - PlayPauseStopWidth) / 2);

			var leftRect = new Rect(0, 0, screenWidth, Screen.height);
			leftRect.xMin += Space; // Spacing left
			leftRect.xMin += ButtonWidth * ToolCount; // Tool buttons
			leftRect.xMin += Space; // Spacing between tools and pivot
			leftRect.xMin += 64 * 2; // Pivot buttons
			leftRect.xMax = playButtonsPosition;

			var rightRect = new Rect(0, 0, screenWidth, Screen.height);
			rightRect.xMin = playButtonsPosition;
			rightRect.xMin += _commandStyle.fixedWidth * 3; // Play buttons
			rightRect.xMax = screenWidth;
			rightRect.xMax -= Space; // Spacing right
			rightRect.xMax -= DropdownWidth; // Layout
			rightRect.xMax -= Space; // Spacing between layout and layers
			rightRect.xMax -= DropdownWidth; // Layers
			rightRect.xMax -= Space; // Spacing between layers and account
			rightRect.xMax -= DropdownWidth; // Account
			rightRect.xMax -= Space; // Spacing between account and cloud
			rightRect.xMax -= ButtonWidth; // Cloud
			rightRect.xMax -= Space; // Spacing between cloud and collab
			rightRect.xMax -= 78; // Colab

			// Add spacing around existing controls
			leftRect.xMin += Space;
			leftRect.xMax -= Space;
			rightRect.xMin += Space;
			rightRect.xMax -= Space;

			// Add top and bottom margins
			leftRect.y = 4;
			leftRect.height = 22;
			rightRect.y = 4;
			rightRect.height = 22;

			if (leftRect.width > 0)
			{
				GUILayout.BeginArea(leftRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in LeftToolbarGui)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}

			if (rightRect.width > 0)
			{
				GUILayout.BeginArea(rightRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in RightToolbarGui)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}

		/// <summary>
		/// GUIs the left.
		/// </summary>
		public static void GuiLeft()
		{
			GUILayout.BeginHorizontal();
			foreach (var handler in LeftToolbarGui)
			{
				handler();
			}
			GUILayout.EndHorizontal();
		}

		/// <summary>
		/// GUIs the right.
		/// </summary>
		public static void GuiRight()
		{
			GUILayout.BeginHorizontal();
			foreach (var handler in RightToolbarGui)
			{
				handler();
			}
			GUILayout.EndHorizontal();
		}
	}
}