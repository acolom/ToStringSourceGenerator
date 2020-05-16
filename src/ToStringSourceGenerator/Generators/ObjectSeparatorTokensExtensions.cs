using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace ToStringSourceGenerator.Generators
{
    public static class ObjectSeparatorTokensExtensions
    {
        public static string GetOpeningSeparatorFor(this ObjectSeparatorTokens separator)
        {
            switch (separator)
            {
                case ObjectSeparatorTokens.None:
                    return string.Empty;
                case ObjectSeparatorTokens.Brace:
                    return "{{ ";
                case ObjectSeparatorTokens.Array:
                    return "[ ";
                case ObjectSeparatorTokens.Quote:
                    return "\\\"";
                default:
                    throw new System.Exception($"Unexpected separator value: '{separator}'");
            }
        }
        public static string GetClosingSeparatorFor(this ObjectSeparatorTokens separator)
        {
            switch (separator)
            {
                case ObjectSeparatorTokens.None:
                    return string.Empty;
                case ObjectSeparatorTokens.Brace:
                    return " }}";
                case ObjectSeparatorTokens.Array:
                    return " ]";
                case ObjectSeparatorTokens.Quote:
                    return "\\\"";
                default:
                    throw new System.Exception($"Unexpected separator value: '{separator}'");
            }
        }
        public static ObjectSeparatorTokens GetSeparatorFor(SpecialType specialType)
        {
            var separator = ObjectSeparatorTokens.None;
            switch (specialType)
            {
                case SpecialType.None:
                case SpecialType.System_Object:
                    separator = ObjectSeparatorTokens.Brace;
                    break;
                case SpecialType.System_Array:
                case SpecialType.System_Collections_IEnumerable:
                case SpecialType.System_Collections_Generic_IEnumerable_T:
                case SpecialType.System_Collections_Generic_IList_T:
                case SpecialType.System_Collections_Generic_ICollection_T:
                case SpecialType.System_Collections_IEnumerator:
                case SpecialType.System_Collections_Generic_IEnumerator_T:
                case SpecialType.System_Collections_Generic_IReadOnlyList_T:
                case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                    separator = ObjectSeparatorTokens.Array;
                    break;
                case SpecialType.System_String:
                case SpecialType.System_DateTime:
                    separator = ObjectSeparatorTokens.Quote;
                    break;
            }
            return separator;
        }
    }
}
