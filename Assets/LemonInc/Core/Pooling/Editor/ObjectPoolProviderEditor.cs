using LemonInc.Core.Pooling.Contracts;
using LemonInc.Core.Pooling.Providers;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Pooling.Editor
{
	/// <summary>
	/// Editor for <see cref="NamedObjectPoolProvider"/>.
	/// </summary>
	/// <seealso cref="UnityEditor.Editor" />
	[CustomEditor(typeof(PoolProviderBase<>), editorForChildClasses: true)]
    public class ObjectPoolProviderEditor : UnityEditor.Editor
    {
	    public override void OnInspectorGUI()
	    {
		    
	    }
    }
}
