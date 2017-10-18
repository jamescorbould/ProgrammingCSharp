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
            //Calculator calc = new Calculator();
            //Product p = new Product()
            //{
            //    Price = 100M
            //};

            //Console.WriteLine("Product price = {0}", p.Price);
            //Console.WriteLine("Product discounted price = {0}", calc.CalculateDiscount(p));

            //Derived d = new Derived();
            //Derived d2 = new Derived2();

            //Console.WriteLine(d.MyMethod());
            //Console.WriteLine(d2.MyMethod());

            //Money m = new Money(42.42M);
            //decimal amount = m;  // Implicit conversion.
            //Console.WriteLine(amount);
            //int truncatedAmount = (int)m;  // Explicit conversion (casting).
            //Console.WriteLine(truncatedAmount);

            //List<Order> orders = new List<Order>
            //{
            //    new Order { Created = new DateTime(2016, 6, 19) },
            //    new Order { Created = new DateTime(2014, 6, 19) },
            //    new Order { Created = new DateTime(2017, 6, 19) },
            //    new Order { Created = new DateTime(2011, 6, 19) }
            //};

            //foreach (Order o in orders)
            //{
            //    Console.WriteLine(o.Created.ToString());
            //}

            //orders.Sort();
            //Console.WriteLine();

            //foreach (Order o in orders)
            //{
            //    Console.WriteLine(o.Created.ToString());
            //}

            //Reflection.OutputSomeCodeUsingReflection();

            //Reflection.Funcky();


            //DigitType d = new DigitType(4);
            //byte b = d;  // implicit conversion -- no cast needed.

            //Console.WriteLine(d);

            //Console.WriteLine(b);

            //Car car1 = new Car(make: "Honda", model: "Odyessey", year: "2005");
            //Car car2 = new Car(make: "Honda", model: "Odyessey", year: "2005");
            //Car car3 = new Car(make: "Toyota", model: "Corolla", year: "2005");

            //Console.WriteLine("car1 == car2 => {0}", car1.Equals(car2));
            //Console.WriteLine("car2 == car3 => {0}", car2.Equals(car3));

            //Console.Write(DelegateTest.test("hello", "world"));

            //ThreadTest.Test();

            //Book book = new Book("The Hobbit");

            string s = "James Corbould";
            Console.WriteLine("string '{0}' wordcount = {1}", s, s.WordCount());  // Call extension method on string.


            Console.ReadKey();
        }
    }
}
