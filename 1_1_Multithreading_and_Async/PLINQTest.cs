using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public static class PLINQTest
    {
        public static void RunParallel()
        {
            var numbers = Enumerable.Range(0, 100);
            var parallelResult = numbers.AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(8)
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (var i in parallelResult)
            {
                Console.Write(i + ",");
            }
        }
    }
}
