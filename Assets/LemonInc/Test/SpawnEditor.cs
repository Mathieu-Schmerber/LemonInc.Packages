using System;
using Databases;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawn))]
public class SpawnEditor : OdinEditor
{
	private Texture2D _image;

	protected override void OnEnable()
	{
		base.OnEnable();
		_image = RuntimeDatabase.Section.NewAsset;
	}
}