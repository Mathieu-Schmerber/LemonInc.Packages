using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle
{
    public interface IEventHandleStrategy : IDisposable
    {
        public bool Active { get; set; }
        
        /// <summary>
        /// Try consuming the current event.
        /// </summary>
        /// <param name="preview">The preview editor.</param>
        /// <param name="current">The current event.</param>
        /// <returns>true if the event is consumed.</returns>
        public bool ConsumeEvent(IEditorPreview preview, Event current);
    }
}