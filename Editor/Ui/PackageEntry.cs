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
		private Label _title;
		private Button _updateBtn;
		private Button _deleteBtn;
		private LemonIncPackage _package;

		/// <summary>
		/// Gets or sets the install callback.
		/// </summary>
		/// <value>
		/// The install callback.
		/// </value>
		private Func<LemonIncPackage, Action<bool>, IEnumerator> _installCallback { get; set; }

		/// <summary>
		/// Gets or sets the delete callback.
		/// </summary>
		/// <value>
		/// The delete callback.
		/// </value>
		private Func<LemonIncPackage, Action<bool>, IEnumerator> _deleteCallback { get; set; }
		
		/// <summary>
		/// The install text.
		/// </summary>
		private const string INSTALL_TEXT = "Install";

		/// <summary>
		/// The update text.
		/// </summary>
		private const string UPDATE_TEXT = "Update";

		/// <summary>
		/// The update text.
		/// </summary>
		private const string LOADING_TEXT = "Importing...";

		/// <summary>
		/// Initializes a new instance of the <see cref="PackageEntry"/> class.
		/// </summary>
		/// <param name="uxml">The uxml.</param>
		public PackageEntry()
		{
			this.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
			this.style.alignItems = new StyleEnum<Align>(Align.Center);
			this.style.justifyContent = new StyleEnum<Justify>(Justify.SpaceBetween);
			this.style.paddingLeft = new StyleLength(10);
			this.style.paddingRight = new StyleLength(10);

			var btnContainer = new VisualElement()
			{
				style =
				{
					flexGrow = 0,
					width = new StyleLength(StyleKeyword.Auto),
					flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row),
					alignItems = new StyleEnum<Align>(Align.Center),
				}
			};

			_title = new Label();
			_deleteBtn = new Button() {text = "Delete"};
			_updateBtn = new Button();

			btnContainer.Add(_deleteBtn);
			btnContainer.Add(_updateBtn);
			this.Add(_title);
			this.Add(btnContainer);
		}

		/// <summary>
		/// Binds the specified package.
		/// </summary>
		/// <param name="package">The package.</param>
		/// <param name="install">The install.</param>
		/// <param name="delete">The delete.</param>
		public void Bind(LemonIncPackage package, Func<LemonIncPackage, Action<bool>, IEnumerator> install, Func<LemonIncPackage, Action<bool>, IEnumerator> delete)
		{
			_package = package;
			_title.text = package.Feature;

			if (!package.Installed)
			{
				_deleteBtn.SetEnabled(false);
				_deleteBtn.visible = false;
				_updateBtn.text = INSTALL_TEXT;
			}
			else
			{
				_updateBtn.text = UPDATE_TEXT;
			}

			_installCallback = install;
			_deleteCallback = delete;

			_updateBtn.clicked += OnUpdateClick;
			_deleteBtn.clicked += DeleteBtnOnClick;
		}

		private void DeleteBtnOnClick()
		{
			_deleteBtn.SetEnabled(false);
			EditorCoroutineUtility.StartCoroutine(_deleteCallback(_package, (success) =>
			{
				if (success)
				{
					_deleteBtn.SetEnabled(false);
					_deleteBtn.visible = false;
					_updateBtn.text = INSTALL_TEXT;
				}
				else
				{
					_deleteBtn.SetEnabled(true);
				}
			}), this);
		}

		private void OnUpdateClick()
		{
			_updateBtn.SetEnabled(false);
			_updateBtn.text = LOADING_TEXT;
			EditorCoroutineUtility.StartCoroutine(_installCallback(_package, (success) =>
			{
				_updateBtn.SetEnabled(true);
				_updateBtn.text = INSTALL_TEXT;

				if (success)
				{
					_deleteBtn.SetEnabled(true);
					_deleteBtn.visible = true;
					_updateBtn.text = UPDATE_TEXT;
				}
			}), this);
		}
	}
}
