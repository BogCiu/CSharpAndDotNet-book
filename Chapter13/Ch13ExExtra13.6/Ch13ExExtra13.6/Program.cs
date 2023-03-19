using System;
using System.Runtime.CompilerServices;

namespace Ch13ExExtra13._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string helloWorld = "Hello World!";
            Console.WriteLine(helloWorld);
            string acronymWorld = Extension.ToAcronym(helloWorld);
            Console.WriteLine(acronymWorld);
            string acronymWorld2 = Extension.ToAcronym2(helloWorld);
            Console.WriteLine(acronymWorld2);
        }
    }
}
