using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Animal
    {
        public virtual void MakeANoise() // Virtual means may be overridden by child class or child can inherit the base class definition.
        {
            Console.WriteLine("Animal roar");
        }
    }

    class Cat : Animal
    {
        public override void MakeANoise()
        {
            base.MakeANoise();
        }
    }

    class Dog : Animal
    {
        public override void MakeANoise()
        {
            Console.WriteLine("Woof");
        }
    }
}
