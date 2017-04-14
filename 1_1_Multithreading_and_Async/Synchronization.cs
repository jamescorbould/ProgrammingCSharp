using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public static class Synchronization
    {
        public static void TestLocking()
        {
            int result = 0;
            object _obj = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock(_obj)
                    {
                        result++;
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock(_obj)
                {
                    result--;
                }
            }

            up.Wait();
            Console.WriteLine("_result = {0}", result);
        }

        public static void TestDeadlock()
        {
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A & B");
                    }
                }
            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B & A");
                }
            }
            up.Wait();
        }

        public static void TestInterlocking()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();
            Console.WriteLine(n);
        }
    }
}
