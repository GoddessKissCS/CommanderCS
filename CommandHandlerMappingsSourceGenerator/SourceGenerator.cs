//#define EnableSourceGeneratorDebug

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommandHandlerMappingsSourceGenerator
{
    /// <summary>
    /// https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public class SolrHelperSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext initContext)
        {
#if EnableSourceGeneratorDebug
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
            // Static code outputs
            // Aka things that the user may use in the code and does not deppend on the user code like atributes
            initContext.RegisterPostInitializationOutput(PostInitializationCallback);

            // Do a simple filter
            // To select only the classes that makes sense for us to generate code for
            var classDeclarations = initContext.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: IsTargetForGenerator,
                    transform: Transform);

            // Group all the output to use them together
            var allClassesSelected = classDeclarations.Collect();
            initContext.RegisterSourceOutput(allClassesSelected, GenerateCommonCode);
        }

        public static void PostInitializationCallback(IncrementalGeneratorPostInitializationContext context)
        {
            // Unconditionally generated files
            AddStaticFile("SampleStaticClass.cs");

            void AddStaticFile(string filename)
            {
                var path = $"Static.{filename}";
                var generatedName = filename.Replace(".cs", ".generated.cs");
                context.AddSource(generatedName, Tool.GetEmbedFileAsString(path));
            }
        }

        private const string AttributeName = "Command";
        private const string AttributeNameAlt = $"{AttributeName}Attribute";

        public static bool IsTargetForGenerator(SyntaxNode SyntaxNode, CancellationToken cancellationToken)
        {
            // true if it's what we are looking for, in that case all clases in the specified namespace
            if (SyntaxNode is not ClassDeclarationSyntax classNode)
            {
                return false;
            }

            if (!classNode.HasAttribute(AttributeName))
            {
                return false;
            }

            return true;
        }

        public static SymbolData Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            var ITypeSymbol = context.SemanticModel.GetDeclaredSymbol(context.Node, cancellationToken) as ITypeSymbol;

            return new SymbolData()
            {
                ClassDeclarationSyntax = (ClassDeclarationSyntax)context.Node,
                ITypeSymbol = ITypeSymbol,
            };
        }

        public class SymbolData
        {
            public ClassDeclarationSyntax ClassDeclarationSyntax { get; set; }
            public ITypeSymbol ITypeSymbol { get; set; }
        }

        public static void GenerateCommonCode(SourceProductionContext context, ImmutableArray<SymbolData> symbolData)
        {
            var mappingsCode = new StringBuilder();

            mappingsCode.AppendLine();

            const string indent = "\t\t\t";

            foreach (var symbol in symbolData)
            {
                var attr = symbol.ClassDeclarationSyntax.GetAttribute(AttributeName);
                var typeName = symbol.ITypeSymbol.OriginalDefinition;
                var instanceName = symbol.ITypeSymbol.Name + "Instance";

                var baseClass = typeName.BaseType;
                var paramsType = baseClass.TypeArguments[0];
                var attributes = typeName.GetAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute.AttributeClass.Name != AttributeNameAlt)
                    {
                        continue;
                    }

                    var nammedValues = attribute.NamedArguments.ToImmutableDictionary();

                    if (nammedValues.TryGetValue("Id", out var Id))
                    {
                        //{ 1409, CommandMapping<SampleCommandHandler, SampleParams> },
                        var code = $"{{{Id.Value},CommandMapping<{typeName}, {paramsType}>}},";

                        mappingsCode.Append(indent).AppendLine(code);
                    }
                }
            }

            var parameters = new Dictionary<string, string>
            {
                { "Mappings", mappingsCode.ToString() },
            };

            var interceptorTemplate = Tool.FillTemplateFromFile("PacketHandler.cs", parameters);

            context.AddSource($"PacketHandler.generated.cs", interceptorTemplate);
        }
    }
}
