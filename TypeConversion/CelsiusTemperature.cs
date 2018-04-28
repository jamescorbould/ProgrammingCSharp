using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
    class CelsiusTemperature
    {
        public double Temperature { get; set;  }

        public static implicit operator CelsiusTemperature(FahrenheitTemperature fahrenheit)
        {
            return new CelsiusTemperature { Temperature = (fahrenheit.Temperature -32) * .5556 };
        }
    }
}
