using System;

namespace LemonInc.Tools.Databases.Interfaces
{
	/// <summary>
	/// Describes a panel item.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IPanelItem<TData> : IDisposable
	{
		/// <summary>
		/// The validation delegate.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="error">The error.</param>
		/// <returns>True if valid.</returns>
		public delegate bool OnValidate(TData data, out string error);

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public TData Data { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance can hold children.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance can hold children; otherwise, <c>false</c>.
		/// </value>
		public bool CanHoldChildren { get; set; }

		/// <summary>
		/// Gets or sets the validate.
		/// </summary>
		/// <value>
		/// The validate.
		/// </value>
		public OnValidate Validate { get; set; }

		/// <summary>
		/// Occurs when [on renamed].
		/// </summary>
		public event Action<TData> OnRenamed;

		/// <summary>
		/// Sets the error.
		/// </summary>
		/// <param name="error">if set to <c>true</c> [error].</param>
		/// <param name="errorMessage">The error message.</param>
		public void SetError(bool error, string errorMessage);

		/// <summary>
		/// Binds the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="onAddChild">The on add child.</param>
		public void Bind(TData data, Action<TData> onAddChild);

		/// <summary>
		/// Called when [selected].
		/// </summary>
		public void OnSelected();

		/// <summary>
		/// Called when [deselected].
		/// </summary>
		public void OnDeselected();

		/// <summary>
		/// Starts renaming.
		/// </summary>
		public void StartRename();
	}
}