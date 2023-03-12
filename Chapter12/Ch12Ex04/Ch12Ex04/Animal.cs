using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    public abstract class Animal
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        public Animal(string newName) => name = newName;
        public void Feed() => Console.WriteLine($"{name} has ben fed.");
        public abstract void MakeANoise();
    }
}
