using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    public static class DelegateTest
    {
        public delegate string Combine(string s1, string s2);
        public delegate void show(string msg);

        public static void display(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void emptyMethod()
        {
            Console.WriteLine("Empty Method.");
        }

        public static void voidMethod()
        {
            Console.WriteLine("Void Method.");
        }

        static void myintMethod(int i)
        {
            Console.WriteLine("myintMethod: i = {0}", i);
        }
        static void myintStringMethod(int i, string s)
        {
            Console.WriteLine("myintStringMethod: i = {0} s = {1}", i, s);
        }

        public static string test(string s, string ss)
        {
            Combine combine = delegate (string s1, string s2) { return s1 + s2; }; // Remember need to include types in the delegate parameters!!
            show show = new show(display);

            // Call the delegate.
            show(string.Format("{0} {1}", s, ss));

            return combine(s, ss);
        }

        public static void testActionDelegate()
        {
            // Action delegate doesn't return a vlaue and not require any input parameters.
            Action action = emptyMethod;
            action += voidMethod;

            action();
        }

        public static int Add(int x, int y) => x + y;
        

        public static int Sub(int x, int y) => x - y;

        public static void testGenericActionDelegate()
        {
            // Action<> generic delegate can pass in up to 16 parameters but can't return a type.
            Action<int> myIntAct = myintMethod;
            Action<int, string> myIntStringAct = myintStringMethod;
            myIntAct(22);
            myIntStringAct(22, "Ali");
        }

        public static void testFunc()
        {
            Func<int, int, int> myFunc = (x,y) => x + y ;
            Console.WriteLine(myFunc(1, 1));
        }

        public static void testPredicate()
        {
            Predicate<int> isEven = (x) => x % 2 == 0;
            Console.WriteLine(isEven(2));
        }
    }
}
