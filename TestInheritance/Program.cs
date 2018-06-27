using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal(4, "Biscuits");
            Console.WriteLine(animal.ToString());

            Animal animal2 = new Animal(null, "Meat");
            Console.WriteLine(animal2.ToString());

            Console.ReadKey();
        }
    }
}
