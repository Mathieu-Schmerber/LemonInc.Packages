using System;
using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
	/// <summary>
	/// Package entry UI, belongs to the <see cref="PackageScope"/>
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class PackageEntry : VisualElement
	{
		private readonly Toggle _toggle;
		private readonly Label _title;
		private readonly Image _installedIcon;
		private readonly Button _updateBtn;
		private readonly Button _deleteBtn;
		private LemonIncPackage _package;
		private Action<bool> _selectionChangedCallback;

		/// <summary>
		/// Gets or sets the install callback.
		/// </summary>
		/// <value>
		/// The install callback.
		/// </value>
		private Func<LemonIncPackage, Action<bool>, IEnumerator> _installCallback;

		/// <summary>
		/// Gets or sets the delete callback.
		/// </summary>
		/// <value>
		/// The delete callback.
		/// </value>
		private Func<LemonIncPackage, Action<bool>, IEnumerator> _deleteCallback;

		private readonly Texture2D _dlIcon;
		private readonly Texture2D _loadingIcon;

		/// <summary>
		/// Initializes a new instance of the <see cref="PackageEntry"/> class.
		/// </summary>
		/// <param name="uxml">The uxml.</param>
		public PackageEntry()
		{
			_dlIcon = EditorGUIUtility.IconContent("Download-Available").image as Texture2D;
			_loadingIcon = EditorGUIUtility.IconContent("Loading").image as Texture2D;
			
			style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
			style.alignItems = new StyleEnum<Align>(Align.Center);
			style.justifyContent = new StyleEnum<Justify>(Justify.SpaceBetween);
			style.paddingLeft = new StyleLength(10);
			style.paddingRight = new StyleLength(10);

			var btnContainer = new VisualElement
			{
				style =
				{
					flexGrow = 0,
					width = new StyleLength(StyleKeyword.Auto),
					flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
					alignItems = new StyleEnum<Align>(Align.Center),
				}
			};

			_toggle = new Toggle();
			var container = new VisualElement
			{
				style = 
				{
					flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
					flexGrow = 1,
					alignItems = new StyleEnum<Align>(Align.Center),
				}
			};

			_title = new Label
			{
				style =
				{
					marginLeft = new StyleLength(10),
				}
			};

			_installedIcon = new Image
			{
				image = EditorGUIUtility.IconContent("Installed").image,
				style = {
					marginLeft = new StyleLength(5), // spacing from the label
					width = 16,
					height = 16
				}
			};

			container.Add(_installedIcon);
			container.Add(_title);

			_deleteBtn = new Button
			{
				iconImage = EditorGUIUtility.IconContent("P4_DeletedLocal").image as Texture2D,
				style =
				{
					width = 30,
					borderBottomWidth = 0,
					borderLeftWidth = 0,
					borderRightWidth = 0,
					borderTopWidth = 0,
				}
			};
			_updateBtn = new Button
			{
				iconImage = _dlIcon,
				style =
				{
					width = 30,
					borderBottomWidth = 0,
					borderLeftWidth = 0,
					borderRightWidth = 0,
					borderTopWidth = 0,
				}
			};

			btnContainer.Add(_updateBtn);
			btnContainer.Add(_deleteBtn);
			Add(_toggle);
			Add(container);
			Add(btnContainer);
		}

		/// <summary>
		/// Binds the specified package.
		/// </summary>
		/// <param name="package">The package.</param>
		/// <param name="install">The install.</param>
		/// <param name="delete">The delete.</param>
		public void Bind(LemonIncPackage package, Func<LemonIncPackage, 
			Action<bool>, IEnumerator> install, 
			Func<LemonIncPackage, Action<bool>, IEnumerator> delete)
		{
			_package = package;
			_title.text = package.Feature;

			Refresh();

			_installCallback = install;
			_deleteCallback = delete;

			_updateBtn.clicked += OnUpdateClick;
			_deleteBtn.clicked += DeleteBtnOnClick;
			_toggle.RegisterValueChangedCallback((evt) => _package.Selected = evt.newValue);
		}

		private void Refresh()
		{
			if (!_package.Installed)
			{
				_deleteBtn.style.display = DisplayStyle.None;
				_installedIcon.style.display = DisplayStyle.None;
			}
			else
			{
				_deleteBtn.style.display = DisplayStyle.Flex;
				_installedIcon.style.display = DisplayStyle.Flex;
			}
		}
		
		private void DeleteBtnOnClick()
		{
			_deleteBtn.SetEnabled(false);
			EditorCoroutineUtility.StartCoroutine(_deleteCallback(_package, (success) =>
			{
				_deleteBtn.SetEnabled(true);
				Refresh();
			}), this);
		}

		private void OnUpdateClick()
		{
			_updateBtn.SetEnabled(false);
			_updateBtn.iconImage = _loadingIcon;
			EditorCoroutineUtility.StartCoroutine(_installCallback(_package, (success) =>
			{
				_updateBtn.SetEnabled(true);
				_updateBtn.iconImage = _dlIcon;
				Refresh();
			}), this);
		}
	}
}
