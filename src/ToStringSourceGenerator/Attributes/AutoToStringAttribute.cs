using System;
using System.Collections.Generic;
using System.Text;

namespace ToStringSourceGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class AutoToStringAttribute : Attribute
    {
    }

}
