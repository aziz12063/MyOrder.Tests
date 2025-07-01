using System;

namespace MyOrder.Generator
{
    /// <summary>
    /// Marks a property that is rendered only for display.  
    /// The Field-Reducers generator will exclude it from optimistic
    /// UpdateField reducers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DisplayOnlyFieldAttribute : Attribute { }
}