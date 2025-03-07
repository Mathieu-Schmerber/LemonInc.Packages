using System.Collections.Generic;
using System.Linq;
using LemonInc.Core.Grid.Extensions;
using LemonInc.Core.Grid.Interfaces;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Tools.Tilemap.Data;
using LemonInc.Tools.Tilemap.Data.TileProperties;
using UnityEngine;

namespace LemonInc.Tools.Tilemap
{
	/// <summary>
	/// Describes a tile.
	/// </summary>
	public class Tile
	{
		private class PropertySetting
		{
			public GameObject Prefab { get; set; }
			public Quaternion Rotation { get; set; } = Quaternion.identity;
			public TileProperty Property { get; set; }

			public PropertySetting(GameObject prefab)
			{
				Prefab = prefab;
			}
		}

		/// <summary>
		/// Gets or sets the tile's data.
		/// </summary>
		public TileData Data { get; set; }

		/// <summary>
		/// Instantiated <see cref="GameObject"/>.
		/// </summary>
		public GameObject InstanceGO { get; private set; }

		/// <summary>
		/// The currently used prefab.
		/// </summary>
		public GameObject InstancePrefab { get; set; }

		/// <summary>
		/// Refreshes the tile.
		/// </summary>
		/// <param name="tilemap">The <see cref="Tilemap"/> of the tile.</param>
		/// <param name="gridPosition">The grid position on the tilemap.</param>
		public void Refresh(Tilemap tilemap, Vector3Int gridPosition, List<Vector3Int> refreshedChain = null)
		{
			if (Data == null)
				Clear(tilemap, gridPosition);
			else
			{
				var setting = GetRuledPrefab(tilemap, gridPosition);

				if (setting.Prefab != InstancePrefab)
				{
					if (InstanceGO)
						Clear(tilemap, gridPosition);

					var display = setting.Property == null ? setting.Prefab : GetPropertyPrefab(setting.Property);

					InstanceGO = UnityEngine.Object.Instantiate(display, tilemap.ToWorldPos(gridPosition), setting.Rotation, tilemap.transform);
					if (setting.Property != null)
						MirrorProperty(setting.Property, InstanceGO);
					InstancePrefab = setting.Prefab;
				}
				else
					return;
			}

			UpdateNeighbors(tilemap, gridPosition, refreshedChain ?? new List<Vector3Int>());
		}

		/// <summary>
		/// Clears the tile.
		/// </summary>
		/// <param name="tilemap">The <see cref="Tilemap"/> of the tile.</param>
		/// <param name="gridPosition">The grid position on the tilemap.</param>
		private void Clear(Tilemap tilemap, Vector3Int gridPosition)
		{
			var instance = InstanceGO ?? tilemap.GetInstanceAt(gridPosition);
			if (instance)
			{
#if UNITY_EDITOR
				UnityEngine.Object.DestroyImmediate(instance);
#else
				UnityEngine.Object.Destroy(instance);
#endif
				InstanceGO = null;
				InstancePrefab = null;
			}
		}

		private void UpdateNeighbors(Tilemap tilemap, Vector3Int gridPosition, ICollection<Vector3Int> refreshedChain = null)
		{
			Vector2Int[] neighbors = {
				Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
				Vector2Int.up + Vector2Int.left, Vector2Int.up + Vector2Int.right, Vector2Int.down + Vector2Int.left, Vector2Int.down + Vector2Int.right
			};

			refreshedChain?.Add(gridPosition);
			foreach (var item in neighbors)
			{
				var pos = gridPosition + new Vector3Int(item.x, 0, item.y);

				if (refreshedChain == null || refreshedChain.Contains(pos))
					continue;

				var tile = tilemap.GetTile(pos);

				refreshedChain?.Add(pos);
				if (tile != null && tile.Data != null)
					tile.Refresh(tilemap, pos);
			}
		}

		private PropertySetting GetRuledPrefab(Tilemap tilemap, Vector3Int gridPosition)
		{
			if (Data.Properties == null || Data.Properties.Count == 0)
				return new PropertySetting(Data.Prefab);

			foreach (var property in Data.Properties.OrderByDescending(x => x.Neighboring.Count(x => x.Value != null)))
			{
				var setting = GetMatchingPropertySetting(property, tilemap, gridPosition);

				if (setting != null)
					return setting;
			}

			return new PropertySetting(Data.Prefab);
		}

		private PropertySetting GetMatchingPropertySetting(TileProperty property, Tilemap tilemap, Vector3Int gridPosition)
		{
			var angle = 0;
			var neighboring = property.Neighboring
				.Where(x => x.Value != null)
				.Select(prop => new KeyValuePair<Vector3Int, TileData>(new Vector3Int(prop.Key.x, 0, prop.Key.y), prop.Value))
				.ToList();
			var iterations = new Dictionary<TileProperty.PatternRotation, (int iteration, int angle)>
			{
				{TileProperty.PatternRotation.Never, (iteration: 1, angle: 0)},
				{TileProperty.PatternRotation._180, (iteration: 2, angle: 180)},
				{TileProperty.PatternRotation._90, (iteration: 4, angle: 90)},
			};

			for (var i = 0; i < iterations[property.Rotate].iteration; i++)
			{
				var match = true;

				foreach (var item in neighboring)
				{
					var tile = tilemap.GetTile(item.Key + gridPosition);

					if (tile == null || tile.Data != item.Value)
					{
						match = false;
						break;
					}
				}

				if (match)
				{
					return new PropertySetting(property.Outcome)
					{
						Rotation = Quaternion.Euler(0, property.RotateTile ? angle : 0, 0),
						Property = property
					};
				}

				angle += iterations[property.Rotate].angle;
				neighboring = neighboring.Select(x => new KeyValuePair<Vector3Int, TileData>(x.Key.RotatePoint(Vector3Int.up * angle, Vector3Int.zero), x.Value)).ToList();
			}

			return null;
		}

		private void MirrorProperty(TileProperty property, GameObject instance)
		{
			var scale = Vector3Int.one;
			int[] factors = { 1, -1 };

			switch (property.Mirror)
			{
				case TileProperty.MirrorOutcome.X:
					scale.x *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Y:
					scale.y *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Z:
					scale.z *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Xy:
					scale.x *= factors.Random();
					scale.y *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Xz:
					scale.x *= factors.Random();
					scale.z *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Yz:
					scale.y *= factors.Random();
					scale.z *= factors.Random();
					break;
				case TileProperty.MirrorOutcome.Xyz:
					scale.x *= factors.Random();
					scale.y *= factors.Random();
					scale.z *= factors.Random();
					break;
			}

			instance.transform.localScale = new Vector3(instance.transform.localScale.x * scale.x, instance.transform.localScale.y * scale.y, instance.transform.localScale.z * scale.z);
		}

		private GameObject GetPropertyPrefab(TileProperty property)
		{
			return property.Random != null && property.Random.Length > 0 ? property.Random.Random() : property.Outcome;
		}
	}
}