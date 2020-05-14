using System;
using System.Collections.Generic;
using System.Text;

namespace ToStringSourceGenerator
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AutoToStringAttribute : Attribute
    {
    }

}
