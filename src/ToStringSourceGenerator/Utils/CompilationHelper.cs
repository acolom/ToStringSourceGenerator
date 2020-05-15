using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ToStringSourceGenerator.Utils
{
    /// <summary>
    /// Utility class extracted from https://github.com/terrajobst/minsk/blob/master/src/Minsk.Generators/SyntaxNodeGetChildrenGenerator.cs
    /// https://youtu.be/JSFZ3qDx83g?list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y&t=1524
    /// </summary>
    internal static class CompilationHelper
    {
        public static IReadOnlyList<INamedTypeSymbol> GetAllTypes(IAssemblySymbol symbol)
        {
            var result = new List<INamedTypeSymbol>();
            GetAllTypes(result, symbol.GlobalNamespace);
            result.Sort((x, y) => x.MetadataName.CompareTo(y.MetadataName));
            return result;
        }

        public static void GetAllTypes(List<INamedTypeSymbol> result, INamespaceOrTypeSymbol symbol)
        {
            if (symbol is INamedTypeSymbol type)
                result.Add(type);

            foreach (var child in symbol.GetMembers())
                if (child is INamespaceOrTypeSymbol nsChild)
                    GetAllTypes(result, nsChild);
        }

        public static bool IsDerivedFrom(ITypeSymbol type, INamedTypeSymbol baseType)
        {
            while (type != null)
            {
                if (SymbolEqualityComparer.Default.Equals(type, baseType))
                    return true;

                type = type.BaseType;
            }

            return false;
        }

        public static bool IsPartial(INamedTypeSymbol type)
        {
            foreach (var declaration in type.DeclaringSyntaxReferences)
            {
                var syntax = declaration.GetSyntax();
                if (syntax is TypeDeclarationSyntax typeDeclaration)
                {
                    foreach (var modifer in typeDeclaration.Modifiers)
                    {
                        if (modifer.ValueText == "partial")
                            return true;
                    }
                }
            }

            return false;
        }

        public static bool AttributeDataIsOfType<T>(AttributeData attributeData) where T : Attribute
        {
            return typeof(T).FullName == attributeData.AttributeClass.ToDisplayString();
        }

        public static bool SymbolContainsAttribute<T>(ISymbol symbol) where T : Attribute
        {
            foreach (var attr in symbol.GetAttributes())
            {
                // better way to check??
                var isAttr = AttributeDataIsOfType<T>(attr);
                if (isAttr)
                    return true;
            }
            return false;
        }

        public static IEnumerable<AttributeData> GetAttributesOfType<T>(ISymbol symbol) where T : Attribute
        {
            foreach (var attr in symbol.GetAttributes())
            {
                // better way to check??
                var isAttr = AttributeDataIsOfType<T>(attr);
                if (isAttr)
                    yield return attr;
            }
        }
    }
}
