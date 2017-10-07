using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.CodeDom;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace _5_ExamQuestionsTest
{
    partial class Program
    {
        enum Days { Mon = 1, Tue, Wed, Thur, Fri, Sat, Sun };

        [Flags]
        enum Days2
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        public enum Planet
        {
            Mercury,
            Venus,
            Earth
        }

        public static class SolarSystem
        {
            public static IEnumerable<Planet> PlanetsByDistanceFromSun
            {
                get
                {
                    yield return Planet.Mercury;  // Can return each element one at a time.
                    yield return Planet.Venus;
                    yield return Planet.Earth;
                }
            }
        }

        [DataContract]
        internal class Person2
        {
            [DataMember]
            internal string name;

            [DataMember]
            internal int age;
        }

        public static void SerializeToJSON()
        {
            Person2 p = new Person2();
            p.name = "James";
            p.age = 40;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person2));

            ser.WriteObject(stream1, p); // Serlializes the object to a JSON message.

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person2 object: ");
            Console.WriteLine(sr.ReadToEnd());
        }

        public static Person2 DeserializeJSONToObject(string json)
        {
            Person2 p2 = new Person2();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(p2.GetType());
            p2 = ser.ReadObject(ms) as Person2;
            ms.Close();
            return p2;
        }

        static void Main(string[] args)
        {
            foreach (Planet p in SolarSystem.PlanetsByDistanceFromSun)
            {
                Console.WriteLine("Planet = {0}", p);
            }

            SerializeToJSON();
            Person2 p2 = DeserializeJSONToObject("{\"name\": \"Bob\", \"age\": 19}");
            Console.WriteLine("name = {0}, age = {1}", p2.name, p2.age);
                
            //var graph = BuildHelloWorldGraph.BuildGraph();
            //string sourceFile = BuildHelloWorldGraph.GenerateCSharpCode(graph);
            //bool success = BuildHelloWorldGraph.CompileCSharpCode(sourceFile, @".\HelloWorld.exe");

            //TryFlags();

            //ch03();
            //optional(lastname: "Corbs", age: 40);

            //decimal total = 1234.56M;
            //Console.WriteLine(String.Format("{0:C}", total));
            //Console.WriteLine(total.ToString("c"));

            //Person alice = new Employee();
            //Person brett = new Manager();
            //Employee bob = new Person();
            //Manager cindy = new Employee();
            //Manager dan = (Manager)(new Employee());

            //Console.WriteLine(Convert.ChangeType(3.14F, TypeCode.Int32));

            //BitConverter.ToInt16()
            //Byte[] bytes = BitConverter.GetBytes(40);

            //Console.WriteLine(string.Join(" ", new List<string> { "James", "Ben", "Lockie" }));

            //Console.WriteLine(DateTime.Now.ToString("D"));
            //Console.WriteLine(DateTime.Now.ToString("d"));
            //Console.WriteLine(DateTime.Now.ToShortDateString());

            //Console.WriteLine(Calc.Add(50, 50));
            //Console.WriteLine(Calc.ShowNote("Hi"));
            //BackgroundWorker worker = new BackgroundWorker();
            //Monitor mon = new Monitor();
            //int value = 5, value2 = 5;
            //Console.Write(Interlocked.Add(ref value, value2));

            //GetRefAssemblies();
            //string hello = "hello world";
            //GetType(hello);

            Console.ReadKey();
        }

        public static void ch03()
        {
            int myInt = new int();
            int myInt2;
            Console.WriteLine("Value of myInt (default) = {0}", myInt);

            Man man = new Man("James", "Corbs", 40);
            Console.WriteLine("Man speaks: \"{0}\"", man.saysomething());

            Console.WriteLine("Days.Mon = {0}", (int)Days.Mon);
            Console.WriteLine("Days.Tue = {0}", (int)Days.Tue);
            Console.WriteLine("Days.Wed = {0}", (int)Days.Wed);
            Console.WriteLine("Days.Thur = {0}", (int)Days.Thur);
            Console.WriteLine("Days.Fri = {0}", (int)Days.Fri);
            Console.WriteLine("Days.Sat = {0}", (int)Days.Sat);
            Console.WriteLine("Days.Sun = {0}", (int)Days.Sun);
        }

        public static void optional (string lastname, string firstname = "James", int age = 1)
        {
            // Optional parameters must appear AFTER all mandatory parameters to prevent compiler error.
            Man man = new Man("Steve", "Davis", 40);
        }

        class Person
        {
            public string firstName
            {
                get { return String.Format("{0} - {1}", "PERSON", this.firstName); }
                set { firstName = this.firstName; }
            }
        }

        [Serializable]
        class Employee : Person, IComparable, IComparer, IEnumerable, IEnumerator, IDisposable
        {
            public object Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public new string firstName {
                get { return String.Format("{0} - {1}", "EMPLOYEE", this.firstName); }
                set { firstName = this.firstName; }
            }

            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            int IComparer.Compare(object x, object y)
            {
                throw new NotImplementedException();
            }
        }

        class Manager : Employee
        {
            public new string firstName
            {
                get { return String.Format("{0} - {1}", "MANAGER", this.firstName); }
                set { firstName = this.firstName; }
            }
        }

        class TestReflection : System.Attribute
        {
            public string Version { get; set; }
        }

        public static void GetRefAssemblies()
        {
            Assembly asm = Assembly.LoadFile(@"C:\Users\James Corbould\Documents\Projects\ProgrammingCSharp\ProgrammingCSharp\1_1_Multithreading_and_Async\bin\Debug\1_1_Multithreading_and_Async.exe");

            Console.WriteLine("\n\nAssembly name = {0}", asm.FullName);

            Assembly asm2 = Assembly.GetExecutingAssembly();
            Console.WriteLine("\n\nCurrently executing assembly name = {0}", asm2.FullName);


            AssemblyName[] asmNames = asm.GetReferencedAssemblies();

            Console.WriteLine();

            foreach(AssemblyName asmName in asmNames)
            {
                Console.WriteLine(asmName.Name);
            }

            var publicTypes = asm.ExportedTypes;

            // Get all the public types defined in this assembly.
            foreach (TypeInfo info in publicTypes)
            {
                Console.WriteLine(info.Name);
            }

            //Assembly.Load("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            //Assembly.ReflectionOnlyLoad("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            //Assembly.Load(@"C:\Users\James Corbould\Documents\Projects\ProgrammingCSharp\ProgrammingCSharp\1_1_Multithreading_and_Async\bin\Debug\1_1_Multithreading_and_Async.exe");
            //Assembly.LoadFile(@"C:\Users\James Corbould\Documents\Projects\ProgrammingCSharp\ProgrammingCSharp\1_1_Multithreading_and_Async\bin\Debug\1_1_Multithreading_and_Async.exe");
            Assembly assembly = Assembly.Load("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            var table = assembly.CreateInstance("System.Data.DataTable");
            Console.WriteLine("Table Type = {0}", table.GetType());
            Type type = table.GetType();  // returns all the types for this class e.g. methods, fields, properties.

            //foreach (var t in type.GetRuntimeMethods())
            //{
            //    Console.WriteLine(t.Name);
            //}

            Console.WriteLine("Is a Public class? => {0}", type.IsPublic);

            foreach (var f in type.GetFields())
            {
                Console.WriteLine("Field name = {0}", f.Name);
            }

            foreach (var p in type.GetProperties())
            {
                Console.WriteLine("Property name = {0}, property type = {1}", p.Name, p.PropertyType);

                if (p.PropertyType.ToString() == "System.Data.DataColumn[]")
                {
                    Console.Write(" *** This is an array ***");
                }
            }

            assembly.GetType().GetField("bob");

            typeof(Calc).GetCustomAttributes(typeof(DataMappingAttribute), false);

            CodeNamespace codeNamespace = new CodeNamespace("MyNamespace");

            CodeTypeDeclaration dec = new CodeTypeDeclaration("bob");

            CodeMemberField xField = new CodeMemberField();
            xField.Name = "x";
            xField.Type = new CodeTypeReference(typeof(double));
        }

        public static void GetType(Object myParam)
        {
            Type myType = myParam.GetType();
            Console.WriteLine("Object type = {0}", myType.FullName);
        }

        public static void TestFile()
        {
            
        }

        public static void TryFlags()
        {
            Days2 readingDays = Days2.Monday | Days2.Saturday;
            Console.WriteLine(readingDays);
        }

        public static void TryYield()
        {

        }
    }

    internal class DataMappingAttribute
    {
    }
}
