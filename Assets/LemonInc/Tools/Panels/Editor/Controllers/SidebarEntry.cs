using System;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using UnityEngine;
using UnityEngine.UIElements;
using EditorIcons = Sirenix.Utilities.Editor.EditorIcons;

namespace LemonInc.Tools.Panels.Controllers
{
	/// <summary>
	/// SidebarController entry, owned by the <see cref="PanelEditorWindow"/>.
	/// </summary>
	public class SidebarEntry : VisualElement
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; private set; }

		/// <summary>
		/// The name.
		/// </summary>
		private readonly Label _name;

		/// <summary>
		/// The icon.
		/// </summary>
		private readonly Image _icon;

		/// <summary>
		/// The root.
		/// </summary>
		private readonly VisualElement _root;

		/// <summary>
		/// Initializes a new instance of the <see cref="SidebarEntry"/> class.
		/// </summary>
		public SidebarEntry()
		{
			_root = new VisualElement()
			{
				style =
				{
					flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
					alignItems = new StyleEnum<Align>(Align.Center),
					height = new StyleLength(22 + 5 + 5),
					borderBottomWidth = new StyleFloat(1),
					borderBottomColor = new StyleColor(new Color(0, 0, 0, 0.2f)),
					borderTopWidth = new StyleFloat(1),
					borderTopColor = new StyleColor(new Color(1, 1, 1, 0.2f))
				}
			};

			_icon = new Image()
			{
				style =
				{
					width = new StyleLength(20)
				}
			};
			_name = new Label()
			{
				enableRichText = true
			};

			_root.Add(_icon);
			_root.Add(_name);

			Add(_root);
		}

		/// <summary>
		/// Binds the specified sidebar element.
		/// </summary>
		/// <param name="sidebarElement">The sidebar element.</param>
		/// <param name="highlight">Optional text part to highlight.</param>
		public void Bind(ISidebarElement sidebarElement, string highlight = "")
		{
			Id = sidebarElement.Id;

			switch (sidebarElement.Type)
			{
				case SidebarElementType.ELEMENT:
					_icon.image = EditorIcons.UnityGameObjectIcon;
					_root.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0f));
					break;
				case SidebarElementType.GROUP:
					_icon.image = EditorIcons.Folder.Inactive;
					_root.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0.2f));
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_name.text = sidebarElement.DisplayName;
			if (!string.IsNullOrEmpty(highlight))
			{
				var start = _name.text.IndexOf(highlight, StringComparison.CurrentCultureIgnoreCase);

				if (start < 0)
					return;

				var highlightPart = _name.text.Substring(start, highlight.Length);
				_name.text = _name.text.Replace(highlightPart, $"<mark>{highlightPart}</mark>");
			}
		}
	}
}