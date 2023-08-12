using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Core.StateMachine.Editor
{
	/// <summary>
	/// Widget.
	/// </summary>
	/// <seealso cref="UnityEngine.UIElements.VisualElement" />
	public class Widget<T> : VisualElement, IWidget<T> 
		where T : ScriptableObject
	{
		private VisualElement _titleContainer;
		private VisualElement _contentContainer;
		private Label _titleLabel;
		private TextField _renameField;
		private Foldout _foldout;
		private InspectorElement _inspectorElement;
		private T _data;
		private bool _selected;

		public bool IsRenaming { get; private set; }

		public T Data => _data;

		private Action<T> _onDelete;
		private Action<string> _onRename;
		private Action<bool> _onToggle;

		/// <summary>
		/// Initializes a new instance of the <see cref="Widget{T}"/> class.
		/// </summary>
		public Widget()
		{ 
			BuildUi();
			_renameField.RegisterCallback<FocusOutEvent>(_ => StopRenaming(true));
		}

		private void BuildUi()
		{
			_foldout = new Foldout();
			_titleContainer = new VisualElement { name = "titleContainer" };
			_contentContainer = new VisualElement { name = "contentContainer" };

			_titleLabel = new Label { name = "title" };
			_renameField = new TextField { name = _titleLabel.name, isDelayed = true };

			Hide(_renameField);
			_titleContainer.Add(_titleLabel);
			_titleContainer.Add(_renameField);

			_foldout.Add(_contentContainer);
			var foldoutTop = _foldout.Q<Toggle>().Q("unity-checkmark").parent;
			foldoutTop.Add(_titleContainer);
			Add(_foldout);
		}

		private void Hide(VisualElement element) =>
			element.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);

		private void Show(VisualElement element) =>
			element.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);

		/// <summary>
		/// Binds the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="onRename"></param>
		/// <param name="onDelete"></param>
		/// <param name="onToggle"></param>
		public void Bind(T data, Action<string> onRename, Action<T> onDelete, Action<bool> onToggle)
		{
			if (data == null)
				return;

			_data = data;
			_onRename = onRename;
			_onDelete = onDelete;
			_onToggle = onToggle;
			_titleLabel.text = data.name;

			_inspectorElement = new InspectorElement(data);
			_contentContainer.Add(_inspectorElement);

			_foldout.RegisterValueChangedCallback(evt => _onToggle?.Invoke(evt.newValue));
		}

		public void StartRenaming()
		{
			IsRenaming = true;

			Hide(_titleLabel);
			Show(_renameField);

			_renameField.SetValueWithoutNotify(string.IsNullOrWhiteSpace(Data.name) ? Data.GetType().Name : Data.name);
			_renameField.Focus();
		}

		public void StopRenaming(bool save)
		{
			IsRenaming = false;
			Hide(_renameField);
			Show(_titleLabel);
			if (!save) 
				return;

			if (string.IsNullOrWhiteSpace(_renameField.text))
			{
				if (string.IsNullOrWhiteSpace(Data.name))
					_renameField.SetValueWithoutNotify(Data.GetType().Name);
				else
					return;
			}

			_titleLabel.text = _renameField.text;
			_onRename?.Invoke(_renameField.text);
		}

		/// <summary>
		/// Deletes this instance.
		/// </summary>
		public void Delete()
		{
			_onDelete?.Invoke(Data);
		}

		public bool IsSelectable() => true;

		public void Select()
		{
			_selected = true;
		}

		public void Unselect()
		{
			_selected = false;
		}

		public bool IsSelected() => _selected;
	}
}