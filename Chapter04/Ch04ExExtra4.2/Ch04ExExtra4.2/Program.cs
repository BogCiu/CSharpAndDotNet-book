using System;

namespace Ch04ExExtra4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool areBothNumbersAbove10;
            double var1, var2;
            do
            {
                Console.WriteLine("Give me the 1st number: ");
                var1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Now give me the 2nd number: ");
                var2 = Convert.ToDouble(Console.ReadLine());
                areBothNumbersAbove10 = (var1 >= 10) && (var2 >= 10);
            }
            while (areBothNumbersAbove10);

            Console.WriteLine($"Your numbers are {var1} and {var2}.");
            Console.ReadKey();

        }
    }
}
