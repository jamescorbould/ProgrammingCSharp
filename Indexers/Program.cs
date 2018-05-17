using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    using System;

    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }

    class Temperature
    {
        private float[] weekTemp = { 47.5F, 40.0F, 52.5F, 45.5F, 48.0F, 38.0F, 35.7F };
        private string[] weekTemp2 = { "bob" };

        // Define an indexer property that encapsulates the float array and allows the array to be accessed safely.
        public float this[int index]
        {
            get
            {
                if (index >= 0 && index < weekTemp.Length)
                {
                    return weekTemp[index];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value > 0)
                {
                    weekTemp[index] = value;
                }
                else
                {
                    Console.WriteLine("Please set value greater than 0");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            //var stringCollection = new SampleCollection<string>();
            //stringCollection[0] = "Hello, World";
            //Console.WriteLine(stringCollection[0]);

            Temperature temps = new Temperature();
            temps[6] = 30.0F;
            temps[0] = 0F;

            Console.ReadKey();
        }
    }
    // The example displays the following output:
    //       Hello, World.
}
