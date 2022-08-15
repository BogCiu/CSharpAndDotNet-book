using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch11ExExtra11._1
{
    public class People : DictionaryBase, ICloneable
    {
        public void Add(Person newPerson) => Dictionary.Add(newPerson.Name, newPerson);
        public void Remove(string oldPerson) => Dictionary.Remove(oldPerson);
        public Person this[string personIndex]
        {
            get { return (Person)Dictionary[personIndex]; }
            set { Dictionary[personIndex] = value; }
        }

        public Person[] GetOldest()
        {
            Person oldestPerson = null;
            People oldestPeople = new People();
            Person currentPerson;
            foreach (DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                if (oldestPerson == null)
                {
                    oldestPerson = currentPerson;
                    oldestPeople.Add(oldestPerson);
                }
                else
                {
                    if (currentPerson > oldestPerson)
                    {
                        oldestPerson = currentPerson;
                        oldestPeople.Clear();
                        oldestPeople.Add(currentPerson);
                    }
                    else
                    {
                        if (currentPerson >= oldestPerson)
                        {
                            oldestPeople.Add(currentPerson);
                        }
                    }
                }
            }
            Person[] returnArray = new Person[oldestPeople.Count];
            int copyIndex = 0;
            foreach (DictionaryEntry p in oldestPeople)
            {
                returnArray[copyIndex] = p.Value as Person;
                copyIndex++;
            }
            return returnArray;
        }

        public object Clone()
        {
            People clone = new People();
            Person currentPerson, newPerson;
            foreach (DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                newPerson = new Person();
                newPerson.Name = currentPerson.Name;
                newPerson.Age = currentPerson.Age;
                clone.Add(newPerson);
            }
            return clone;
        }

        public IEnumerable Ages
        {
            get 
            { 
                foreach (object element in Dictionary.Values)
                    yield return (element as Person).Age;
            }
        }
    }
}
