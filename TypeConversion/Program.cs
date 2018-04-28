using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassB(); // ClassB derives from ClassA.

            if (a is ClassB) // Returns true or false.
            {
                // Convert explicitly from type ClassA to ClassB.
                // Throws a casting exception if invalid; use "is" to check whether a type is convertible or not.
                ClassB b = (ClassB)a;
            }

            FahrenheitTemperature ft = new FahrenheitTemperature { Temperature = 32 };
            Console.WriteLine("Fahrenheit temp = {0}", ft.Temperature);
            CelsiusTemperature ct = ft; // Convert fahrenheit to celsius implicitly.
            Console.WriteLine("Celsius temp = {0}", ct.Temperature);
            Console.ReadKey();
        }
    }
}
