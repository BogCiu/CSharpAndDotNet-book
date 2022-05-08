using System;

namespace Ch05Ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friendNames = { "Todd Anthony", "Mary Chris", "Autry Rual" }; // Mary Chris is an undecided transgeder or what? And Autry Rual...is stealing our jeerbs :^)
            int i;
            Console.WriteLine($"Here are {friendNames.Length} of my friends:");
            //for (i = 0; i < friendNames.Length; i++)
            //{
            //    Console.WriteLine(friendNames[i]);
            //}
            foreach(string friendName in friendNames)
            {
                Console.WriteLine(friendName);
            }
            Console.ReadKey();
        }
    }
}
