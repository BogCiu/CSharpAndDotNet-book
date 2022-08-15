using System;

namespace Ch11ExExtra11._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            People myFriends = new People();
            Person myPerson1 = new Person();
            myPerson1.Name = "Andu";
            myPerson1.Age = 36;
            Person myPerson2 = new Person();
            myPerson2.Name = "Cristina";
            myPerson2.Age = 28;
            myFriends.Add(myPerson1);
            myFriends.Add(myPerson2);

            Console.WriteLine($"My friend is {myFriends["Cristina"].Name} and her age is {myFriends["Cristina"].Age}.");
            Console.WriteLine($"Her boyfriend is {myFriends["Andu"].Name} and his age is {myFriends["Andu"].Age}.");
            myFriends.Remove("Andu");
            Console.WriteLine($"I had an argument and now my friend's list has {myFriends.Count} member(s) in it.");
            myFriends.Add(myPerson1);

            Person myPerson3 = new Person();
            myPerson3.Age = 28;
            myPerson3.Name = "Bogdan";
            myFriends.Add(myPerson3);

            Console.WriteLine($"myPerson1 > myPerson2 = {myPerson1 > myPerson2}");
            Console.WriteLine($"myPerson2 > myPerson3 = {myPerson2 > myPerson3}");
            Console.WriteLine($"myPerson2 >= myPerson3 = {myPerson2 >= myPerson3}");

            foreach(Person individual in myFriends.GetOldest())
            {
                Console.WriteLine(individual.Name);
            }

            People myOtherFriendsList = (People)myFriends.Clone();
            Console.WriteLine(myOtherFriendsList["Bogdan"].Name);

            Console.WriteLine("Varstele noastre");
            foreach (int age in myFriends.Ages)
            {
                Console.WriteLine(age);
            }
        }
    }
}
