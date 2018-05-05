using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Distance
    {
        public int metre { get; set; }

        /// <summary>
        /// Example of operator overloading.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Distance operator ++ (Distance distance)
        {
            distance.metre += 5;
            return distance;
        }

        public static bool operator < (Distance d1, Distance d2)
        {
            return (d1.metre < d2.metre);
        }

        public static bool operator > (Distance d1, Distance d2)
        {
            return (d1.metre > d2.metre);
        }
    }

    class Pupil
    {
        public int marks { get; set; }

        public static Pupil operator + (Pupil pup1, Pupil pup2)
        {
            Pupil pup3 = new Pupil();
            pup3.marks = pup1.marks + pup2.marks;
            return pup3;
        }
    }
}
