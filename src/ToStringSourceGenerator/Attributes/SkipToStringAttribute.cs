using System;
using System.Collections.Generic;
using System.Text;

namespace ToStringSourceGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SkipToStringAttribute : Attribute
    {
    }
}
