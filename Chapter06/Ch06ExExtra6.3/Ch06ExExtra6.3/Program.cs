using System;

namespace Ch06ExExtra6._3
{
    internal class Program
    {
        delegate string ReadLineDelegate();
        static void Main(string[] args)
        {
            ReadLineDelegate readLine;
            Console.WriteLine("Please input a parameter");
            readLine = new ReadLineDelegate(Console.ReadLine);
            string input = readLine();
            Console.WriteLine($"You typed: {input}");
        }
    }
}
