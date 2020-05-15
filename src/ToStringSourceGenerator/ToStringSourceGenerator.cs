using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using ToStringSourceGenerator.Utils;
using Microsoft.CodeAnalysis.CSharp;
using System.CodeDom.Compiler;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using ToStringSourceGenerator.Generators;

namespace ToStringSourceGenerator
{
    [Generator]
    public class ToStringSourceGenerator : ISourceGenerator
    {
        public void Initialize(InitializationContext context)
        {
            // No initialization required for this one
        }

        public void Execute(SourceGeneratorContext context)
        {
            context.AddCompiledOnMetadataAttribute();

            var compilation = (CSharpCompilation)context.Compilation;
            var types = CompilationHelper.GetAllTypes(compilation.Assembly);
            using (var stringWriter = new StringWriter())
            using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "    "))
            {
                foreach (var type in types)
                {
                    if (DefaultToStringGenerator.ShouldUseGenerator(type))
                    {
                        DefaultToStringGenerator.WriteTo(indentedTextWriter, context, type);
                    }
                }

                indentedTextWriter.Flush();
                stringWriter.Flush();

                var sourceText = SourceText.From(stringWriter.ToString(), Encoding.UTF8);
                var hintName = $"AutoToString_{compilation.Assembly.Name}.g.cs";
                
                context.AddSource(hintName, sourceText);
            }
        }
    }
}

