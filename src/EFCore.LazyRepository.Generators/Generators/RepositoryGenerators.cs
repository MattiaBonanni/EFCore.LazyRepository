using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace EFCore.LazyRepository.Generators.Generators
{
    [Generator]
    public class RepositoryGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            StringBuilder sourceBuilder = new StringBuilder(@"
using System;
namespace EFCore.LazyRepository.Repositories
{
    public partial class FooBarRepository
    {
        public void FromGenerator() 
        {
            Console.WriteLine(""Hello from generated code!"");
        }
    }
}");

            // inject the created source into the users compilation
            context.AddSource("fooBarRepository", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No needed
        }
    }
}
