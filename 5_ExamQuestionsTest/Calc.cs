using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_ExamQuestionsTest
{
    static class Calc
    {
        static Func<int, int, int> Calculate;  // 2 x int parameters and return type of int.
        static Func<float, float> F;
        static Action note;

        public static int Add(int x, int y)
        {
            Calculate = delegate (int x2, int y2) { return x2 + y2; };
            return Calculate.Invoke(x, y);
        }

        public static void ShowNote(string msg)
        {
            note = () => Console.WriteLine(msg);
        }

        public static void TestChecked()
        {
            int i = 0;
            double d = double.MaxValue;

            try
            {
                // Check for buffer overflow for the int.
                checked
                {
                    i = (int)d;
                    Console.WriteLine(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e.Message);  // Arithmetic operation resulted in an overflow.
            }

            unchecked
            {
                i = (int)d;
                Console.WriteLine(i);  // No exception is thrown and int is set to -2147483648.
            }
        }
    }
}
