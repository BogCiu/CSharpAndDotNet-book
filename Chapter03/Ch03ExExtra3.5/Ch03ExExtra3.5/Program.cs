using System;

namespace Ch03ExExtra3._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber, thirdNumber, fourthNumber;
            Console.WriteLine("First number:");
            firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second number:");
            secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Third number:");
            thirdNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fourth number:");
            fourthNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The product of {firstNumber} and {secondNumber} " +
                $"and {thirdNumber} and {fourthNumber} is " +
                $"{firstNumber * secondNumber * thirdNumber * fourthNumber}");
            Console.ReadKey();
        }
    }
}
