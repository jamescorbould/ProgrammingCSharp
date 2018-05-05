using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    public static class EnumTest
    {
        public enum Status : Byte
        {
            Alive = 1,
            Injured,
            Dead
        };

        [Flags]
        public enum BorderSides // The enum represents a collection of flags, rather than a single value.
        {
            None=0,
            Left=1,
            Right=2,
            Top=4,
            Bottom=8
        }

        [Flags]
        public enum Colours  // Bit flags.
        {
            None=0,     // 0x00000000
            Red=1,      // 0x00000010
            Green=2,    // 0x00000100
            Yellow=4,   // 0x00001000
            Blue=8      // 0x00010000
        }
    }
}
