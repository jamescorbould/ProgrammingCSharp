using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace _1_1_Multithreading_and_Async
{
    public class ConcurrentCollectionTest
    {
        public static void BlockingCollectionTest()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();

            //Task read = Task.Run(() =>
            //    {
            //        while (true)
            //        {
            //            Console.WriteLine(col.Take());
            //        }
            //    });

            Task read = Task.Run(() =>
                {
                    foreach (string v in col.GetConsumingEnumerable()) { Console.WriteLine(v); }
                });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        break;
                    }
                    col.Add(s);
                }
            });

            write.Wait();
        }

        public static void ConcurrentBagTest()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;

            if (bag.TryTake(out result))
            {
                Console.WriteLine(result);
            }

            if (bag.TryPeek(out result))
            {
                Console.WriteLine("There is a next item: {0}", result);
            }
        }

        public static void ConcurrentBagIterateTest()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                foreach(int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }

        public static void ConcurrentStackTest()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
            {
                Console.WriteLine("Popped: {0}", result);
            }

            stack.PushRange(new int[] { 1, 2, 3});

            int[] values = new int[2];
            stack.TryPopRange(values); // Items popped from the stack will be added to the values array.

            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }

        public static void ConcurrentDictionaryTest()
        {
            var dict = new ConcurrentDictionary<string, int>();

            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 has been updated to 21");
            }

            dict["k1"] = 42; // Overwrite unconditionally.

            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);
        }
    }
}
