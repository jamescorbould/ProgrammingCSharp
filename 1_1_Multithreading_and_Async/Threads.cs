using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

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

        public static void RunTask()
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write('*');
                }
            });

            t.Wait();
        }

        public static void RunTaskReturn()
        {
            Task<int> t = Task.Run(() =>
            {
                return 39;
            });

            Console.WriteLine(t.Result);
        }

        public static void RunTaskContinuationReturn()
        {
            Task<int> t = Task.Run(() =>
            {
                return 39;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.WriteLine(t.Result);
        }

        // Attaching child tasks to a parent task.
        public static void RunChildTasks()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                    TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                });

            finalTask.Wait();
        }

        public static void TaskFactoryDemo()
        {
            object _lockObj = new object();

            lock (_lockObj)
            {
                Task<Int32[]> parent = Task.Run(() =>
                {
                    var results = new Int32[3];

                    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                    tf.StartNew(() => results[0] = 0);
                    tf.StartNew(() => results[1] = 1);
                    tf.StartNew(() => results[2] = 2);

                    return results;
                });

                var finalTask = parent.ContinueWith(
                    parentTask =>
                    {
                        foreach (int i in parentTask.Result)
                            Console.WriteLine(i);
                    });

                finalTask.Wait();
            }
        }

        public static void TaskWaitAllDemo()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
        }

        public static void TaskWaitAnyDemo()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }

        public static void ParallelDemo()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }

        public static void ParallelDemoBreak()
        {
            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }

                return;
            });
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }

        public Task SleepAsyncA(int millisecondsTimeout)
        {
            // This uses a thread from the thread pool while sleeping.
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            // Does not occupy a thread while waiting for the timer to run.
            // Gives scalability.
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }

        static void Main(string[] args)
        {
            //Thread t = new Thread(new ThreadStart(ThreadMethod));
            //t.Start();

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Main thread: Do some work.");
            //    Thread.Sleep(0);
            //}

            //t.Join();

            //Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            //t2.Start(5);
            //t2.Join();

            //Console.ReadKey();

            //StopThread();

            //ThreadStatic();

            //ThPool();

            //RunTask();
            //Console.ReadKey();

            //RunTaskReturn();
            //RunTaskContinuationReturn();
            //RunChildTasks();
            //TaskFactoryDemo();
            //TaskWaitAllDemo();
            //TaskWaitAnyDemo();

            //ParallelDemoBreak();

            //string result = DownloadContent().Result;
            //Console.WriteLine(result);

            //PLINQTest.RunParallel();

            AggException.TestAggException();

            Console.ReadKey();
        }
    }
}
