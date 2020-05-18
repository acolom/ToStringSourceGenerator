using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using ToStringSourceGenerator.Utils;

namespace ToStringSourceGenerator.Generators
{
    [Generator]
    public class SourceGeneratorToString : ISourceGenerator
    {
        public void Initialize(InitializationContext context)
        {
            // No initialization required for this one
        }

        public void Execute(SourceGeneratorContext context)
        {
            context.AddCompiledOnMetadataAttribute();

            var compilation = context.Compilation;
            var types = CompilationHelper.GetAllTypes(context.Compilation.Assembly);

            using (var stringWriter = new StringWriter())
            using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "    "))
            {
                var defaultToStringGenerator = new DefaultToStringGenerator(context);
                foreach (var type in types)
                {
                    if (DefaultToStringGenerator.ShouldUseGenerator(type))
                    {
                        defaultToStringGenerator.WriteType(type, indentedTextWriter);
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

