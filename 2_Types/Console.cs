using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Types
{
    class Console
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Product p = new Product();
            p.Price = 100M;

            Console.WriteLine("Product price = {0}", p.Price);
            calc.CalculateDiscount(p);
        }
    }
}
