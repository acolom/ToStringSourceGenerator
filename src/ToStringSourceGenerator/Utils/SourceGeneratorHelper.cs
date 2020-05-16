using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace ToStringSourceGenerator.Utils
{
    internal static class SourceGeneratorHelper
    {
        public static void AddCompiledOnMetadataAttribute(this SourceGeneratorContext context)
        {
            var sourceText = SourceText.From($"[assembly: System.Reflection.AssemblyMetadata(\"CompiledOn:\", \"{DateTime.UtcNow}\")]", Encoding.UTF8);
            context.AddSource("Generated.cs", sourceText);
        }
    }
}
