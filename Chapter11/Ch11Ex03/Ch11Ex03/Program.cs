﻿using System;

namespace Ch11Ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Primes primesFrom2To1000 = new Primes(2, 100000);
            foreach (long i in primesFrom2To1000)
                Console.Write($"{i} ");
            Console.ReadKey();
        }
    }
}