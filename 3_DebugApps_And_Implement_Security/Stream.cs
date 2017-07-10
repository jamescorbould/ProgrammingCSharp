using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DebugApps_And_Implement_Security
{
    public static class Stream
    {
        public static void FilestreamTest()
        {
            string path = @"c:\temp\test.dat";

            using (FileStream fs = File.Create(path))
            {
                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fs.Write(data, 0, data.Length);
                Console.WriteLine("Written file stream");
            }
        }

        public static void StreamWriterTest()
        {
            // Creates a file with UTF8 encoding automatically.
            string path = @"c:\temp\test2.dat";

            using (StreamWriter sw = File.CreateText(path))
            {
                string myValue = "MyValue";
                sw.Write(myValue);  // Encoding is already sorted out for you.
            }
        }
    }
}
