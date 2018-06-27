using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class StringTest
    {
        // Format method has this syntax: {index[,alignment][:formatString]}.
        public void TestStringFormat()
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
    }
}
