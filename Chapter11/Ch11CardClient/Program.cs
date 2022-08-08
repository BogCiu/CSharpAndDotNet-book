using System;
using Ch11CardLib;

namespace Ch11CardClient
{
    internal class Program
    {
        static void ClientTest1()
        {
            Deck deck1 = new Deck();
            Deck deck2 = (Deck)deck1.Clone();
            Console.WriteLine($"The first card in the original deck is : {deck1.GetCard(0)}");
            Console.WriteLine($"The first card in the cloned deck is : {deck2.GetCard(0)}");
            deck1.Shuffle();
            Console.WriteLine("Original deck shuffled.");
            Console.WriteLine($"The first card in the original deck is : {deck1.GetCard(0)}");
            Console.WriteLine($"The first card in the cloned deck is : {deck2.GetCard(0)}");
            Console.ReadKey();
        }
        static void ClientTest2()
        {
            Card.isAceHigh = true;
            Console.WriteLine("Aces are high");
            Card.useTrumps = true;
            Card.trump = Suit.Club;
            Console.WriteLine("Clubs are trumps");
            Card card1, card2, card3, card4, card5;
            card1 = new Card(Suit.Club, Rank.Five);
            card2 = new Card(Suit.Club, Rank.Five);
            card3 = new Card(Suit.Club, Rank.Ace);
            card4 = new Card(Suit.Heart, Rank.Ten);
            card5 = new Card(Suit.Diamond, Rank.Ace);
            Console.WriteLine($"{card1} == {card2} ? {card1 == card2}");
            Console.WriteLine($"{card1} != {card3} ? {card1 != card3}");
            Console.WriteLine($"{card1}.Equals({card4}) ? {card1.Equals(card4)}");
            Console.WriteLine($"Card.Equals({card3}, {card4}) ? {Card.Equals(card3, card4)}");
            Console.WriteLine($"{card1} > {card2} ? {card1 > card2}");
            Console.WriteLine($"{card1} <= {card3} ? {card1 <= card3}");
            Console.WriteLine($"{card1} > {card4} ? {card1 > card4}");
            Console.WriteLine($"{card4} > {card1} ? {card4 > card1}");
            Console.WriteLine($"{card5} > {card4} ? {card5 > card4}");
            Console.WriteLine($"{card4} > {card5} ? {card4 > card5}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            //ClientTest1();
            ClientTest2();
        }
    }
}
