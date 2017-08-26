using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_ExamQuestionsTest
{
    partial class Program
    {
        enum Days { Mon = 1, Tue, Wed, Thur, Fri, Sat, Sun };
        static void Main(string[] args)
        {
            ch03();
            optional(lastname: "Corbs", age: 40);

            decimal total = 1234.56M;
            Console.WriteLine(String.Format("{0:C}", total));
            Console.WriteLine(total.ToString("c"));

            Person alice = new Employee();
            Person brett = new Manager();
            //Employee bob = new Person();
            //Manager cindy = new Employee();
            //Manager dan = (Manager)(new Employee());
            
            Console.WriteLine(Convert.ChangeType(3.14F, TypeCode.Int32));

            //BitConverter.ToInt16()
            Byte[] bytes = BitConverter.GetBytes(40);

            Console.WriteLine(string.Join(" ", new List<string> { "James", "Ben", "Lockie" }));

            Console.WriteLine(DateTime.Now.ToString("D"));
            Console.WriteLine(DateTime.Now.ToString("d"));
            Console.WriteLine(DateTime.Now.ToShortDateString());

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
    }
}
