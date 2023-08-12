using System.Collections.Generic;
using LemonInc.Tools.Tilemap.Data.TileProperties;
using UnityEngine;

namespace LemonInc.Tools.Tilemap.Data
{
	/// <summary>
	/// Holds the data of a <see cref="Tile"/>.
	/// </summary>
	[CreateAssetMenu(menuName = "Lemon Inc/Tilemap/Tile")]
	public class TileData : ScriptableObject
	{
		public Texture Texture;
		public GameObject Prefab;
		[HideInInspector] public List<TileProperty> Properties;
	}
}