using System;
using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using static LemonInc.Tools.PackageHandler.Styles;

namespace LemonInc.Tools.PackageHandler.Ui
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
		/// Initializes a new instance of the <see cref="PackageEntry"/> class.
		/// </summary>
		/// <param name="uxml">The uxml.</param>
		public PackageEntry(VisualTreeAsset uxml)
		{
			uxml.CloneTree(this);
			Refresh();
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

			_installCallback = install;
			_deleteCallback = delete;

			_updateBtn.clicked += OnUpdateClick;
			_deleteBtn.clicked += DeleteBtnOnClick;
		}

		private void DeleteBtnOnClick()
		{
			EditorCoroutineUtility.StartCoroutine(_deleteCallback(_package, (success) =>
			{
				if (success)
				{
					//Refresh();
					_deleteBtn.SetEnabled(false);
					_deleteBtn.visible = false;
					_updateBtn.text = INSTALL_TEXT;
				}
			}), this);
		}

		private void OnUpdateClick()
		{
			EditorCoroutineUtility.StartCoroutine(_installCallback(_package, (success) =>
			{
				if (success)
				{
					//Refresh();
					_deleteBtn.SetEnabled(true);
					_deleteBtn.visible = true;
					_updateBtn.text = UPDATE_TEXT;
				}
			}), this);
		}

		private void Refresh()
		{
			_title = this.Q<Label>("Title");
			_updateBtn = this.Q<Button>("Update");
			_deleteBtn = this.Q<Button>("Delete");
		}
	}
}
