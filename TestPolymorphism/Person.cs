using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPolymorphism
{
    abstract class Person // Written by Team A.
    {
        abstract public string Name { get; set; } // Must override.
        abstract public int Age { get; set; }

        public virtual int Shoesize { get; set; } // Can override.
    }

    class Pilot : Person
    {
        public override string Name { get ; set; }
        public override int Age { get; set; }

        public new int Shoesize { get; set; }
    }
}
