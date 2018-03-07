using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    static class Reflection
    {
        public static void OutputSomeCodeUsingReflection()
        {
            // Use CodeDOM to generate code at runtime.
            // Generate Hello World with the CodeDOM.  Creates expression graph for creating code at runtime.
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace();
            ns.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression csl = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!")
                );

            compileUnit.Namespaces.Add(ns);
            ns.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(csl);

            CSharpCodeProvider provider = new CSharpCodeProvider();  // Could call a different code provider to output code for diff language.
            VBCodeProvider providerVb = new VBCodeProvider();

            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "     ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
                tw.Close();
            }

            using (StreamWriter sw2 = new StreamWriter("HelloWorld.vb", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw2, "     ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
                tw.Close();
            }
        }

        public static void Funcky()
        {
            Func<int, int, int> addFunc = (x, y) => x + y; // Inline function.
            Console.WriteLine(addFunc(2, 3));
        }
    }
}
