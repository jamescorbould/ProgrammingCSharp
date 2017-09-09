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
    }
}
