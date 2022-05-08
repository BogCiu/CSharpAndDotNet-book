using System;

namespace Ch05ExExtra5._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your string:");
            string inputString = Console.ReadLine();
            Console.WriteLine($"Input string length is {inputString.Length}");

            string reverseString = "";
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(inputString[i]);
                reverseString += inputString[i];
            }
            Console.WriteLine(reverseString);
            Console.ReadKey();
        }
    }
}
