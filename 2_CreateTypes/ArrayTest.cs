using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    public static class ArrayTest
    {
        public static void MultiDimArrayTest()
        {
            int[,] numbers = new int[2, 5];

            // Initialize numbers array.
            numbers = new int[2, 5]
            {
                {2,4,6,8,10},
                {1,3,5,7,9}
            };

            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    Console.WriteLine("Pos[{0},{1}] = {2}", row, col, numbers[row, col]);
                }
            }
        }

        public static void JaggedArrayTest()
        {
            // Jagged array is an array of an array, which means number of rows in jagged array is
            // fixed but number of columns isn’t fixed.
            int[][] jagged = new int[4][]; // Jagged array with 4 rows.

            // Declare each row with different number of columns.
            jagged[0] = new int[2]; // Row 0 has 2 columns.
            jagged[1] = new int[3]; // Row 1 has 3 columns.
            jagged[2] = new int[4];
            jagged[3] = new int[5];

            // Initialize with values.
            jagged[0] = new int[] { 4, 5 };
            jagged[1] = new int[] { 6, 7, 8 };

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].GetLength(0); col++)
                {
                    //Console.WriteLine("[{0}],[{1}] = {2}", row, col, jagged[row][col]);
                }
            }

            int[][] jagged2 =
                {
                    new int[]{4,5},
                    new int[]{6,7,8},
                    new int[]{9,10,11},
                    new int[]{12,13,14,15}
                };

            for (int row = 0; row < jagged2.GetLength(0); row ++)
            {
                for (int col = 0; col < jagged2[row].GetLength(0); col++)
                {
                    Console.WriteLine("[{0}],[{1}] = {2}", row, col, jagged2[row][col]);
                }
            }
        }
    }
}
