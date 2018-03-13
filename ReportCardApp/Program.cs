using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCardApp
{
    class Program
    {
        private static string[][] studentMarks;

        public static string[][] StudentMarks { get => studentMarks; set => studentMarks = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("****************************************");
            Console.Write("Enter total students: ");
            int studentsTotal = int.Parse(Console.ReadLine());
            StudentMarks = new string[studentsTotal][];

            int[][] jagged =
            {
                new int[]{4,5},
                new int[]{6,7,8},
                new int[]{9,10,11},
                new int[]{12,13,14,15}
            };

            for (int i = 0; i < studentsTotal; i++)
            {
                Console.Write("Enter Student Name: ");
                string studentName = Console.ReadLine();
                Console.Write("Enter English Marks(Out Of 100): ");
                string englishMarks = Console.ReadLine();
                Console.Write("Enter Math Marks(Out Of 100): ");
                string mathMarks = Console.ReadLine();
                Console.Write("Enter Computer Marks(Out Of 100): ");
                string computerMarks = Console.ReadLine();

                int totalMarks = Sum(int.Parse(englishMarks), int.Parse(mathMarks), int.Parse(computerMarks));

                StudentMarks[i] = new string[] { studentName, englishMarks, mathMarks, computerMarks,
                    Sum(int.Parse(englishMarks), int.Parse(mathMarks), int.Parse(computerMarks)).ToString() };

                Console.WriteLine("****************************************");
            }

            SortReportCards();
            PrintReportCard();
}

        private static void PrintReportCard()
        {
            for (int i = 0; i < StudentMarks.GetLength(0); i++)
            {
                string[] student = StudentMarks[i];

                Console.WriteLine("\n****************************************");
                Console.WriteLine("Student Name:    {0}", student[0]);
                Console.WriteLine("English Marks:   {0}", student[1]);
                Console.WriteLine("Math Marks:      {0}", student[2]);
                Console.WriteLine("Computer Marks:  {0}", student[3]);
                Console.WriteLine("Total Marks:     {0}", student[4]); 
                Console.WriteLine("****************************************\n");
            }

            Console.ReadKey();
        }

        private static void SortReportCards()
        {
            // Sort the Report Card array with the highest score descending.
            string[][] studentMarks = new string[StudentMarks.GetLength(0)][];
            //StudentMarks.CopyTo(studentMarks, 0);

            while (studentMarks.GetLength(0) <= StudentMarks.GetLength(0))
            {
                string[] maxStudent = studentMarks.Last();
                int currentMaxMarks = maxStudent == null ? 0 : int.Parse(maxStudent[4]);

                string[] student = StudentMarks.First();
                int currentMarks = int.Parse(student[4]);

                if (currentMaxMarks >= currentMarks)
                {
                    StudentMarks.Skip(1);
                }
                else
                {
                    //studentMarks.SetValue(student, );
                    StudentMarks.Take(1);
                }
            }

            StudentMarks = studentMarks;
        }

        private static int Sum(params int[] ints)
        {
            int total = 0;

            foreach (int i in ints)
            {
                total += i;
            }

            return total;
        }
    }
}
