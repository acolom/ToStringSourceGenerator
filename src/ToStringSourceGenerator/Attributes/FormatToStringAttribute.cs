using System;

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
