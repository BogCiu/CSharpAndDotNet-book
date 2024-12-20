﻿using System;
using BeginningCSharp;

namespace Ch18CardClientCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[2];
            Console.Write("Enter the name of player #1: ");
            players[0] = new Player(Console.ReadLine());
            Console.Write("Enter the name of player #2: ");
            players[1] = new Player(Console.ReadLine());

            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();

            Console.WriteLine($"{players[0].Name} recieved this hand: ");
            foreach (var card in players[0].PlayHand)
            {
                Console.WriteLine($"{card.rank} of {card.suit}s");
            }

            Console.WriteLine($"{players[1].Name} recieved this hand: ");
            foreach (var card in players[1].PlayHand)
            {
                Console.WriteLine($"{card.rank} of {card.suit}s");
            }
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

        }
    }
}
