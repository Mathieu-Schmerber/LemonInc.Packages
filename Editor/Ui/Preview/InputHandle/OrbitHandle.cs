using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle
{
    public class OrbitHandle : IInputHandleStrategy
    {
        public bool Active { get; set; }
     
        public void OnInput(IEditorPreview preview, Event current)
        {
            
        }
        
        public void Dispose() { }
    }
}