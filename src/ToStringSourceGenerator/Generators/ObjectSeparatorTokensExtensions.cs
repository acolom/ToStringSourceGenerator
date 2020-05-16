using Microsoft.CodeAnalysis;

namespace ToStringSourceGenerator.Generators
{
    public static class ObjectSeparatorTokensExtensions
    {
        public static string GetOpeningSeparatorFor(this ObjectSeparatorToken separator)
        {
            switch (separator)
            {
                case ObjectSeparatorToken.None:
                    return string.Empty;
                case ObjectSeparatorToken.Brace:
                    return "{{ ";
                case ObjectSeparatorToken.Array:
                    return "[ ";
                case ObjectSeparatorToken.Quote:
                    return "\\\"";
                default:
                    throw new System.Exception($"Unexpected separator value: '{separator}'");
            }
        }
        public static string GetClosingSeparatorFor(this ObjectSeparatorToken separator)
        {
            switch (separator)
            {
                case ObjectSeparatorToken.None:
                    return string.Empty;
                case ObjectSeparatorToken.Brace:
                    return " }}";
                case ObjectSeparatorToken.Array:
                    return " ]";
                case ObjectSeparatorToken.Quote:
                    return "\\\"";
                default:
                    throw new System.Exception($"Unexpected separator value: '{separator}'");
            }
        }
        public static ObjectSeparatorToken GetSeparatorFor(SpecialType specialType)
        {
            var separator = ObjectSeparatorToken.None;
            switch (specialType)
            {
                case SpecialType.None:
                case SpecialType.System_Object:
                    separator = ObjectSeparatorToken.Brace;
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
                    separator = ObjectSeparatorToken.Array;
                    break;
                case SpecialType.System_String:
                case SpecialType.System_DateTime:
                    separator = ObjectSeparatorToken.Quote;
                    break;
            }
            return separator;
        }
    }
}
