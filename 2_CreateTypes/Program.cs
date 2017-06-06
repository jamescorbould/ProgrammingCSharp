using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Product p = new Product()
            {
                Price = 100M
            };

            Console.WriteLine("Product price = {0}", p.Price);
            Console.WriteLine("Product discounted price = {0}", calc.CalculateDiscount(p));

            Derived d = new Derived();
            Derived d2 = new Derived2();

            Console.WriteLine(d.MyMethod());
            Console.WriteLine(d2.MyMethod());

            Money m = new Money(42.42M);
            decimal amount = m;  // Implicit conversion.
            Console.WriteLine(amount);
            int truncatedAmount = (int)m;  // Explicit conversion (casting).
            Console.WriteLine(truncatedAmount);

            Console.ReadKey();
        }
    }
}
