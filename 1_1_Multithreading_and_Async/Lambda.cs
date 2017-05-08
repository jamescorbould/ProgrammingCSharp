using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _1_1_Multithreading_and_Async.Event;

namespace _1_1_Multithreading_and_Async
{
    public static class Lambda
    {
        public static void TestLambda()
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));
        }

        public static void MultipleStatementsLambda()
        {
            Calculate calc = (x, y) =>
            {
                Console.WriteLine("Adding numbers");
                return x + y;
            };

            int result = calc(3, 4);
        }

        public static void BuiltInDelegates()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            calc(3, 4);
        }
    }
}
