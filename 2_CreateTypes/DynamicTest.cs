using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    public static class DynamicTest
    {
        public static void Test()
        {
            // Dynamic variable can be reused to hold different values e.g. string and then int.
            dynamic i = "James";
            Console.WriteLine(i.GetType());
            i = 22;
            Console.WriteLine(i.GetType());
        }
    }
}
