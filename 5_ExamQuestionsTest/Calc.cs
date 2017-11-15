using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // Debug is only available with debug builds.
            // ConditionalAttribute with a value of DEBUG is applied to the Debug class, hence why Debug is only called when using debug builds.
            Debug.WriteLine("Debug #1");  // Writes the error message to VS output window.

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
                Console.WriteLine(i);  // No exception is thrown and int is set to -2147483648, which is max size for an int.
            }
        }

        public static void TestDisableWarning()
        {
#pragma warning disable
            // Unreachable code detected warning is suppressed due to pragma directive.
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore
        }
    }
}
