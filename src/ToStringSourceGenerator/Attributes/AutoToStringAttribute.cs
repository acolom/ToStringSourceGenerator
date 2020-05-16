using System;

namespace ToStringSourceGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class AutoToStringAttribute : Attribute
    {
    }

}
