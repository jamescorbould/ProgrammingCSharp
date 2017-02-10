﻿using System;
using System.Threading;

namespace _1_1_Multithreading_and_Async
{
    class Threads
    {
        //[ThreadStatic]
        //public static int _field;

        // 
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void ThreadMethod2(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        // A better way to stop a thread is to use a shared variable to signal that processing should stop.
        public static void StopThread()
        {
            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }

        // Each thread can have it's own copy of a variable.
        // Marking a field with the ThreadStatic attribute ensures that each thread will get it's own copy of a field.
        public static void ThreadStatic()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    //_field++;
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    //_field++;
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();

            Console.ReadKey();
        }

        public static void ThPool()
        {
            // Sample showing assignment of a thread from the thread pool, to execute a task.
            // Work is queued pending assignment of a thread from the pool.
            ThreadPool.QueueUserWorkItem((s) =>
                { Console.WriteLine("Working on thread obtained from the thread pool."); });

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();

            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            t2.Start(5);
            t2.Join();

            Console.ReadKey();

            StopThread();

            ThreadStatic();

            ThPool();
        }
    }
}
