using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
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

        public static void ReadFileStream()
        {
            string path = @"c:\temp\test2.dat";

            using (FileStream fs = File.OpenRead(path))
            {
                byte[] data = new byte[fs.Length];

                for (int index = 0; index < fs.Length; index++)
                {
                    data[index] = (byte)fs.ReadByte();
                }

                Console.WriteLine(Encoding.UTF8.GetString(data));
            }
        }

        public static void ReadFileStreamStreamReader()
        {
            string path = @"c:\temp\test2.dat";

            // If know parsing a text file, then can use StreamReader which uses a default encoding and returns the bytes as a string.
            using (StreamReader sr = File.OpenText(path))
            {
                Console.WriteLine(sr.ReadLine());
            }
        }

        public static void DecoratorPatternStreams()
        {
            string folder = @"C:\temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 + 1024).ToArray();

            using (FileStream fs = File.Create(uncompressedFilePath))
            {
                fs.Write(dataToCompress, 0, dataToCompress.Length);
            }

            using (FileStream fsc = File.Create(compressedFilePath))
            {
                using (GZipStream gz = new GZipStream(fsc, CompressionMode.Compress))
                {
                    gz.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
            FileInfo compressedFile = new FileInfo(compressedFilePath);

            Console.WriteLine(uncompressedFile.Length);
            Console.WriteLine(compressedFile.Length);
        }

        public static void TestWebRequest()
        {
            WebRequest req = WebRequest.Create("http://www.datacom.co.nz");
            WebResponse resp = req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string responseText = sr.ReadToEnd();

            Console.WriteLine(responseText);

            resp.Close();
        }
    }
}
