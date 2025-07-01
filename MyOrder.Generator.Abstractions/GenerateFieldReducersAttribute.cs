using System;

namespace MyOrder.Generator
{
    /// <summary>
    /// Place this on any Fluxor <c>[FeatureState]</c> record (or
    /// record/class that participates in Fluxor) whose <c>IField</c>
    /// properties you want updated optimistically by the generator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class GenerateFieldReducersAttribute : Attribute
    { }
}