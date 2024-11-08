﻿using System;

namespace Ch06Ex01
{
    internal class Program
    {
        static string myString;
        static void Write()
        {
            //Console.WriteLine("Text output from function");
            string myString = "String defined in Write()";
            Console.WriteLine("Now in Write()");
            Console.WriteLine($"Local mySting = {myString}");
            Console.WriteLine($"Global mySting = {Program.myString}");
        }
        static void Main(string[] args)
        {
            string myString = "String defined in Main()";
            Program.myString = "Global String";
            Write();
            Console.WriteLine("\nNow in Main()");
            Console.WriteLine($"Local myString = {myString}");
            Console.WriteLine($"Global myString = {Program.myString}");
            Console.ReadKey();
        }
    }
}
