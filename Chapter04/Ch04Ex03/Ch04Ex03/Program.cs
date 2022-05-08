using System;

namespace Ch04Ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string myName = "bogdan";
            const string nicename = "bianca";
            const string sillyName = "ciupi";
            string name;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            switch (name.ToLower())
            {
                case myName:
                    Console.WriteLine("You have the same name as me!");
                    break;
                case nicename:
                    Console.WriteLine("My, what a nice name you have");
                    break;
                case sillyName:
                    Console.WriteLine("That's a very silly name.");
                    break;
            }
            Console.WriteLine($"Hello {name}");
            Console.ReadKey();
        }
    }
}
