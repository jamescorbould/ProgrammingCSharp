using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class ControlStatements
    {
        // Test cannot change a reference variable when using a foreach - it is readonly.
        // Variable is strongly typed.
        public static void TestForEachCannotChange()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName="Doe" },
                new Person() { FirstName = "Jane", LastName="Doe" },
            };

            foreach (Person p in people)
            {
                p.LastName = "Changed"; // This is allowed.
                //p = new Person(); // This give a compile error.
            }
        }

        // Foreach is readonly since foreach is syntactic sugar for the following logic.
        // If change reference, then enumerator won't be able to find the next object in the collection - 
        // hence the object reference is readonly.
        public static void TestEnumeratorForEach()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName="Doe" },
                new Person() { FirstName = "Jane", LastName="Doe" },
            };

            List<Person>.Enumerator e = people.GetEnumerator();

            try
            {
                Person v;
                while (e.MoveNext())
                {
                    v = e.Current;  // If change value for v, then enumerator will not be able to locate next object in the collection.
                }
            }
            finally
            {
                System.IDisposable d = e as System.IDisposable;
                if (d != null)
                {
                    d.Dispose();
                }
            }
        }
    }
}
