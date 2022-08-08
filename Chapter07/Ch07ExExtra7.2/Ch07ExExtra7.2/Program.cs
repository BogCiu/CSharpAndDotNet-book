using System;

namespace Ch07ExExtra7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[5000];
            for (int i =0; i < 5001; i++)
            {
                myArray[i] = i;
            }
        }
    }
}
