using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CommandHandlerMappingsSourceGenerator
{
    public static class Tool
    {
        private static readonly Type AssemblyType = typeof(Tool);

        public static Stream GetEmbedFile(string filename)
        {
            const string folderName = "EmbedResources";
            var resource = AssemblyType.Assembly.GetManifestResourceStream($"{AssemblyType.Namespace}.{folderName}.{filename}");
            return resource;
        }

        public static string GetEmbedFileAsString(string filename)
        {
            using var embedFile = GetEmbedFile(filename);
            using var reader = new StreamReader(embedFile);
            string text = reader.ReadToEnd();
            return text;
        }

        public static bool HasAttribute(this ClassDeclarationSyntax classDeclaration, string name)
        {
            var attr = GetAttribute(classDeclaration, name);

            return attr is not null;
        }

        public static AttributeSyntax? GetAttribute(this ClassDeclarationSyntax classDeclaration, string name)
        {
            foreach (var attributeList in classDeclaration.AttributeLists)
            {
                foreach (var attribute in attributeList.Attributes)
                {
                    if (attribute.Name.ToString() == name)
                    {
                        return attribute;
                    }
                }
            }
            return null;
        }

        public static string FillTemplateFromFile(string filename, Dictionary<string, string> replacements)
        {
            var template = GetEmbedFileAsString(filename);

            return FillTemplate(template, replacements);
        }

        public static string FillTemplate(string template, Dictionary<string, string> replacements)
        {
            return Regex.Replace(template, @"Template(.+?)Template", m =>
            {
                if (!replacements.TryGetValue(m.Groups[1].Value, out var value))
                {
                    return "ERROR PATTERN NOT FOUND";
                }

                return value;
            });
        }

        public static bool HasToken(this SyntaxTokenList tokenList, string tokenValue)
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                var item = tokenList[i];

                if (item.Text == tokenValue)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool InheritFrom(this INamedTypeSymbol symbol, string fullyQualifiedName)
        {
            while (symbol.BaseType is not null)
            {
                symbol = symbol.BaseType;

                var name = symbol.ToString();

                if (name == fullyQualifiedName)
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddStaticFile(this IncrementalGeneratorPostInitializationContext context, string filename)
        {
            var outputName = filename.Replace(".cs", ".generated.cs");

            var templateString = GetEmbedFileAsString(filename);

            context.AddSource(outputName, templateString);
        }
    }
}