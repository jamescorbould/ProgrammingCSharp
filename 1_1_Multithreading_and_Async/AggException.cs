using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public static class AggException
    {
        public static void TestAggException()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There were {0} exceptions", e.InnerExceptions.Count);
            }
        }

        private static bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }

            return i % 2 == 0;
        }
    }
}
