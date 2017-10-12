using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    
        struct DigitType
        {
            byte value;

            public DigitType(byte value)  //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }

            public static implicit operator byte(DigitType d)  // implicit digit to byte conversion operator
            {
                System.Console.WriteLine("conversion occurred");
                return d.value;  // implicit conversion
            }
        }

        //class TestImplicitConversion
        //{
        //    static void Main()
        //    {
        //        Digit d = new Digit(3);
        //        byte b = d;  // implicit conversion -- no cast needed
        //    }
        //}
        // Output: Conversion occurred.
}
