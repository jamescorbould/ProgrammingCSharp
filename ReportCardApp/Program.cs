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

                StudentMarks[i] = new string[]{studentName, englishMarks, mathMarks, computerMarks};

                Console.WriteLine("****************************************");
            }

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
                Console.WriteLine("****************************************\n");
            }

            Console.ReadKey();
        }
    }
}
