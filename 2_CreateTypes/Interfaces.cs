using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Order : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            return this.Created.CompareTo(o.Created);
        }
    }

    /// <summary>
    /// Example class that implements IEquatable interface to determine if two instances are equal.
    /// </summary>
    public class Car : IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public Car(string make, string model, string year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {
            if (this.Make == car.Make &&
                this.Model == car.Model &&
                this.Year == car.Year)
            {
                return true;
            }
            else
                return false;
        }
    }
    
    interface IMaths
    {
        int Marks { get; }
    }

    interface IEnglish
    {
        int Marks { get; }
    }

    class Student : IMaths, IEnglish
    {
        /// <summary>
        /// Example of explicit interface defintion, to cope with 2 different interfaces containing field of the same name.
        /// </summary>
        int mathsMarks = 10;
        int englishMarks = 5;

        int IMaths.Marks
        {
            get
            {
                return mathsMarks;
            }
        }

        int IEnglish.Marks
        {
            get
            {
                return englishMarks;
            }
        }
    }
}
