using System;
using System.Collections.Generic;
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

        public static void AddHelloWorldClass(this SourceGeneratorContext context)
        {
            // begin creating the source we'll inject into the users compilation
            var sourceBuilder = new StringBuilder(@"
                using System;
               namespace HelloWorldGenerated
                {
                    public static class HelloWorld
                    {
                        public static void SayHello() 
                        {
                            Console.WriteLine(""Hello from generated code!"");
                            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
            ");

            // using the context, get a list of syntax trees in the users compilation
            var syntaxTrees = context.Compilation.SyntaxTrees;

            // add the filepath of each tree to the class we're building
            foreach (SyntaxTree tree in syntaxTrees)
            {
                sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
            }

            // finish creating the source to inject
            sourceBuilder.Append(@"
                    }
                }
            }");

            // inject the created source into the users compilation
            context.AddSource("helloWorldGenerator.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }
    }
}
