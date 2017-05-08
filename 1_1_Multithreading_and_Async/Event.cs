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

        public class Pub
        {
            public Action OnChange { get; set; }

            public void Raise()
            {
                if (OnChange != null)
                {
                    OnChange();
                }
            }
        }

        public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.OnChange = () => Console.WriteLine("Accidently removed subscriptions of methods 1 & 2");  // Accidently have used assignment operator.
            p.Raise();

            // The Pub class is unaware of any subscribers, it just raises the event.
            // If no subscribers to an event, the OnChange property would be null.
        }

        public class Pub2
        {
            public event Action OnChange = delegate { };

            public void Raise()
            {
                OnChange();
            }
        }

        public void CreateAndRaise2()
        {
            Pub2 p2 = new Pub2();
            p2.OnChange += () => Console.WriteLine("Event raised to method 1");
            p2.OnChange += () => Console.WriteLine("Event raised to method 2");
            //p2.OnChange = () => Console.WriteLine("Accidently removed subscriptions of methods 1 & 2");  // Accidently have used assignment operator.  **But** prevented when use Event keyword.
            p2.Raise();

            // The Pub class is unaware of any subscribers, it just raises the event.
            // If no subscribers to an event, the OnChange property would be null.
        }

        public class MyArgs : EventArgs
        {
            public int Value { get; set; }
            public MyArgs(int value)
            {
                Value = value;
            }
        }

        public class Pub3
        {
            public event EventHandler<MyArgs> OnChange = delegate { };

            public void Raise()
            {
                OnChange(this, new MyArgs(42));
            }
        }

        public void CreateAndRaise3()
        {
            Pub3 p3 = new Pub3();

            p3.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);

            p3.Raise();
        }

        public class Pub4
        {
            public event EventHandler OnChange = delegate { };
            public void Raise()
            {
                OnChange(this, EventArgs.Empty);
            }
        }

        public void CreateAndRaise4()
        {
            Pub4 p = new Pub4();

            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e) => { throw new Exception(); };
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");  // This subscriber is never called, since exception thrown for previous sender.

            p.Raise();
        }

        public class Pub5
        {
            public event EventHandler OnChange = delegate { };
            public void Raise()
            {
                var exceptions = new List<Exception>();

                foreach (Delegate handler in OnChange.GetInvocationList())
                {
                    try
                    {
                        // By handling the exception each time, ensure that all subscribers are notified, even if an exception is thrown.
                        handler.DynamicInvoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }

                if (exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }
            }
        }

        public void CreateAndRaise5()
        {
            Pub5 p5 = new Pub5();

            p5.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p5.OnChange += (sender, e) => { throw new Exception(); };
            p5.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

            try
            {
                p5.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }
    }
}
