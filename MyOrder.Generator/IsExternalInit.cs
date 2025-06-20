#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Runtime.CompilerServices;
#pragma warning restore IDE0130 // Namespace does not match folder structure

// Stub needed so record syntax works when targeting netstandard2.0.
// This is a workaround for the fact that C# 9.0's `init` accessor
internal static class IsExternalInit
{
}
