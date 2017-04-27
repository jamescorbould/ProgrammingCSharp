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
        static int value = 1;

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

        public static void CompareAndExchangeNonAtomic()
        {
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output.
                    Thread.Sleep(1000);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
        }

        public static void CompareAndExchangeAtomic()
        {
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change the output.
                    Thread.Sleep(1000);
                    Interlocked.CompareExchange(ref value, 2, 1);
                    //value = 2;
                }
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
        }

        public static void CancelTask()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationTokenSource.Cancel();

            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

        public static void CancelTaskEx()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                t.Exception.Handle((e) => true);
                Console.WriteLine("You have cancelled the task.");
            }, TaskContinuationOptions.OnlyOnCanceled);

            //try
            //{
            //    Console.WriteLine("Press enter to stop the task.");
            //    Console.ReadLine();

            //    cancellationTokenSource.Cancel();
            //    task.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine(e.InnerExceptions[0].Message);
            //}
            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }

        public static void TimeoutTask()
        {
            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });

            int index = Task.WaitAny(new[] { longRunning }, 1000);  // Wait on an array of inline tasks for 1 sec.

            if (index == -1)
            {
                Console.WriteLine("Task timed out ");
            }
        }
    }
}
