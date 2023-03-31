using System;
using System.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNET_16_6_LargeNumberQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arraySizes = { 100, 1000, 10000, 10000, 1000000, 5000000, 10000000, 50000000 };
            foreach (int i in arraySizes)
            {
                int[] numbers = GenerateLotsOfNumbers(i);
                var queryResults = from n in numbers
                                   // Modifications for Ex16.4
                                   where n > 1000
                                   // where n < 1000
                                   // Modifications end
                                   // Modifications for Ex16.3
                                   orderby n
                                   // Modifications end
                                   select n;
                // Modifications for Ex16.2
                WriteLine("number array size = {0}: Count (n<1000) = {1}", numbers.Length, queryResults.Count());
                //foreach (var item in queryResults)
                //{
                //    WriteLine(item);
                //}
                // Modifications end
            }
            Write("Program finished, press Enter/Return to continue");
            ReadKey();
        }

        private static int[] GenerateLotsOfNumbers(int count)
        {
            Random generator = new Random(0);
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = generator.Next();
            }
            return result;
        }
    }
}
