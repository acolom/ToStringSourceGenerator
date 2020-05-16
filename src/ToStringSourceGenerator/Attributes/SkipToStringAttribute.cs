using System;

namespace ToStringSourceGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class SkipToStringAttribute : Attribute
    {
    }
}
