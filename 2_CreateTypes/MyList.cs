using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    // Custom collection.
    class MyList<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();

        public int Length { get { return list.Count; } }

        public void Add(T data)
        {
            list.Add(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
