using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ServiceModel;

namespace _4_Implement_Data_Access
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerializing.");
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerialized.");
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("OnDeserializing.");
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("OnSerialized.");
        }
    }

    // Example of implementing ISerializable to have greater control over the serialization of the object by using the SerializationInfo object.
    [Serializable]
    public class PersonComplex : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isDirty = false;
        public PersonComplex() { }

        protected PersonComplex(SerializationInfo info, StreamingContext context)
        {
            // Constructor is called during deserialization.
            Console.WriteLine("Deserializing - constructor called - reading data *from* SerializationInfo object.");
            // Security checks here.

            Id = info.GetInt32("Value1");
            Name = info.GetString("Value2");
            isDirty = info.GetBoolean("Value3");
        }

        [System.Security.Permissions.SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Called during serialization.
            Console.WriteLine("Serializing - loading data *into* SerializationInfo object.");
            info.AddValue("Value1", Id);
            info.AddValue("Value2", Name);
            info.AddValue("Value3", isDirty);
        }
    }

    [Serializable]
    public class OrderS
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlIgnore]
        public bool IsDirty { get; set; }
        [XmlArray("Lines")]
        [XmlArrayItem("OrderLine")]
        public List<OrderLineS> OrderLines { get; set; }
    }

    [Serializable]
    public class VIPOrder : OrderS
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class OrderLineS
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public int Amount { get; set; }
        [XmlElement("OrderedProduct")]
        public ProductS Product { get; set; }
    }

    [Serializable]
    public class ProductS
    {
        [XmlAttribute]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class Patient : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            { 
                return 1;
            }

            Patient p = obj as Patient;

            if (p == null)
            {
                throw new ArgumentException("Object is not an Patient");
            }

            return this.Name.CompareTo(p.Name);
        }

        public override string ToString()
        {
            return string.Format("ID = {0}, Name = {1}, Age = {2}", this.ID, this.Name, this.Age);
        }
    }

    //explcit interface defintion example. = 1 interface where only some methods should be called by a specific class.  since private, 
        //cannot be called unless explicity implemented, so only explicit implement those methods required for the class from the interface.
}
