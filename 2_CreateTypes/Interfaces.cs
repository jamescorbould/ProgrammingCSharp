using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Order : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Order o = obj as Order;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }

            return this.Created.CompareTo(o.Created);
        }
    }
}
