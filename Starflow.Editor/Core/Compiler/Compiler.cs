using CSScriptLib;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StarflowEditor.Core.Compiler
{
    internal class Compiler
    {
        private static readonly IEnumerable<string> DefaultNamespaces =
            new[]
            {
                "Microsoft.Xna.Framework",
                "Starflow",
                "System",
                "System.Net",
                "System.Linq",
                "System.Text",
                "System.Text.RegularExpressions",
                "System.Collections.Generic",
            };

        private static string runtimePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\{0}.dll";

        private static readonly IEnumerable<MetadataReference> DefaultReferences =
            new[]
            {
                MetadataReference.CreateFromFile(string.Format(runtimePath, "mscorlib")),
                MetadataReference.CreateFromFile(string.Format(runtimePath, "System")),
                MetadataReference.CreateFromFile(string.Format(runtimePath, "System.Core")),
                MetadataReference.CreateFromFile(string.Format(AppDomain.CurrentDomain.BaseDirectory + @"{0}.dll", "Starflow")),
                MetadataReference.CreateFromFile(string.Format(AppDomain.CurrentDomain.BaseDirectory + @"{0}.dll", "MonoGame.Framework")),
            };

        private static readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release)
                    .WithUsings(DefaultNamespaces);

        public static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text, Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }

        public static List<Starflow.MonoBehaviour> CompileScripts(string scriptsLocation)
        {
            var scripts = new List<Starflow.MonoBehaviour>();
            var directoryInfo = new DirectoryInfo(scriptsLocation);

            var game_asm = CSScript.Evaluator;

            foreach (var file in directoryInfo.GetFiles())
            {
                /*string className = Path.GetFileNameWithoutExtension(file.Name);

                var info = new CompileInfo { RootClass = "scr_"+className, AssemblyFile = "AssemblyGame.dll" };
                string code = File.ReadAllText(file.FullName);
                string compileCode = @"using Starflow;
using static " + "scr_" + className + @";
MonoBehaviour Class()
{
    return new " + className + @"();
}";
                Console.WriteLine(compileCode);
                game_asm.CompileCode(code, info);
                dynamic script = game_asm.LoadMethod(compileCode);

                Starflow.MonoBehaviour mono = script.Class();
                scripts.Add(mono);*/
            }

            DirectoryInfo d = directoryInfo;
            string[] sourceFiles = d.EnumerateFiles("*.cs", SearchOption.AllDirectories)
                .Select(a => a.FullName).ToArray();

            List<SyntaxTree> trees = new List<SyntaxTree>();
            foreach (string file in sourceFiles)
            {
                string code = File.ReadAllText(file);
                Console.WriteLine(code);
                var tree = Parse(code, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6));
                trees.Add(tree);
            }

            var compilation
                = CSharpCompilation.Create("Sandbox", trees, DefaultReferences, DefaultCompilationOptions);
            try
            {
                var result = compilation.Emit($@"{AppDomain.CurrentDomain.BaseDirectory}\Sandbox.dll");

                Console.WriteLine(result.Success ? "Sucess!!" : "Failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return scripts;
        }
    }

    public class ObjectCreateMethod
    {
        delegate object MethodInvoker();
        MethodInvoker methodHandler = null;

        public ObjectCreateMethod(Type type)
        {
            CreateMethod(type.GetConstructor(Type.EmptyTypes));
        }

        public ObjectCreateMethod(ConstructorInfo target)
        {
            CreateMethod(target);
        }

        void CreateMethod(ConstructorInfo target)
        {
            DynamicMethod dynamic = new DynamicMethod(string.Empty,
                        typeof(object),
                        new Type[0],
                        target.DeclaringType);
            ILGenerator il = dynamic.GetILGenerator();
            il.DeclareLocal(target.DeclaringType);
            il.Emit(OpCodes.Newobj, target);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);

            methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
        }

        public object CreateInstance()
        {
            return methodHandler();
        }
    }
}
