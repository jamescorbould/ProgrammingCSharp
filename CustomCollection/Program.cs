using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<string> coll = new CustomCollection<string>();
            coll.Add("Bob");
            Console.WriteLine(coll.test());
            Console.WriteLine(coll.Contains<string>("bob"));
            Console.ReadKey();
        }

        
    }
}
