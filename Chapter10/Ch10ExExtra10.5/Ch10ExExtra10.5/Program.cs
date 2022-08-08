using System;
using Ch10CardLib;

namespace Ch10ExExtra10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Deck myDeck = new Deck();
                myDeck.Shuffle();
                int cardsDrawn = 0;
                bool flushGained = false;
                while (cardsDrawn <50 )
                {
                    Card[] drawnCards = new Card[5];
                    for (int i = cardsDrawn; i< cardsDrawn + 5; i++)
                    {
                        drawnCards[i-cardsDrawn] = myDeck.GetCard(i);
                    }

                    if ((drawnCards[0].suit == drawnCards[1].suit) &
                        (drawnCards[1].suit == drawnCards[2].suit) &
                        (drawnCards[2].suit == drawnCards[3].suit) &
                        (drawnCards[3].suit == drawnCards[4].suit))
                    {
                        flushGained = true;
                        Console.WriteLine($"{drawnCards[0].ToString()}, " +
                            $"{drawnCards[1].ToString()}, " +
                            $"{drawnCards[2].ToString()}, " +
                            $"{drawnCards[3].ToString()}, " +
                            $"{drawnCards[4].ToString()}.\n\nFlush!");
                            Console.ReadKey();
                        break;
                    }
                    cardsDrawn += 5;
                }
                if (flushGained == false)
                    Console.WriteLine("No flush.");
            }

        }
    }
}
