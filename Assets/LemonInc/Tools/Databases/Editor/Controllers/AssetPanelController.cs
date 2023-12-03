using System.Linq;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Extensions;
using LemonInc.Tools.Databases.Interfaces;
using LemonInc.Tools.Databases.Models;
using LemonInc.Tools.Databases.Ui;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using EditorIcons = Sirenix.Utilities.Editor.EditorIcons;
using Object = UnityEngine.Object;

namespace LemonInc.Tools.Databases.Controllers
{
	/// <summary>
	/// Controls the asset panel.
	/// </summary>
	public class AssetPanelController : ListPanelController<AssetListEntry, AssetDefinition>
	{
		/// <summary>
		/// The load folder button.
		/// </summary>
		private readonly ToolbarButton _loadFolderButton;

		/// <summary>
		/// The empty information.
		/// </summary>
		private readonly Label _emptyInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="AssetPanelController"/> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="reference">The reference.</param>
		/// <param name="validateItem">The validate item.</param>
		public AssetPanelController(string title, 
			PanelReference reference, 
			IPanelItem<AssetDefinition>.OnValidate validateItem) : base(reference, validateItem)
		{
			reference.TitleLabel.text = title;
			_loadFolderButton = new ToolbarButton();
			_loadFolderButton.Add(new Image()
			{
				image = EditorIcons.UnityFolderIcon,
				style =
				{
					width = new StyleLength(18)
				}
			});
			_loadFolderButton.AddToClassList("entry-add-child");
			reference.AddToolbarButton.parent.Add(_loadFolderButton);

			_emptyInfo = new Label
			{
				text = "No element to display"
			};
			_emptyInfo.AddToClassList("empty-info");
			_emptyInfo.style.display = DisplayStyle.Flex;

			ListView.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<AssetDefinition>()
					? DisplayStyle.None
					: DisplayStyle.Flex);

			Reference.PanelVisualElement.Add(_emptyInfo);

			_loadFolderButton.clicked += OpenFolderDialogue;
		}

		/// <summary>
		/// Opens the folder dialogue.
		/// </summary>
		private void OpenFolderDialogue()
		{
			if (Source == null)
				return;

			var folder = EditorUtility.OpenFolderPanel("Load a folder content", "Assets", "");
			if (!string.IsNullOrEmpty(folder))
			{
				LoadAssets<ScriptableObject>(folder);
				LoadAssets<GameObject>(folder);
			}

			Refresh();
		}

		/// <summary>
		/// Loads the assets.
		/// </summary>
		/// <typeparam name="TAsset">The type of the asset.</typeparam>
		/// <param name="folder">The folder.</param>
		private void LoadAssets<TAsset>(string folder) where TAsset : Object
		{
			var assets = AssetDatabase.FindAssets("t:" + typeof(TAsset).Name, new string[1] { folder.ToAssetPath() });

			foreach (var guid in assets)
			{
				var sub = AssetDatabase.GUIDToAssetPath(guid);
				var asset = AssetDatabase.LoadAssetAtPath<TAsset>(sub);

				if (!Source.Any(x => x.Data.GetInstanceID().Equals(asset.GetInstanceID())))
				{
					OnItemAdded(new AssetDefinition()
					{
						Data = asset
					});
				}
			}
		}

		public override void Refresh()
		{
			base.Refresh();

			_emptyInfo.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<AssetDefinition>()
					? DisplayStyle.Flex
					: DisplayStyle.None);

			ListView.style.display =
				new StyleEnum<DisplayStyle>(Source.IsNullOrEmpty<AssetDefinition>()
					? DisplayStyle.None
					: DisplayStyle.Flex);

			Reference.PanelVisualElement.SetEnabled(Source != null);
		}
	}
}