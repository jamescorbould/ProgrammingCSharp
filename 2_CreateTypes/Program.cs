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
            //Console.WriteLine(NamedParameters(lastName: "Corbould", firstName: "James")); // Specify named parameters so can be ref out of order.
            //Console.WriteLine(MultOptionalParameter(5));

            //int j = 0;
            //IntByRef(ref j); // Pass memory address of j, not it's actual value.
            //Console.WriteLine("j = {0}", j);

            //int i = 0;
            //Sum(out i);
            //Console.WriteLine("i = {0}", i);

            //int[] array = { 1, 40, 36, 4 };
            //int total = SumAll(array);
            //Console.WriteLine("Sum total = {0}", total);

            //Console.WriteLine("(byte)EnumTest.Status.Alive = {0}", (byte)EnumTest.Status.Alive);
            //Console.WriteLine("EnumTest.Status.Alive = {0}", EnumTest.Status.Alive);

            //EnumTest.BorderSides leftRight = EnumTest.BorderSides.Left | EnumTest.BorderSides.Right;
            //Console.WriteLine("leftRight = {0}", leftRight);

            EnumTest.Colours mix = EnumTest.Colours.Blue | EnumTest.Colours.Green;
            // 0x00010000
            // 0x00000100
            // 0x00010100 => mix now represents blue and green.
            Console.WriteLine("mix = {0}", mix);

            //DynamicTest.Test();

            //string name = "James Rupert Corbould";
            //Console.WriteLine("name world count using extension method = {0}", name.WordCount());

            //int age = 40;
            //Console.WriteLine("age.IsLessThan(60) = {0}", age.IsLessThan(60));  // Call extension method on int.

            //string city = "Auckland";
            //Console.WriteLine("city.First(\"Auckland\") = {0}", city.First<char>());

            //Vehicle vehicle = new Bike();
            //Console.WriteLine("Bike num of wheels = {0}", vehicle.wheels);

            //IVehicle truck = new Truck();
            //Console.WriteLine("Truck wheels = {0}", truck.wheels);

            //Student student = new Student();
            //Console.WriteLine("((IEnglish)student).Marks = {0}", ((IEnglish)student).Marks);
            //Console.WriteLine("((IMaths)student).Marks = {0}", ((IMaths)student).Marks);

            // Example of custom operator overloading.
            //Distance d = new Distance();
            //Console.WriteLine("d.metre = {0}", d.metre);
            //d++;
            //Console.WriteLine("d.metre = {0}", d.metre);

            //Pupil p1 = new Pupil();
            //Pupil p2 = new Pupil();
            //p1.marks = 55;
            //p2.marks = 75;
            //p1 = p1 + p2;
            //Console.WriteLine("p1.marks = {0}", p1.marks);

            Distance d1 = new Distance { metre = 10 };
            Distance d2 = new Distance { metre = 20 };

            if (d1 < d2)
            {
                Console.WriteLine("d1 < d2");
            }
            else if (d2 < d1)
            {
                Console.WriteLine("d2 < d1");
            }

            Cat c = new Cat();
            c.MakeANoise();

            Dog d = new Dog();
            d.MakeANoise();

            Console.ReadKey();
        }

        public static void NullTest()
        {
            //int i = null; // Fails since value types cannot be null.
            int? i = null; // Using nullable, int can now be null.
            Nullable<int> x = null; // Alternative.  Can be simplified to the above.
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
