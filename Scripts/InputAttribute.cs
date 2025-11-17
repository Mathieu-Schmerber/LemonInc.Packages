using System;

namespace LemonInc.Core.Input
{
    /// <summary>
    /// Marks a field as an input that should be automatically registered and updated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InputAttribute : Attribute
    {
    }
}