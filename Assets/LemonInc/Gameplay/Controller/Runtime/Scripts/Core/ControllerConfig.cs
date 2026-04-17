using UnityEngine;

namespace LemonInc.Gameplay.Controller.Core
{
    /// <summary>
    /// Base ScriptableObject configuration for any controller.
    /// Subclass this to define controller-specific tuning data (speeds, gravity scale, etc.)
    /// </summary>
    public abstract class ControllerConfig : ScriptableObject { }
}