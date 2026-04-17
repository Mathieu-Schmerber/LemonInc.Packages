using System;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Implemented by any state (leaf or sub-state machine) that can gate action execution.
    /// </summary>
    public interface IActionGate
    {
        bool AllowsAction(Type actionType);
    }
}