using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace _4_Implement_Data_Access
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Task t = SelectDataFromTable();
            //Task t = SelectMultipleFromTable();
            //Task t = UpdateRows();
            //Task t = UpdateRowsWithParameters("MERCURY");
            //Task t = TestTransactions();
            //TestXMLReader();
            //TestXMLWriterCreateFile();
            //TestXMLDoc();
            TestXPath();
            //LinqSelectTest();
            //LinqJoinTest();
            //LinqOrders();
            //LinqToXMLTest();
            //SerlializeOrder();
            //SerializeBinary();
            //SerializeJS();
            //Patient p = new Patient { ID = 123, Name = "Grantx", Age = 104 };
            //Console.WriteLine(GetPropertyValueByReflection(p));

            //List<Patient> pcoll = new List<Patient>
            //{
            //    new Patient { ID = 0, Age = 23, Name = "Bob" },
            //    new Patient { ID = 1, Age = 40, Name = "James" }
            //};

            //Console.WriteLine("RegEx validation result = {0}", ValidateZipCodeRegEx("001"));

            //pcoll.Sort();

            //foreach(Patient pt in pcoll)
            //{
            //    Console.WriteLine(pt.Name);
            //}

            //TestForLoop(pcoll);

            //TestComparePatients();

            Console.ReadKey();
        }

        public static async Task SelectDataFromTable()
        {
            // ADO.NET.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM JobHeader", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Console.WriteLine("Job name '{0}' retrieved from db.", dataReader["JobName"]);
                }

                dataReader.Close();
            }
        }

        public static async Task SelectMultipleFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM JobHeader;SELECT COUNT(*) AS Total from JobHeader", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Console.WriteLine("Job name '{0}' retrieved from db.", dataReader["JobName"]);
                }

                await dataReader.NextResultAsync(); // Move to the next result set.
                await dataReader.ReadAsync();
                Console.WriteLine("Total no of records = {0}", dataReader["Total"]);

                dataReader.Close();
            }
        }

        public static async Task UpdateRows()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE JobHeader SET JobName = 'MOTLEY' WHERE ID = '2100219'", connection);
                await connection.OpenAsync();

                int noOfRowsUpdated = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} row(s).", noOfRowsUpdated);
            }
        }

        public static async Task UpdateRowsWithParameters(string jobName)
        {
            // Allows protect against SQL injection from a malicious user.
            // Should always validate user input before using in a SQL statement.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE JobHeader SET JobName = @jobName WHERE ID = '2100219'", connection);
                await connection.OpenAsync();

                // By using parameters, ensures that users cannot enter/insert malicious code into the above SQL.
                // SQL will fail on syntax error, for example.
                command.Parameters.AddWithValue("@jobName", jobName);

                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} rows", numberOfInsertedRows);
            }
        }

        public static async Task TestTransactions()
        {
            // Wraps db changes into a transaction - if an error occurs within the scope of the transaction,
            // then whole transaction is rolled back.  Prevents data corruption.
            // Wrap within a using to ensure the object is disposed when no longer in use.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (TransactionScope tscope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("INSERT INTO JobHeader([JobName]) VALUES('Job101')", connection);
                        SqlCommand command2 = new SqlCommand("INSERT INTO JobHeader([JobName]) VALUES('Job101')", connection);
                        await command1.ExecuteNonQueryAsync();
                        await command2.ExecuteNonQueryAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception thrown - {0}.", e.Message);
                    }
                }
                tscope.Complete();
            }
        }

        public static void TestXMLReader()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                            <people>
                                <person firstname=""john"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>john@unknown.com</emailaddress>
                                    </contactdetails>
                                </person>
                                <person firstname=""jane"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>jane@unknown.com</emailaddress>
                                        <phonenumber>001122334455</phonenumber>
                                    </contactdetails>
                                </person>
                            </people>";

            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings() { IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");
                    string firstName = xmlReader.GetAttribute("firstName");
                    string lastName = xmlReader.GetAttribute("lastName");
                    Console.WriteLine("Person: {0} {1}", firstName, lastName);
                    xmlReader.ReadStartElement("person");
                    Console.WriteLine("Contact Details");
                    xmlReader.ReadStartElement("contactdetails");
                    string emailAddress = xmlReader.ReadString();
                    Console.WriteLine("Email address: {0}", emailAddress);
                }
            }
        }

        public static void TestXMLWriterCreateFile()
        {
            StringWriter stream = new StringWriter();

            using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("firstName", "John");
                writer.WriteAttributeString("lastName", "Doe");
                writer.WriteStartElement("ContactDetails");
                writer.WriteElementString("EmailAddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }

            Console.WriteLine(stream.ToString());
        }

        public static void TestXMLDoc()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                            <people>
                                <person firstname=""john"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>john@unknown.com</emailaddress>
                                    </contactdetails>
                                </person>
                                <person firstname=""jane"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>jane@unknown.com</emailaddress>
                                        <phonenumber>001122334455</phonenumber>
                                    </contactdetails>
                                </person>
                            </people>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.GetElementsByTagName(name: "person");

            // Output the names of the people in the document.
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            // Start creating a new node.
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            firstNameAttribute.Value = "Foo";
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            lastNameAttribute.Value = "Bar";
            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);
            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);
        }

        public static void TestXPath()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                            <people>
                                <person firstname=""john"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>john@unknown.com</emailaddress>
                                    </contactdetails>
                                </person>
                                <person firstname=""jane"" lastname=""doe"">
                                    <contactdetails>
                                        <emailaddress>jane@unknown.com</emailaddress>
                                        <phonenumber>001122334455</phonenumber>
                                    </contactdetails>
                                </person>
                            </people>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XPathNavigator nav = doc.CreateNavigator();
            string query = "//people/person[@firstname='jane']";
            XPathNodeIterator iterator = nav.Select(query);
            Console.WriteLine(iterator.Count); // Displays 1

            while (iterator.MoveNext())
            {
                string firstName = iterator.Current.GetAttribute("firstname", "");
                string lastName = iterator.Current.GetAttribute("lastname", "");
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }
        }

        public static void LinqSelectTest()
        {
            int[] data = { 1, 2, 3, 5, 8, 13 };

            // Query syntax.
            var result = from d in data
                         where d > 5
                         select d;

            Console.WriteLine(string.Join(", ", result));

            // Method syntax.
            result = data.Where(x => x > 5);

            Console.WriteLine(string.Join(", ", result));
        }

        public static void LinqJoinTest()
        {
            int[] data1 = { 1, 2, 3, 5, 8, 13 };
            int[] data2 = { 2, 4, 6, 8, 10, 12 };

            var result = from d1 in data1
                         from d2 in data2
                         select d1 * d2;

            Console.WriteLine(string.Join(", ", result));
        }

        public class Product
        {
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public class OrderLine
        {
            public int Amount { get; set; }
            public Product Product { get; set; }
        }

        public class Order
        {
            public List<OrderLine> OrderLines { get; set; }
        }

        public static void LinqOrders()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Description = "Widget",
                    Price = 1.00M
                },
                new Product
                {
                    Description = "Widget2",
                    Price = 2.00M
                }
            };

            var orders = new List<Order>
            {
                new Order
                {
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Amount = 5,
                            Product = products[0]
                        },
                        new OrderLine
                        {
                            Amount = 3,
                            Product = products[1]
                        }
                    }
                },
                new Order
                {
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine
                        {
                            Amount = 5,
                            Product = products[0]
                        },
                        new OrderLine
                        {
                            Amount = 3,
                            Product = products[1]
                        },
                        new OrderLine
                        {
                            Amount = 2,
                            Product = products[0]
                        },
                        new OrderLine
                        {
                            Amount = 15,
                            Product = products[1]
                        }
                    }
                }
            };

            Console.WriteLine("Average no. of order lines per order = {0}", orders.Average(o => o.OrderLines.Count));  // Method syntax, no query syntax available.

            // Example of projection - select another type or anon. type as the result of your query.
            var result = from o in orders
                         from l in o.OrderLines
                         group l by l.Product into p
                         select new
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };

            var list = result.ToList();
            Console.WriteLine("Sum of product {0} = {1}", result.First().Product.Description, result.First().Amount);

            foreach (var p in result)
            {
                Console.WriteLine("Sum of product {0} = {1}", p.Product.Description, p.Amount);
            }
        }

        public static void LinqToXMLTest()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                        <people>
                            <person firstname=""john"" lastname=""doe"">
                                <contactdetails>
                                    <emailaddress>john@unknown.com</emailaddress>
                                </contactdetails>
                            </person>
                            <person firstname=""jane"" lastname=""doe"">
                                <contactdetails>
                                    <emailaddress>jane@unknown.com</emailaddress>
                                    <phonenumber>001122334455</phonenumber>
                                </contactdetails>
                            </person>
                            <person firstname=""freddy"" lastname=""doe"">
                                <contactdetails>
                                    <emailaddress>jane@unknown.com</emailaddress>
                                    <phonenumber>001122334455</phonenumber>
                                </contactdetails>
                            </person>
                        </people>";

            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> personNames = from p in doc.Descendants("person")
                                              where p.Descendants("contactdetails").Descendants("phonenumber").Any()
                                              let name = (string)p.Attribute("firstname")
                                              + " " + (string)p.Attribute("lastname")
                                              orderby name
                                              select name;

            foreach (string n in personNames)
            {
                Console.WriteLine("Name = {0}", n.ToString());
            }
        }

        private static OrderS CreateOrder()
        {
            ProductS p1 = new ProductS { ID = 1, Description = "p2", Price = 9 };
            ProductS p2 = new ProductS { ID = 2, Description = "p3", Price = 6 };

            OrderS order = new VIPOrder
            {
                ID = 4,
                Description = "Order for John Doe. Use the nice giftwrap",

                OrderLines = new List<OrderLineS>
                {
                    new OrderLineS { ID = 5, Amount = 1, Product = p1},
                    new OrderLineS { ID = 6 ,Amount = 10, Product = p2},
                }
            };

            return order;
        }

        private static void SerlializeOrder()
        {
            Console.WriteLine("Serlialize Order");
            XmlSerializer serializer = new XmlSerializer(typeof(OrderS), new Type[] { typeof(VIPOrder) });
            string xml;
            string xmlFilePath = @"C:\temp\Order.xml";

            using (StringWriter stringWriter = new StringWriter())
            {
                OrderS order = CreateOrder();
                serializer.Serialize(stringWriter, order);
                xml = stringWriter.ToString();
            }

            using (StringReader stringReader = new StringReader(xml))
            {
                OrderS o = (OrderS)serializer.Deserialize(stringReader);

                // Use the order.
                using (StreamWriter sw = File.CreateText(xmlFilePath))
                {
                    sw.WriteLine(xml);
                }
            }
        }

        private static void SerializeBinary()
        {
            Person p = new Person
            {
                Age = 40,
                FirstName = "Corbs",
                LastName = "Corby"
            };

            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(@"C:\temp\data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream(@"C:\temp\data.bin", FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);
                //Person dp2 = formatter.Deserialize<Person>(stream);  // Compiler error - no generic version.
                Console.WriteLine("Person name = {0} {1}", dp.FirstName, dp.LastName);
            }
        }

        private static void SerializeJS()
        {
            Patient p = new Patient
            {
                ID = 1,
                Name = "Bob",
                Age = 34
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(p);

            Console.WriteLine(json);

            p = serializer.Deserialize<Patient>(json);

            Console.WriteLine("p.Name = {0}", p.Name);

            p = (Patient)serializer.Deserialize(json, p.GetType());

            Console.WriteLine("p.Name = {0}", p.Name);

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Name0", "James");
            dict.Add("Name1", "Ben");
            dict.Add("Name2", "Lockie");

            json = serializer.Serialize(dict);

            Console.WriteLine(json);
        }

        // Try reflection on Patient class to retrive name property.
        public static string GetPropertyValueByReflection(Patient p)
        {
            return p.GetType().GetProperty("Name").GetValue(p).ToString();
        }

        public static void TestForLoop(List<Patient> pcoll)
        {
            // Gives runtime error, cannot use foreach to remove items from a collection.
            //foreach (Patient p in pcoll)
            //{
            //    pcoll.RemoveAt(pcoll.IndexOf(p));
            //}

            Console.WriteLine("pcoll count = {0}", pcoll.Count());
            int count = pcoll.Count();

            for (int i = 0; i < count; i++)
            {
                pcoll.RemoveAt(0);
            }

            Console.WriteLine("pcoll count after remove = {0}", pcoll.Count());
        }

        public static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        public static void TestComparePatients()
        {
            List<Patient> pcoll = new List<Patient>
            {
                new Patient { Age = 55, ID = 0, Name = "Bob" },
                new Patient { Age = 33, ID = 1, Name = "Jim" }
            };

            pcoll.Sort();

            foreach (Patient p in pcoll)
            {
                Console.WriteLine(p.ToString());
            }

            var patArray = pcoll.ToArray();

            // < 0 = current instance precedes object specified in the sort order.  'B' precedes 'J' if sorted alpha.
            // 0 = current instance in the same pos in the sort order.
            // > 0 = current instance follows the object specified in the sort order.  'J' follows 'B' in the sort order.
            Console.WriteLine(patArray[0].CompareTo(patArray[1])); // returns -1.
            Console.WriteLine(patArray[1].CompareTo(patArray[0])); // returns 1.
        }

        public static void TestRaiseEvent()
        {
            
        }
    }
}
