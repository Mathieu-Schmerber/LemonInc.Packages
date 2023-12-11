using System;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Interfaces;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Editor.Controllers
{
	/// <summary>
	/// Tree view entry.
	/// </summary>
	/// <seealso cref="UnityEditor.IMGUI.Controls.TreeViewItem" />
	public class TreeViewEntry<TData> : PanelItemBase<TData>
		where TData : class, IIdentifiable
	{
		/// <summary>
		/// The add button.
		/// </summary>
		private readonly Button _addButton;

		/// <summary>
		/// The on child add.
		/// </summary>
		private Action<TData> _onChildAdd;

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeViewEntry&lt;TData&gt;"/> class.
		/// </summary>
		/// <param name="mayHaveChildren">if set to <c>true</c> [may have children].</param>
		/// <param name="color">The color.</param>
		public TreeViewEntry(bool mayHaveChildren, Color color)
		{
			Insert(0, new ColoredSquare(color));
			AddToClassList("view-entry");

			if (mayHaveChildren)
			{
				Add(new ToolbarSpacer()
				{
					style =
					{
						flexGrow = 1,
						flexShrink = 0
					}
				});
				_addButton = new Button
				{
					text = "+"
				};
				_addButton.AddToClassList("entry-add-child");
				_addButton.clicked += OnChildAdd;
				Add(_addButton);
			}
		}

		/// <summary>
		/// Called when [child add].
		/// </summary>
		private void OnChildAdd()
		{
			_onChildAdd?.Invoke(Data);
		}

		/// <inheritdoc />
		public override void Bind(TData data, Action<TData> onAddChild)
		{
			base.Bind(data, onAddChild);

			TitleLabel.text = data.Name;
			_onChildAdd = onAddChild;
		}

		/// <inheritdoc />
		public override void Dispose()
		{
			_addButton.clicked -= OnChildAdd;
		}
	}
}
