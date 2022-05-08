using System;

namespace Ch05ExExtra5._2
{
    enum color: byte
    {
        red = 1,
        orange = 2,
        yellow = 3,
        green = 4,
        blue = 5,
        indigo = 6,
        violet = 7,
        black = 8,
        white = 9
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            byte myByteColor = (byte)color.green;
            short myShortColor = (short)color.red;
            Console.WriteLine(myByteColor);
            Console.WriteLine(myShortColor);
            string myStringColor = color.indigo.ToString();
            Console.WriteLine(myStringColor);
            Console.ReadKey();
        }
    }
}
