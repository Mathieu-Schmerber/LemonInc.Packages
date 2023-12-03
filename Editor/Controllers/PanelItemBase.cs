using System;
using LemonInc.Editor.Utilities;
using LemonInc.Tools.Databases.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Databases.Controllers
{
	/// <summary>
	/// Describes a panel item.
	/// </summary>
	/// <typeparam name="TData">The type of the data.</typeparam>
	/// <seealso cref="IPanelItem{TData}" />
	public abstract class PanelItemBase<TData> : VisualElement, IPanelItem<TData>
		where TData : class, IIdentifiable
	{
		/// <inheritdoc/>
		public string Name { get; set; }

		/// <inheritdoc/>
		public TData Data { get; set; }

		/// <inheritdoc/>
		public bool CanHoldChildren { get; set; }

		/// <inheritdoc/>
		public IPanelItem<TData>.OnValidate Validate { get; set; }

		/// <inheritdoc/>
		public event Action<TData> OnRenamed;

		/// <summary>
		/// The title label.
		/// </summary>
		protected Label TitleLabel;

		/// <summary>
		/// The title container.
		/// </summary>
		private VisualElement _titleContainer;

		/// <summary>
		/// The rename field.
		/// </summary>
		private TextField _renameField;

		/// <summary>
		/// The error icon.
		/// </summary>
		private readonly Image _errorIcon;

		/// <summary>
		/// Initializes an instance of <see cref="PanelItemBase&lt;TData&gt;"/>.
		/// </summary>
		protected PanelItemBase()
		{
			focusable = true;
			SetupRenamingOption();
			_errorIcon = new Image()
			{
				image = EditorIcons.ConsoleErroricon.image,
				style =
				{
					width = new StyleLength(18)
				}
			};
			_errorIcon.style.display = DisplayStyle.None;
			_titleContainer.Insert(0, _errorIcon);
		}

		/// <summary>
		/// Notifies the rename.
		/// </summary>
		public void NotifyRename() => OnRenamed?.Invoke(Data);

		/// <inheritdoc/>
		public void SetError(bool error, string errorMessage)
		{
			TitleLabel.style.color = new StyleColor(error ? Color.red : Color.white);
			_errorIcon.style.display = error ? DisplayStyle.Flex : DisplayStyle.None;
			_errorIcon.tooltip = errorMessage;
		}

		/// <inheritdoc/>
		public virtual void Bind(TData data, Action<TData> onAddChild)
		{
			Data = data;

			SetError(!Validate.Invoke(data, out var errorMessage), errorMessage);
		}

		/// <inheritdoc/>
		public virtual void OnSelected() { }

		/// <inheritdoc/>
		public virtual void OnDeselected() { }

		/// <inheritdoc/>
		public abstract void Dispose();

		#region Rename

		/// <summary>
		/// Sets up the renaming option.
		/// </summary>
		private void SetupRenamingOption()
		{
			_titleContainer = new VisualElement();
			_titleContainer.AddToClassList("title-container");
			TitleLabel = new Label();
			_titleContainer.Add(TitleLabel);
			Add(_titleContainer);

			focusable = true;
			pickingMode = PickingMode.Position;

			_renameField = new TextField
			{
				name = "textField",
				isDelayed = true,
				style =
				{
					display = DisplayStyle.None
				}
			};

			_renameField.AddToClassList("rename-field");
			_renameField.ElementAt(0).style.fontSize = TitleLabel.style.fontSize;
			_renameField.ElementAt(0).style.height = 18f; // still need to figure out how to make these values depend on the label's font size
			_titleContainer.Insert(1, _renameField);

			var textInput = _renameField.Q(TextField.textInputUssName);
			textInput.RegisterCallback<FocusOutEvent>(EndRename);
		}

		/// <summary>
		/// Starts the rename.
		/// </summary>
		public void StartRename()
		{
			TitleLabel.style.display = DisplayStyle.None;
			_renameField.SetValueWithoutNotify(TitleLabel.text);
			_renameField.style.display = DisplayStyle.Flex;
			_renameField.Q(TextField.textInputUssName).Focus();
			_renameField.SelectAll();
		}

		/// <summary>
		/// Ends the rename.
		/// </summary>
		/// <param name="evt">The evt.</param>
		private void EndRename(FocusOutEvent evt)
		{
			TitleLabel.style.display = DisplayStyle.Flex;
			_renameField.style.display = DisplayStyle.None;

			if (TitleLabel.text.Equals(_renameField.text))
				return;

			TitleLabel.text = _renameField.text.Trim();
			Data.Name = TitleLabel.text;
			OnRenamed?.Invoke(Data);
		}

		#endregion
	}
}
