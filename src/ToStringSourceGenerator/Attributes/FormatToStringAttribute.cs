using System;
using System.Collections.Generic;
using System.Text;

namespace ToStringSourceGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class FormatToStringAttribute : Attribute
    {
        private readonly string _format;

        public FormatToStringAttribute(string format)
        {
            _format = format;
        }
    }
}
