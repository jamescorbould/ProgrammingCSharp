using System;
using System.Diagnostics;

namespace _3_DebugApps_And_Implement_Security
{
    public static class DebugAndTrace
    {
        static void Main(string[] args)
        {
            //testDebug();
            //testTrace();
            //PerfCounters();
            //IncrementCustomCounters();
            //Stream.FilestreamTest();
            //Stream.StreamWriterTest();
            //Stream.ReadFileStream();
            //Stream.ReadFileStreamStreamReader();
            //Stream.DecoratorPatternStreams();
            //Stream.TestWebRequest();
            //Stream.CreateAndWriteAsyncToFile();
            Stream.SequentialCalls();
            Stream.ParallelCalls();
            Console.ReadKey();
        }
        public static void TestDebug()
        {
            // Output will be return to the Output window in Visual Studio.
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");
        }

        public static void TestTrace()
        {
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);

            traceSource.TraceInformation("Tracing application...");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });

            traceSource.Flush();
            traceSource.Close();
        }

        public static void PerfCounters()
        {
            Console.WriteLine("Press escape key to stop");

            using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

        public static void IncrementCustomCounters()
        {
            if (CreatePerfCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationsCounter = new PerformanceCounter(
                "JCCategory",
                "# operations executed",
                "",
                false);
            var operationsPerSecondCounter = new PerformanceCounter(
                "JCCategory",
                "# operations / sec",
                "",
                false);

            do
            {
                totalOperationsCounter.Increment();
                operationsPerSecondCounter.Increment();
            }
            while (1 == 1);
        }

        public static bool CreatePerfCounters()
        {
            if (!PerformanceCounterCategory.Exists("JCCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData(
                        "# operations executed",
                        "Total number of operations executed",
                        PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(
                        "# operations / sec",
                        "Number of operations executed per second",
                        PerformanceCounterType.RateOfCountsPerSecond32)
                };

                PerformanceCounterCategory.Create("JCCategory", "JCCategoryHelp", PerformanceCounterCategoryType.SingleInstance, counters);

                return true;
            }

            return false;
        }
    }
}
