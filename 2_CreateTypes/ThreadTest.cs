using System;
using System.Threading;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class ThreadTest
    {
        /// <summary>
        /// Demonstrates:
        ///     ThreadLocal(T) constructor
        ///      ThreadLocal(T).Value
        ///      One usage of ThreadLocal(T)
        /// </summary>
        /// <remarks>
        /// Each Action will be assigned a unique instance of a thread.  Each thread will access the same static instance.
        /// The thread will not be shared amongst the instances.
        /// </remarks>
        public static void Test()
        {
            // Thread-Local variable that yields a name for a thread
            ThreadLocal<string> ThreadName = new ThreadLocal<string>(() =>
            {
                return "Thread" + Thread.CurrentThread.ManagedThreadId;
            });

            // Action that prints out ThreadName for the current thread
            Action action = () =>
            {
                // If ThreadName.IsValueCreated is true, it means that we are not the
                // first action to run on this thread.
                bool repeat = ThreadName.IsValueCreated;

                Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, repeat ? "(repeat)" : "");
            };

            // Launch eight of them.  On 4 cores or less, you should see some repeat ThreadNames
            Parallel.Invoke(action, action, action, action, action, action, action, action);

            // Dispose when you are done
            ThreadName.Dispose();
        }
    }
}