using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ch13CardClient
{
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player() { } 
        public Player (string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        public Cards BiggestWorkableRankSet(Cards inputHand)
        {
            Cards hand = new();
            for (int i = 0; i < inputHand.Count; i++)
            {
                hand.Add(inputHand[i]);
            }
            // Sort the hand first for easier comparisons
            // hand.Sort();
            Dictionary<Rank, int> setCount = new Dictionary<Rank, int>();
            setCount[Rank.Ace] = 0;
            setCount[Rank.Duece] = 0;
            setCount[Rank.Three] = 0;
            setCount[Rank.Four] = 0;
            setCount[Rank.Five] = 0;
            setCount[Rank.Six] = 0;
            setCount[Rank.Seven] = 0;
            setCount[Rank.Eight] = 0;
            setCount[Rank.Nine] = 0;
            setCount[Rank.Ten] = 0;
            setCount[Rank.Jack] = 0;
            setCount[Rank.Queen] = 0;
            setCount[Rank.King] = 0;
            Cards returnCards = new();
            Card activeCard = hand[0];

            // Count all the occurences for each rank
            foreach (Card card in hand)
                setCount[card.rank] += 1;

            // Get the max rank count and corresponding rank(s)
            int maxSetCount = 0;
            Rank maxSetRank = Rank.Ace;
            Rank maxSetRank2 = Rank.Ace;
            foreach (KeyValuePair<Rank,int> dict in setCount)
            {
                if (maxSetCount < dict.Value)
                {
                    maxSetCount = dict.Value;
                    maxSetRank = dict.Key;
                    maxSetRank2 = dict.Key;
                }
                else if (maxSetCount == dict.Value)
                {
                    maxSetRank2 = dict.Key;
                }
            }

            // If max rank is 4, return that hand; if it's 3 and there's no 2 sets of 3's, return that, else return nothing
            if (maxSetCount == 4)
            {
                foreach (Card card in hand)
                {
                    if (card.rank == maxSetRank)
                    {
                        returnCards.Add(card);
                    }
                }
            }
            else if (maxSetCount == 3)
            {
                if (maxSetRank == maxSetRank2)
                {
                    foreach (Card card in hand)
                        if (card.rank == maxSetRank2)
                        {
                            returnCards.Add(card);
                        }
                }
            }
            // Else it's not a winnable hand so I'm returning an empty hand
            Console.WriteLine($"----------Found a RANK set of {returnCards.Count} cards of the rank {maxSetRank}");
            return returnCards;
        }
        private Cards BiggestWorkableSuiteSet(Cards inputHand)
        {
            Cards hand = new();
            for (int i = 0; i < inputHand.Count; i++)
            {
                hand.Add(inputHand[i]);
            }

            Dictionary<Suit, int> setCount = new Dictionary<Suit, int>();
            setCount[Suit.Spade] = 0;
            setCount[Suit.Club] = 0;
            setCount[Suit.Heart] = 0;
            setCount[Suit.Diamond] = 0;
            Cards returnCards = new();
            Card activeCard = hand[0];

            // Count all the occurences for each suit
            foreach (Card card in hand)
                setCount[card.suit] += 1;

            // Get the max suit count and corresponding suit(s)
            int maxSetCount = 0;
            Suit maxSetSuit = Suit.Spade;
            Suit maxSetSuit2 = Suit.Spade;
            foreach (KeyValuePair<Suit, int> dict in setCount)
            {
                if (maxSetCount < dict.Value)
                {
                    maxSetCount = dict.Value;
                    maxSetSuit = dict.Key;
                    maxSetSuit2 = dict.Key;
                }
                else if (maxSetCount == dict.Value)
                {
                    maxSetSuit2 = dict.Key;
                }
            }

            // If max suit is 7, 4 or 3, return that hand
            if (maxSetCount == 7)
            {
                for (int i = 0; i < inputHand.Count; i++)
                {
                    returnCards.Add(inputHand[i]);
                }
            }
            else if ((maxSetCount == 4) || (maxSetCount == 3))
            {
                foreach (Card card in hand)
                {
                    if (card.suit == maxSetSuit)
                    {
                        returnCards.Add(card);
                    }
                }
            }
            // Else it's not a winnable hand so I'm returning an empty hand
            Console.WriteLine($"----------Found a SUIT set of {returnCards.Count} cards of the suit {maxSetSuit}");
            return returnCards;
        }

        public bool HasWonRummy()
        {
            bool won = false;
            Cards biggestRankSet = BiggestWorkableRankSet(PlayHand);

            // If biggestRankSet is 4 - we look for a 2nd set, of 3 cards of a (different) rank or suite
            if (biggestRankSet.Count == 4)
            {
                Cards temporaryPlayHand = new();

                for (int i = 0; i < PlayHand.Count; i++)
                {
                    temporaryPlayHand.Add(PlayHand[i]);
                }
                foreach (Card singleCard in biggestRankSet)
                {
                    temporaryPlayHand.Remove(singleCard);
                }
                // Look for a set of Rank cards again
                Cards secondsetEvaluation = BiggestWorkableRankSet(temporaryPlayHand);
                if (secondsetEvaluation.Count == 3)
                {
                    won = true;
                }
                // Look for a set of Suite cards instead
                else
                {
                    secondsetEvaluation = BiggestWorkableSuiteSet(temporaryPlayHand);
                    if (secondsetEvaluation.Count == 3)
                    {
                        won = true;
                    }
                    else
                    {
                        won = false;
                    }
                }
            }
            // If biggestRankSet is 3, the only valid winning condition is a set of 4 cards of a suite
            else if (biggestRankSet.Count == 3)
            {
                Cards temporaryPlayHand = new();
                for (int i = 0; i < PlayHand.Count; i++)
                {
                    temporaryPlayHand.Add(PlayHand[i]);
                }
                foreach (Card singleCard in biggestRankSet)
                {
                    temporaryPlayHand.Remove(singleCard);
                }
                Cards secondsetEvaluation = BiggestWorkableSuiteSet(temporaryPlayHand);
                if (secondsetEvaluation.Count == 4)
                {
                    won = true;
                }
                else
                {
                    won = false;
                }
            }
            // All the winning conditions from here involve having 2 sets of suites (or 7 cards of the same suite)
            else
            {
                Cards biggestSuiteSet = BiggestWorkableSuiteSet(PlayHand);
                if (biggestSuiteSet.Count == 7)
                {
                    won = true;
                }
                else if (biggestSuiteSet.Count == 4)
                {
                    Cards temporaryPlayHand = new(); 
                    for (int i = 0; i < PlayHand.Count; i++)
                    {
                        temporaryPlayHand.Add(PlayHand[i]);
                    }
                    foreach (Card singleCard in biggestSuiteSet)
                    {
                        temporaryPlayHand.Remove(singleCard);
                    }
                    Cards secondsetEvaluation = BiggestWorkableSuiteSet(temporaryPlayHand);
                    if (secondsetEvaluation.Count == 3)
                    {
                        won = true;
                    }
                    else
                    {
                        won = false;
                    }
                }
                else
                {
                    won = false;
                }
            }

            return won;
        }

        public bool HasWon()
        {

            bool won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].suit == match;
                if (won == false)
                    break;
            }
            return won;
        }
    }
}
