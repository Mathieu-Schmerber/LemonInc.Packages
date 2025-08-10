using UnityEditor;

namespace LemonInc.Core.Utilities.Editor
{
    public class IdentifiableScriptableObjectPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(
            string[] importedAssets, 
            string[] deletedAssets,
            string[] movedAssets, 
            string[] movedFromAssetPaths)
        {
            foreach (var assetPath in importedAssets)
            {
                var asset = AssetDatabase.LoadAssetAtPath<IdentifiableScriptableObject>(assetPath);
                if (asset != null)
                {
                    // Check if this is a duplicate by looking for other assets with same ID
                    var guids = AssetDatabase.FindAssets($"t:{asset.GetType().Name}");
                    var isDuplicate = false;

                    foreach (var guid in guids)
                    {
                        var path = AssetDatabase.GUIDToAssetPath(guid);
                        if (path == assetPath) 
                            continue;
                        
                        var otherAsset = AssetDatabase.LoadAssetAtPath<IdentifiableScriptableObject>(path);
                        if (otherAsset != null && otherAsset.Id == asset.Id && !string.IsNullOrEmpty(asset.Id))
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (isDuplicate || string.IsNullOrEmpty(asset.Id))
                    {
                        asset.Id = System.Guid.NewGuid().ToString();
                        EditorUtility.SetDirty(asset);
                        AssetDatabase.SaveAssets();
                    }
                }
            }
        }
    }
}