using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public async static void CreateAndWriteAsyncToFile()
        {
            using (FileStream fs = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                await fs.WriteAsync(data, 0, data.Length);
            }
        }

        public async static void TestHttpRequestAsync()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.datacom.co.nz");
        }

        public async static void SequentialCalls()
        {
            HttpClient client = new HttpClient();

            // The Tasks below will run sequentiallly (t = 3t);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            string microsoft = await client.GetStringAsync("http://www.microsoft.com");
            Console.WriteLine("First task completed");
            string datacom = await client.GetStringAsync("http://www.datacom.co.nz");
            Console.WriteLine("Second task completed");
            string dd = await client.GetStringAsync("http://www.dimensiondata.com");
            Console.WriteLine("Third task completed");
            sw.Stop();
            Console.WriteLine("*** Elapsed time sequential = {0} ms ***", sw.ElapsedMilliseconds);
        }

        public async static void ParallelCalls()
        {
            HttpClient client = new HttpClient();

            // The Tasks below will run sequentiallly (t = t/3);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Task microsoft = client.GetStringAsync("http://www.microsoft.com");
            Console.WriteLine("First parallel task start");
            Task datacom = client.GetStringAsync("http://www.datacom.co.nz");
            Console.WriteLine("Second parallel task start");
            Task dd = client.GetStringAsync("http://www.dimensiondata.com");
            Console.WriteLine("Third parallel task start");
            await Task.WhenAll(microsoft, datacom, dd);
            sw.Stop();
            Console.WriteLine("*** Elapsed time parallel = {0} ms ***", sw.ElapsedMilliseconds);
        }
    }
}
