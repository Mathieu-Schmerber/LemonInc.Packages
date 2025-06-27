using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
	/// <summary>
	/// Package scope.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.VisualElement" />
	public class PackageScope : VisualElement
	{
		private readonly Label _title;
		private readonly ListView _packageView;
		private List<LemonIncPackage> _packages;

		/// <summary>
		/// Gets or sets the install callback.
		/// </summary>
		/// <value>
		/// The install callback.
		/// </value>
		public Func<LemonIncPackage, Action<bool>, IEnumerator> InstallCallback { get; set; }

		/// <summary>
		/// Gets or sets the delete callback.
		/// </summary>
		/// <value>
		/// The delete callback.
		/// </value>
		public Func<LemonIncPackage, Action<bool>, IEnumerator> DeleteCallback { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PackageScope"/> class.
		/// </summary>
		/// <param name="baseUxml">The base uxml.</param>
		/// <param name="entryUxml">The entry uxml.</param>
		public PackageScope(VisualTreeAsset baseUxml)
		{
			baseUxml.CloneTree(this);

			_title = this.Q<Label>();
			_packageView = this.Q<ListView>();
			
			_packageView.makeItem = () => new PackageEntry();
			_packageView.bindItem = (element, index) => (element as PackageEntry)?.Bind(_packages[index], InstallCallback, DeleteCallback);
		}

		/// <summary>
		/// Binds the specified package.
		/// </summary>
		/// <param name="packages">The package.</param>
		public void Bind(List<LemonIncPackage> packages)
		{
			_packages = packages;
			_title.text = packages.FirstOrDefault()?.Scope;
			_packageView.itemsSource = _packages;
		}
	}
}