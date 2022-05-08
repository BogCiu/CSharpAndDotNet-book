using System;

namespace Ch05ExExtra5._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your string");
            string inputString = Console.ReadLine();
            inputString = inputString.Replace("no", "yes");
            inputString = inputString.Replace("No", "Yes");
            Console.WriteLine($"Opposite day!:\n{inputString}");
            Console.ReadKey();
        }
    }
}
