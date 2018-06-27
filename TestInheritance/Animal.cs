using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInheritance
{
    class Animal
    {
        public int? Legs { get; set; }
        public string Diet { get; set; }

        private string _colour = String.Empty;

        public int Age { get; set; }

        public string Colour
        {
            get; private set;
        }

        public Animal(int? legs, string diet)
        {
            Legs = legs * 2;
            Diet = diet;
        }

        public override string ToString()
        {
            //int localLegs = String.Format("Animal, Legs = {0}, Diet = {1}", (Legs == 8 ? (Legs == 7 ? Legs ?? 7 : 8) : 9), Diet);
        }
    }
}
