using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            stringWriter.Write("James Corbould");

            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();

        }

        public string FormatCoins(string name, int coins)
        {
            return string.Format("Player {0}, collected {1:D3} coins", name, coins);
        }
    }
}
