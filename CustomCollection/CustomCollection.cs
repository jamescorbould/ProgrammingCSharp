using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    class CustomCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        private List<T> list = new List<T>();

        T IList<T>.this[int index] { get => list.ElementAt<T>(index); set => list.Insert(index, value); }

        int ICollection<T>.Count => list.Count();

        bool ICollection<T>.IsReadOnly => throw new NotImplementedException();
        
        public void Add(T item)
        {
            list.Add(item);
        }

        void ICollection<T>.Clear()
        {
            list.Clear();
        }

        public string test()
        {
            return "test";
        }

        bool ICollection<T>.Contains(T item)
        {
            return list.Contains<T>(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            T[] obj = new T[list.Count()];
            list.CopyTo(obj, arrayIndex);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        int IList<T>.IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        void IList<T>.Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        bool ICollection<T>.Remove(T item)
        {
            return list.Remove(item);
        }

        void IList<T>.RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
    }
}
