﻿using System;
using System.Linq;
using System.Reflection;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace LemonInc.Tools.Panels.Controllers
{
	/// <summary>
	/// Inspector panel, right side of <see cref="PanelEditorWindow"/>.
	/// </summary>
	public class InspectorPanelController : IDisposable
	{
		private readonly PanelEditorWindow _main;

		/// <summary>
		/// The inspector.
		/// </summary>
		private readonly VisualElement _inspector;

		/// <summary>
		/// The locate asset button.
		/// </summary>
		private readonly ToolbarButton _locateBtn;

		/// <summary>
		/// The bind.
		/// </summary>
		private ISidebarElement _bind;

		/// <summary>
		/// The delete asset button.
		/// </summary>
		private readonly ToolbarButton _deleteBtn;

		/// <summary>
		/// The editor.
		/// </summary>
		private UnityEditor.Editor _editor;

		/// <summary>
		/// Initializes a new instance of the <see cref="InspectorPanelController"/> class.
		/// </summary>
		public InspectorPanelController(VisualElement rootVisualElement, PanelEditorWindow main)
		{
			_main = main;
			_inspector = rootVisualElement.Q<ScrollView>("Inspector");
			_locateBtn = rootVisualElement.Q<ToolbarButton>("LocateAsset");
			_deleteBtn = rootVisualElement.Q<ToolbarButton>("DeleteAsset");

			Bind(null);

			_locateBtn.clicked += LocateAsset;
			_deleteBtn.clicked += DeleteAsset;
			_main.OnElementDeleted += OnElementDeleted;
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		public void Dispose()
		{
			_locateBtn.clicked -= LocateAsset;
			_deleteBtn.clicked -= DeleteAsset;

			// Clean up the editor instance
			if (_editor != null)
			{
				Object.DestroyImmediate(_editor);
				_editor = null;
			}
		}

		/// <summary>
		/// Binds the specified element.
		/// </summary>
		/// <param name="element">The element.</param>
		public void Bind(ISidebarElement element)
		{
			// Clean up the existing editor instance
			if (_editor != null)
			{
				_editor.serializedObject.Dispose();
				Object.DestroyImmediate(_editor);
				_editor = null;
			}

			_bind = element;
			Refresh();
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh()
		{
			_inspector.Clear();

			// Clean up the existing editor instance
			if (_editor != null)
			{
				Object.DestroyImmediate(_editor);
				_editor = null;
			}

			_locateBtn.SetEnabled(_bind?.Type == SidebarElementType.ELEMENT);
			_deleteBtn.SetEnabled(_bind?.Type == SidebarElementType.ELEMENT);
			if (_bind?.Type == SidebarElementType.ELEMENT)
				DisplayElementDetails(_bind.Object);
		}

		/// <summary>
		/// Displays the element details.
		/// </summary>
		/// <param name="elementObject">The element object.</param>
		private void DisplayElementDetails(Object elementObject)
		{
			_editor = UnityEditor.Editor.CreateEditor(elementObject);
			var inspector = new InspectorElement(_editor);

			_inspector.Add(inspector);
			_inspector.Bind(_editor.serializedObject);
		}

		/// <summary>
		/// Deletes the asset.
		/// </summary>
		private void DeleteAsset()
		{
			if (_bind == null)
				return;

			_main.RequestElementDeletion(_bind);
		}

		/// <summary>
		/// Locates the asset.
		/// </summary>
		private void LocateAsset()
		{
			if (_bind == null)
				return;

			EditorGUIUtility.PingObject(_bind.Object);
		}

		/// <summary>
		/// Repaints if needed.
		/// </summary>
		public void RepaintIfNeeded()
		{
			if (_editor?.RequiresConstantRepaint() == true)
			{
				_inspector?.MarkDirtyRepaint();
			}
		}

		private void OnElementDeleted(ISidebarElement element)
		{
			if (_bind != element)
				return;
			
			if (_editor != null)
			{
				Object.DestroyImmediate(_editor);
				_editor = null;
			}

			Bind(null);
		}
	}
}