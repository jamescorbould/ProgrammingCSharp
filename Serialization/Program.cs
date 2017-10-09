using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(12345);
            DataContractSerializer s = new DataContractSerializer(typeof(Customer));

            using (FileStream fs = File.Open("test" + typeof(Customer).Name + "DataContract.xml", FileMode.Create))
            {
                s.WriteObject(fs, customer);
            }

            XmlSerializer xml = new XmlSerializer(typeof(Customer2));

            using (FileStream fs2 = File.Open("test" + typeof(Customer2).Name + "XmlSerializer.xml", FileMode.Create))
            {
                s.WriteObject(fs2, customer);
            }
        }
    }

    // DataConstractSerializer will serialize all data members, no matter if private fields or not.
    [DataContract]
    public class Customer
    {
        [DataMember]
        private int CustomerID;
        public Customer(int custID)
        {
            this.CustomerID = custID;
        }
    }

    [XmlRoot]
    public class Customer2
    {
        [XmlElement]
        private int CustomerID;
        public Customer2()
        {

        }
        public Customer2(int custID)
        {
            this.CustomerID = custID;
        }
    }
}
