namespace MyOrder.Shared.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class HandlesEventAttribute(Type eventType) : Attribute
{
    public Type EventType { get; } = eventType;
}