﻿using System;

namespace Ch04Ex04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance, interestRate, targetBalance;
            Console.WriteLine("What is your current balance?");
            balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is your current annual interest rate (in %)?");
            interestRate = 1 + Convert.ToDouble(Console.ReadLine()) / 100.0;
            Console.WriteLine("What balance would you like to have?");
            do
            {
                targetBalance = Convert.ToDouble(Console.ReadLine());
                if (targetBalance <= balance)
                    Console.WriteLine("You must enter an amount greater than " +
                        "your current balance!\nPlease enter another value");
            } while(targetBalance <= balance);
                int totalYears = 0;
            while (balance < targetBalance)
            {
                balance *= interestRate;
                ++totalYears;
            }
            Console.WriteLine($"In {totalYears} year{(totalYears == 1 ? "" : "s")} " +
                $"you'll have a blance of {balance}.");
            if (totalYears <= 2)
                Console.WriteLine(
                    "To be honest, you really should try to do some math in your head.");
            Console.ReadKey();
        }
    }
}
