using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    abstract class Vehicle
    {
        public int wheels { get; set; }
    }

    class Bike : Vehicle
    {
        public Bike()
        {
            base.wheels = 2;
        }
    }

    // Implicit interface is implemented publicly.
    interface IVehicle
    {
        int wheels { get; set; } // public.
    }

    public class Truck : IVehicle
    {
        public int wheels { get; set; }

        public Truck()
        {
            wheels = 4;
        }
    }
}
