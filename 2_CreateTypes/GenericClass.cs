using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    interface ISuperHero
    {
        bool CanFly { get; set; }
        string AliasName { get; set; }
        // public parameterless constructor?
    }

    class SuperHero : ISuperHero, IComparable, IEquatable<SuperHero> // Must have default constructor under the hood?
    {
        public bool CanFly { get; set; }
        public string AliasName { get; set; }

        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            // Used in sort() method and sorts heros by aliasname descending.
            SuperHero next = (SuperHero)obj;
            return this.AliasName.CompareTo(next.AliasName);
        }

        public bool Equals(SuperHero other)
        {
            if (this.AliasName.CompareTo(other.AliasName) == 0 && this.Age == other.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            SuperHero other = (SuperHero)obj;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            // Custom hashcode implementation.
            return (this.AliasName + this.Age).GetHashCode();
        }

        public static bool operator == (SuperHero hero1, SuperHero hero2)
        {
            if (((object)hero1) == null || ((object)hero2) == null)
            {
                return Object.Equals(hero1, hero2);
            }

            return hero1.Equals(hero2);
        }

        public static bool operator != (SuperHero hero1, SuperHero hero2)
        {
            if (((object)hero1) == null || ((object)hero2) == null)
            {
                return !Object.Equals(hero1, hero2);
            }

            return !(hero1.Equals(hero2));
        }
    }

    class SortByName : IComparer, IComparer<SuperHero>
    {
        public int Compare(object x, object y)
        {
            SuperHero first = (SuperHero)x;
            SuperHero second = (SuperHero)y;
            return first.AliasName.CompareTo(second.AliasName);
        }

        int IComparer<SuperHero>.Compare(SuperHero x, SuperHero y)
        {
            return x.AliasName.CompareTo(y.AliasName);
        }
    }

    class SortByAge : IComparer, IComparer<SuperHero>
    {
        public int Compare(object x, object y)
        {
            SuperHero first = (SuperHero)x;
            SuperHero second = (SuperHero)y;
            return first.Age.CompareTo(second.Age);
        }

        int IComparer<SuperHero>.Compare(SuperHero x, SuperHero y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }

    class GenericClass<T,M> where T : ISuperHero
    {
        public T GenericProperty0 { get; set; }
        public M GenericProperty1 { get; set; }

        public GenericClass(T genericProperty0, M genericProperty1)
        {
            GenericProperty0 = genericProperty0;
            GenericProperty1 = genericProperty1;
        }

        public GenericClass()
        {
        }

        public override string ToString()
        {
            return string.Format("GenericProperty0 = {0}, GenericProperty0 = {1}, GenericProperty1 = {2}", GenericProperty0.CanFly, GenericProperty0.AliasName, GenericProperty1);
        }
    }

    // Note: more than one generic parameter here.  Use of generic parameters prevents the overhead of boxing/unboxing.
    // The new() generic parameter constraint **must** come last if there are a list of constraints.
    class Person<T> where T : SuperHero, new() // Where T can only be a Superhero with a default constructor.
    {
        // If define such a constraint on T, then why not just specifiy it explicitly??!
        public T GenericProperty0 { get; set; }

        public Person(T genericProperty0)
        {
            GenericProperty0 = genericProperty0;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return string.Format("GenericProperty0 = {0}, GenericProperty0 = {1}, GenericProperty0.GetType = {2}", GenericProperty0.CanFly, GenericProperty0.AliasName, GenericProperty0.GetType());
        }

        public void MultipleGenericMethodArgs<J, K>(J first, K second)
        {
            Console.WriteLine("{0}: {1}", first, second);
        }
        public K ReturnFromMultipleGenericMethodArgs<K, J>(K first)
        {
            K temp = default(K);
            return temp;
        }

        public V ReturnFromGenericValueType<V>(V first) where V : struct  // V must be a value type e.g. int (which is a struct).
        {
            return default(V);
        }
    }
}
