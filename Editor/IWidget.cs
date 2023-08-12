using System;
using UnityEngine;

namespace LemonInc.Core.StateMachine.Editor
{
	public interface IWidget<TData>
		where TData : ScriptableObject
	{
		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		TData Data { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is renaming.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is renaming; otherwise, <c>false</c>.
		/// </value>
		bool IsRenaming { get; }

		/// <summary>
		/// Binds the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		void Bind(TData data, Action<string> onRename, Action<TData> onDelete, Action<bool> onToggle);

		/// <summary>
		/// Starts the renaming.
		/// </summary>
		void StartRenaming();

		/// <summary>
		/// Stops the renaming.
		/// </summary>
		/// <param name="save">if set to <c>true</c> [save].</param>
		void StopRenaming(bool save);

		/// <summary>
		/// Deletes this instance.
		/// </summary>
		void Delete();

		/// <summary>
		/// Determines whether this instance is selectable.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is selectable; otherwise, <c>false</c>.
		/// </returns>
		bool IsSelectable();

		/// <summary>
		/// Selects this instance.
		/// </summary>
		void Select();

		/// <summary>
		/// Unselects this instance.
		/// </summary>
		void Unselect();

		/// <summary>
		/// Determines whether this instance is selected.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </returns>
		bool IsSelected();
	}
}