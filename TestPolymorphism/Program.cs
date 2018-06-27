using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Pilot();
            p.Shoesize = 0;
            Pilot pi = new Pilot();
            pi.Shoesize = 1;
            //Pilot pi2 = new Person();
        }
    }
}
