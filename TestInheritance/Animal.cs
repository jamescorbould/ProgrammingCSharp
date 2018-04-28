using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInheritance
{
    class Animal
    {
        public int Legs { get; set; }
        public string Diet { get; set; }

        private string _colour = String.Empty;

        public string Colour
        {
            get; private set;
        }

        public Animal(int legs, string diet)
        {
            Legs = legs * 2;
            Diet = diet;
        }
    }
}
