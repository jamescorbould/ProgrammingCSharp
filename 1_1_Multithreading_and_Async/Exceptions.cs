using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_Multithreading_and_Async
{
    public static class Exceptions
    {
        static ExceptionDispatchInfo possibleException = null;

        public static void Throw()
        {
            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
            {
                possibleException.Throw();
            }
        }
    }
}
