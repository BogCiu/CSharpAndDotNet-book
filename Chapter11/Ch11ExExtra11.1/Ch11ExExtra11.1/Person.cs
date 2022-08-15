using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11ExExtra11._1
{
    public class Person
    {
        private string name;
        private int age;
        public string Name {get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

        public static bool operator >(Person person1, Person person2)
        {
            return person1.Age > person2.Age;
        }
        public static bool operator <(Person person1, Person person2)
        {
            return person1.Age < person2.Age;
        }
        public static bool operator >=(Person person1, Person person2)
        {
            return person1.Age >= person2.Age;
        }
        public static bool operator <=(Person person1, Person person2)
        {
            return person1.Age <= person2.Age;
        }

    }
}
