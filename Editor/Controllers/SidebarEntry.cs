using System;
using LemonInc.Core.Utilities.Editor;
using LemonInc.Tools.Panels.Interfaces;
using LemonInc.Tools.Panels.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
      /// The text field used for renaming.
      /// </summary>
      private TextField _renameField;

      /// <summary>
      /// The current sidebar element.
      /// </summary>
      private ISidebarElement _currentElement;

      /// <summary>
      /// Tracks whether this entry is currently selected.
      /// </summary>
      private bool _isSelected = false;

      /// <summary>
      /// Delegate for the rename success event.
      /// </summary>
      /// <param name="id">The ID of the renamed element.</param>
      /// <param name="newName">The new name of the element.</param>
      public delegate void RenameSuccessHandler(string oldName, string newName);
      
      /// <summary>
      /// Event raised when rename is successfully completed.
      /// </summary>
      public RenameSuccessHandler OnRenameSuccess;

      /// <summary>
      /// Event raised when we should delete this entry.
      /// </summary>
      public Action OnDeleteRequested;
      
      public Action OnCreateItemRequested;
      
      public Action OnCreateSectionRequested;
      
      /// <summary>
      /// Initializes a new instance of the <see cref="SidebarEntry"/> class.
      /// </summary>
      public SidebarEntry()
      {
         _root = new VisualElement
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

         _icon = new Image
         {
            style =
            {
               width = new StyleLength(20)
            }
         };
         _name = new Label
         {
            enableRichText = true,
            style =
            {
               flexGrow = 1,
               alignContent = Align.Center,
               alignSelf = Align.Center,
            }
         };

         _root.Add(_icon);
         _root.Add(_name);

         Add(_root);

         // Register for keyboard events to handle F2 rename shortcut
         RegisterCallback<KeyDownEvent>(OnKeyDown);

         // Register callbacks for tracking selection state
         RegisterCallback<MouseDownEvent>(_ => Focus());
         RegisterCallback<FocusInEvent>(_ => SetSelected(true));
         RegisterCallback<FocusOutEvent>(_ => SetSelected(false));

         _root.RegisterCallback<ContextClickEvent>(OnContextClick);
         
         // Make the element focusable to receive keyboard events
         focusable = true;
      }

      private Texture GetIconForElement(ISidebarElement element)
      {
         var customIcon = EditorGUIUtility.GetIconForObject(element.Object);
         return customIcon == null ? EditorIcons.ScriptableobjectIcon.image : customIcon;
      }

      /// <summary>
      /// Binds the specified sidebar element.
      /// </summary>
      /// <param name="sidebarElement">The sidebar element.</param>
      /// <param name="highlight">Optional text part to highlight.</param>
      public void Bind(ISidebarElement sidebarElement, string highlight = "")
      {
         Id = sidebarElement.Id;
         _currentElement = sidebarElement;

         switch (sidebarElement.Type)
         {
            case SidebarElementType.ELEMENT:
               _icon.image = GetIconForElement(sidebarElement);
               _root.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0f));
               break;
            case SidebarElementType.GROUP:
               _icon.image = sidebarElement.Empty ? EditorIcons.FolderemptyIcon.image : EditorIcons.FolderIcon.image;
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

      /// <summary>
      /// Sets the selected state of this entry and updates visual appearance.
      /// </summary>
      public void SetSelected(bool isSelected)
      {
         _isSelected = isSelected;

         // Update visual appearance based on selection state
         if (_isSelected)
         {
            _root.AddToClassList("selected-entry");
            _root.style.backgroundColor = new StyleColor(new Color(0.2f, 0.4f, 0.6f, 0.5f));
         }
         else
         {
            _root.RemoveFromClassList("selected-entry");

            // Restore original background color based on element type
            if (_currentElement != null)
            {
               switch (_currentElement.Type)
               {
                  case SidebarElementType.ELEMENT:
                     _root.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0f));
                     break;
                  case SidebarElementType.GROUP:
                     _root.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0.2f));
                     break;
               }
            }
         }
      }

      /// <summary>
      /// Handles key down events to trigger rename on F2.
      /// </summary>
      private void OnKeyDown(KeyDownEvent evt)
      {
         if (!_isSelected)
            return;
         
         if (evt.keyCode == KeyCode.F2)
         {
            StartRename();
            evt.StopPropagation();
         }
         else if (evt.keyCode is KeyCode.Delete or KeyCode.Backspace)
         {
            OnDeleteRequested?.Invoke();
            evt.StopPropagation();
         }
      }

      /// <summary>
      /// Starts the rename operation for this sidebar entry.
      /// </summary>
      public void StartRename()
      {
         // Hide the name label
         _name.style.display = DisplayStyle.None;

         // Create and configure the rename field if it doesn't exist
         if (_renameField == null)
         {
            _renameField = new TextField
            {
               style =
               {
                  flexGrow = 1,
                  marginLeft = 4,
                  marginRight = 4
               }
            };

            // Register event handlers for the field
            _renameField.RegisterCallback<KeyDownEvent>(evt =>
            {
               switch (evt.keyCode)
               {
                  case KeyCode.Return:
                  case KeyCode.KeypadEnter:
                     StopRename();
                     evt.StopPropagation();
                     break;
                  case KeyCode.Escape:
                     CancelRename();
                     evt.StopPropagation();
                     break;
               }
            });

            _renameField.RegisterCallback<FocusOutEvent>(_ => StopRename());
         }

         // Set the initial value and add to the hierarchy
         _renameField.value = _currentElement.DisplayName;
         _root.Add(_renameField);

         // Focus and select all text
         _renameField.schedule.Execute(() =>
         {
            _renameField.Focus();
            _renameField.SelectAll();
         });
      }

      /// <summary>
      /// Stops the rename operation and applies the new name.
      /// </summary>
      public void StopRename()
      {
         if (_renameField == null || !_root.Contains(_renameField))
            return;

         var newName = _renameField.value;

         // Don't apply empty names
         if (string.IsNullOrWhiteSpace(newName))
         {
            CancelRename();
            return;
         }

         // Remove the rename field and show the label
         _root.Remove(_renameField);
         _name.style.display = DisplayStyle.Flex;

         // Only raise the event if the name actually changed
         if (newName != _currentElement.DisplayName)
         {
            _name.text = newName;
            OnRenameSuccess?.Invoke(_currentElement.DisplayName, newName);
         }
      }

      /// <summary>
      /// Cancels the rename operation without applying changes.
      /// </summary>
      public void CancelRename()
      {
         if (_renameField == null || !_root.Contains(_renameField))
            return;

         // Remove the rename field and show the label
         _root.Remove(_renameField);
         _name.style.display = DisplayStyle.Flex;

         // No event is raised when renaming is cancelled
      }
      
      private void OnContextClick(ContextClickEvent evt)
      {
         if (_currentElement == null)
            return;

         var menu = new GenericMenu();

         switch (_currentElement.Type)
         {
            case SidebarElementType.GROUP:
               menu.AddItem(new GUIContent("Add item"), false, () =>
               {
                  OnCreateItemRequested?.Invoke();
               });

               menu.AddItem(new GUIContent("Add child section"), false, () =>
               {
                  OnCreateSectionRequested?.Invoke();
               });

               menu.AddSeparator("");
               menu.AddItem(new GUIContent("Rename (F2)"), false, StartRename);
               break;

            case SidebarElementType.ELEMENT:
               menu.AddItem(new GUIContent("Rename (F2)"), false, StartRename);
               break;

            default:
               return;
         }

         menu.ShowAsContext();
         evt.StopPropagation();
      }
   }
}