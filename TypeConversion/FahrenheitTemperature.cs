using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversion
{
    class FahrenheitTemperature
    {
        public double Temperature { get; set; }

        public static implicit operator FahrenheitTemperature(CelsiusTemperature celsiusTemperature)
        {
            return new FahrenheitTemperature { Temperature = ((celsiusTemperature.Temperature * 1.8) + 32) };
        }
    }
}
