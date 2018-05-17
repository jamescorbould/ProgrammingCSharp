using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class People : IEnumerable
    {
        SuperHero[] people;
        int index = -1;

        public void Add(SuperHero person)
        {
            if (++index < people.Length)
            {
                people[index] = person;
            }
        }
        public People(int size)
        {
            people = new SuperHero[size];
        }

        public IEnumerator GetEnumerator()
        {
            return new PersonEnum(people);
        }
    }

    //Implement IEnumerator, which defines how to interate over a collection.
    class PersonEnum : IEnumerator
    {
        SuperHero[] _people;
        int index = -1;

        public PersonEnum(SuperHero[] people)
        {
            _people = people;
        }

        //Check whether foreach can move to next iteration or not
        public bool MoveNext()
        {
            return (++index < _people.Length);
        }

        //Reset the iteration
        public void Reset()
        {
            index = -1;
        }

        //Get current value
        public object Current
        {
            get
            {
                return _people[index];
            }
        }
    }
}