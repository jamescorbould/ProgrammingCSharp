using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public class Event
    {
        public delegate int Calculate(int x, int y);
        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }
        public delegate void Del();
        public delegate TextWriter CovarianceDel();
        public StreamWriter MethodStream() { return null; }
        public StreamWriter MethodString() { return null; }
        public void TestDelegate()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(3, 4));
        }

        public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }

        public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

        public void MulticastDelegate()
        {
            Del d = MethodOne;
            d += MethodTwo;

            d();

            Console.WriteLine("No. of methods that will be called = {0}", d.GetInvocationList().GetLength(0));
        }

        public void CoVariance()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;

            // Both StreamWriter and StringWriter inherit from TextWriter and are therefore **more derived** that the type defined in the delegate.
            // Therefore, this is an example of covariance.
        }

        void DoSomething(TextWriter tw) { }
        public delegate void Contravariance(StreamWriter sw);
        public void ContraVariance()
        {
            Contravariance cv = DoSomething;

            // DoSomething has a type that is **less derived** than that specified in the delegate.
            // Assigning less derived type to the delegate - therefore, is an example of ContraVariance.


        }
    }
}
