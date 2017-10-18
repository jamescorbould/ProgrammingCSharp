using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    public static class DelegateTest
    {
        public delegate string Combine(string s1, string s2);

        public static string test(string s, string ss)
        {
            Combine combine = delegate (string s1, string s2) { return s1 + s2; }; // Remember need to include types in the delegate parameters!!
            return combine(s, ss);
        }
    }
}
