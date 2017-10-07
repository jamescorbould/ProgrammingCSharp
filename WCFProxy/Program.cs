using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            string result = client.GetData(1);
            Console.WriteLine(result);
            WCFService.CompositeType ctype = new WCFService.CompositeType();
            ctype.BoolValue = true;
            WCFService.CompositeType type = client.GetDataUsingDataContract(ctype); // Example of using DataContract to retrieve a class over the wire.
            Console.WriteLine(type.StringValue);
            Console.WriteLine(ctype.StringValue);
            Console.ReadKey();
        }
    }
}
