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

            //string s = "James Corbould";
            //Console.WriteLine("string '{0}' wordcount = {1}", s, s.WordCount());  // Call extension method on string.

            //ArrayTest.MultiDimArrayTest();
            //ArrayTest.JaggedArrayTest();
            //TestNullCoalescingOp();
            Console.WriteLine(NamedParameters(lastName: "Corbould", firstName: "James")); // Specify named parameters so can be ref out of order.
            Console.WriteLine(MultOptionalParameter(5));

            int j = 0;
            IntByRef(ref j); // Pass memory address of j, not it's actual value.
            Console.WriteLine("j = {0}", j);

            int i = 0;
            Sum(out i);
            Console.WriteLine("i = {0}", i);

            int[] array = { 1, 40, 36, 4 };
            int total = SumAll(array);
            Console.WriteLine("Sum total = {0}", total);
            
            Console.ReadKey();
        }

        public static void TestNullCoalescingOp()
        {
            // Returns left-hand variable if it’s not null; otherwise, it
            // returns a default value stored in a right-hand variable.
            string name = null;
            Console.WriteLine("Hello {0}", name ?? "user"); // If name is null, then print "user".
        }

        public static string NamedParameters(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public static int MultOptionalParameter(int x, int y = 10) // Variable y defaults to 10 if not specified.
        {
            return x * y;
        }

        public static void IntByRef(ref int i)
        {
            i++;
        }

        public static void Sum(out int j)
        {
            j = 1;
        }

        public static int SumAll(params int[] args) // Params allows unlimited number of args to be sent to a method.
        {
            int total = 0;

            foreach(int i in args)
            {
                total += i;
            }

            return total;
        }
    }
}
