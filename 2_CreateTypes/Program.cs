using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

            //EnumTest.Colours mix = EnumTest.Colours.Blue | EnumTest.Colours.Green;
            // 0x00010000
            // 0x00000100
            // 0x00010100 => mix now represents blue and green.
            //Console.WriteLine("mix = {0}", mix);

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

            //Distance d1 = new Distance { metre = 10 };
            //Distance d2 = new Distance { metre = 20 };

            //if (d1 < d2)
            //{
            //    Console.WriteLine("d1 < d2");
            //}
            //else if (d2 < d1)
            //{
            //    Console.WriteLine("d2 < d1");
            //}

            //Cat c = new Cat();
            //c.MakeANoise();

            //Dog d = new Dog();
            //d.MakeANoise();

            //Transformer t = new Transformer();
            //string input = String.Empty;

            //while (input.ToUpper() != "X")
            //{
            //    input = Console.ReadLine();

            //    switch (input)
            //    {
            //        case "Air":
            //            t = new Jet();
            //            break;
            //        case "Sea":
            //            t = new Boat();
            //            break;
            //        case "Train":
            //            t = new Train();
            //            break;
            //        case "X":
            //            break;
            //        default:
            //            t = new Transformer();
            //            break;
            //    }

            //    Console.WriteLine(t.Run());
            //}

            //GenericClass<SuperHero, string> genericClass = new GenericClass<SuperHero, string>(new SuperHero { AliasName = "Superman", CanFly = true }, "James");
            ////GenericClass<int, string> genericClass = new GenericClass<int, string>();
            //Console.WriteLine(genericClass.ToString());

            //Person<SuperHero> person = new Person<SuperHero>(new SuperHero { AliasName = "Superman", CanFly = true });
            ////Person<SuperHero> person = new Person<SuperHero>();
            //Console.WriteLine(person.ToString());
            //person.MultipleGenericMethodArgs("Bob", "Smith");

            //var result = person.ReturnFromMultipleGenericMethodArgs<int, int>(10);
            //Console.WriteLine("var result = {0}", result);

            //var result2 = person.ReturnFromGenericValueType<int>(40); // Generic method constraint - must be a value type.
            //Console.WriteLine("var result2 = {0}", result2);

            //// Angle brackets not needed for a generic method - example:
            //var result3 = person.ReturnFromGenericValueType(40); // Generic method constraint - must be a value type.
            //Console.WriteLine("var result3 = {0}", result3);

            // Will give a complier error since arg must be a value type and string is a ref type.
            //var result3 = person.ReturnFromGenericValueType<string>("bob"); // Generic method constraint - must be a value type.
            //Console.WriteLine("var result2 = {0}", result2);

            //var person = new Person { name = "Bob", age = 29 }
            //var person = new { name = "Bob", age = 29 }; // Anon type - defined inline type, no need to create a class.
            //Console.WriteLine("person name = {0}, type = {1}", person.name, person.GetType());

            //List<string> list = new List<string> { "Bob", "Jane" };

            //foreach (var thing in list)
            //{
            //    var name = thing;
            //    Console.WriteLine("name = {0}", name.ToString());
            //}

            //dynamic myDynamicVar;
            //myDynamicVar = "Bob";

            //Console.WriteLine("dynamic variable = {0}, type = {1}", myDynamicVar, myDynamicVar.GetType());

            //myDynamicVar = 10;

            //Console.WriteLine("dynamic variable = {0}, type = {1}", myDynamicVar, myDynamicVar.GetType());

            //myDynamicVar = true;

            //try
            //{
            //    if (myDynamicVar == "Bob")
            //    {
            //        Console.WriteLine("hi bob");
            //    }
            //    else
            //    {
            //        Console.WriteLine("no bob here");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("an error occured" + ex.Message);
            //    throw;
            //}

            //ArrayList list = new ArrayList();
            //list.Add(new SuperHero { AliasName = "Superman", CanFly = false, Age = 23 });
            //list.Add(new SuperHero { AliasName = "Batman", CanFly = true, Age = 11 });
            //list.Add(new SuperHero { AliasName = "X-Man", CanFly = true, Age = 81 });
            //list.Add(new SuperHero { AliasName = "Wolverine", CanFly = false, Age = 4 });
            //list.Sort();

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            //list.Sort(new SortByAge());
            //Console.WriteLine("\n");

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            //list.Sort(new SortByName());
            //Console.WriteLine("\n");

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            //List<SuperHero> list = new List<SuperHero>();
            //list.Add(new SuperHero { AliasName = "Superman", CanFly = false, Age = 23 });
            //list.Add(new SuperHero { AliasName = "Batman", CanFly = true, Age = 11 });
            //list.Add(new SuperHero { AliasName = "X-Man", CanFly = true, Age = 81 });
            //list.Add(new SuperHero { AliasName = "Wolverine", CanFly = false, Age = 4 });
            //list.Sort();

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            //list.Sort(new SortByAge());
            //Console.WriteLine("\n");

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            //list.Sort(new SortByName());
            //Console.WriteLine("\n");

            //foreach (SuperHero hero in list)
            //{
            //    Console.WriteLine("Super Hero Name = {0}, Can Fly = {1}, Age = {2}", hero.AliasName, hero.CanFly, hero.Age);
            //}

            // Test for equality.
            //SuperHero hero1 = new SuperHero { AliasName = "Bob", Age = 40, CanFly = true };
            //SuperHero hero2 = new SuperHero { AliasName = "Terry", Age = 10, CanFly = false };
            //SuperHero hero3 = new SuperHero { AliasName = "Bob", Age = 40, CanFly = true };

            //Console.WriteLine(hero1 == hero2);
            //Console.WriteLine(hero1 == hero3);

            //MyList<SuperHero> myList = new MyList<SuperHero>();
            //myList.Add(new SuperHero { AliasName = "Superman", CanFly = false });
            //myList.Add(new SuperHero { AliasName = "Batman", CanFly = true });
            //myList.Add(new SuperHero { AliasName = "X-Man", CanFly = true });
            //myList.Add(new SuperHero { AliasName = "Wolverine", CanFly = false });

            //Console.WriteLine("\n");

            //foreach (var hero in myList)
            //{
            //    Console.WriteLine("Super Hero = {0}", hero.AliasName);
            //}

            //People peeps = new People(3);
            //peeps.Add(new SuperHero { AliasName = "Superman", CanFly = true });
            //peeps.Add(new SuperHero { AliasName = "Batman", CanFly = true });
            //peeps.Add(new SuperHero { AliasName = "X-Man", CanFly = false });

            //Console.WriteLine("\n");

            //foreach (var obj in peeps)
            //{
            //    SuperHero superHero = (SuperHero)obj;
            //    Console.WriteLine("Super Hero in custom coll = {0}", superHero.AliasName);
            //}

            // Append to a string.
            // The CLR will create a new string each time and assign the string pointer to the new string on the heap.
            // Since strings are immutable.
            // Therefore it is inefficient to modify and work with strings in this way, using System.String.
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            //string mystring = "test";

            //for (int i = 1; i < 100000; i++)
            //{
            //    mystring += i;
            //}

            ////Stop Recording time
            //watch.Stop();

            //float miliToSec = watch.ElapsedMilliseconds / 1000;

            //Console.WriteLine("Total time: {0}s", miliToSec);

            //Console.ReadKey();

            StringTest.TestStringFormat();
            StringTest.TestStringFormatting();

            int acctNumber = 79203159;

            Console.WriteLine(String.Format(new CustomerFormatter(), "{0}", acctNumber));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:G}", acctNumber));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:S}", acctNumber));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:P}", acctNumber));

            try
            {
                Console.WriteLine(String.Format(new CustomerFormatter(), "{0:X}", acctNumber));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

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
