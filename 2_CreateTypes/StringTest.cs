using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    static class StringTest
    {
        // Format method has this syntax: {index[,alignment][:formatString]}.
        public static void TestStringFormat()
        {
            // Create array of 5-tuples with population data for three U.S. cities, 1940-1950.
            Tuple<string, DateTime, int, DateTime, int>[] cities =
                { Tuple.Create("Los Angeles", new DateTime(1940, 1, 1), 1504277,
                         new DateTime(1950, 1, 1), 1970358),
            Tuple.Create("New York", new DateTime(1940, 1, 1), 7454995,
                         new DateTime(1950, 1, 1), 7891957),
            Tuple.Create("Chicago", new DateTime(1940, 1, 1), 3396808,
                         new DateTime(1950, 1, 1), 3620962),
            Tuple.Create("Detroit", new DateTime(1940, 1, 1), 1623452,
                         new DateTime(1950, 1, 1), 1849568) };

            // Display header
            var header = String.Format("{0,-12}{1,8}{2,12}{1,8}{2,12}{3,14}\n",
                                          "City", "Year", "Population", "Change (%)");
            Console.WriteLine(header);
            foreach (var city in cities)
            {
                var output = String.Format("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}",
                                       city.Item1, city.Item2, city.Item3, city.Item4, city.Item5,
                                       (city.Item5 - city.Item3) / (double)city.Item3);
                Console.WriteLine(output);
            }
        }

        public static void TestStringFormatting()
        {
            Decimal pricePerOunce = 17.36m;
            Decimal pricePerKilo = 22.34m;

            String s = String.Format("\nThe current price is {0:C2} per ounce.", pricePerOunce);
            Console.WriteLine(s);

            s = String.Format("The current price is {0:c4} per ounce.", pricePerOunce);
            Console.WriteLine(s);

            // Check if specify one number after the decimal place, that the value is rounded up/down.
            s = String.Format("The current price is {0:c1} per ounce.", pricePerOunce);
            Console.WriteLine(s);

            s = String.Format("The current price is {0:c1} per kilo.", pricePerKilo);
            Console.WriteLine(s);

            // Left align.
            // Create 2 arrays showing cities and population and display as a formatted table.
            Dictionary<string, int> cities = new Dictionary<string, int>()
            {
                { "Auckland", 1000000 },
                { "Wellington", 500000 },
                { "Christchurch", 500000 }
            };

            Console.WriteLine("\n{0,-16} {1,12}", "City", "Population");

            foreach (KeyValuePair<string, int> kv in cities)
            {
                Console.WriteLine("{0,-16} {1,12:N0}", kv.Key, kv.Value);
            }

            Console.WriteLine("\n");
        }
    }
    
    // Define a custom string formatter.
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                if (String.IsNullOrEmpty(format))
                {
                    format = "G";
                }

                string customerString = arg.ToString();
                if (customerString.Length < 8)
                {
                    customerString = customerString.PadLeft(8, '0');
                }

                format = format.ToUpper();
                switch (format)
                {
                    case "G":
                        return customerString.Substring(0, 1) + "-" +
                                              customerString.Substring(1, 5) + "-" +
                                              customerString.Substring(6);
                    case "S":
                        return customerString.Substring(0, 1) + "/" +
                                              customerString.Substring(1, 5) + "/" +
                                              customerString.Substring(6);
                    case "P":
                        return customerString.Substring(0, 1) + "." +
                                              customerString.Substring(1, 5) + "." +
                                              customerString.Substring(6);
                    default:
                        throw new FormatException(
                                  String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
        }
    }
}
