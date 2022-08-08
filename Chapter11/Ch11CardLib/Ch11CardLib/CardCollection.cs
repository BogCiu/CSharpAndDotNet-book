using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    internal class CardCollection : CollectionBase, ICloneable
    {
        public void Add(Card newCard) => List.Add(newCard);
        public void Remove(Card oldCard) => List.Remove(oldCard);
        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }
        ///<summary>
        ///Utility method for copying card instances into another CardCollection
        ///instance-used in Deck.Shuffle(). This implementation assumes that
        ///source and target collections are the same size.
        ///</summary>
        public void CopyTo(CardCollection targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        ///<summary>
        ///Check to see if the CardCollection collection contains a particular card.
        ///This calls the Cointains() method of the ArrayList for the collection,
        ///which you acces through the InnerList property.
        ///</summary>
        public bool Contains(Card card) => List.Contains(card);
        public object Clone()
        {
            CardCollection newCards = new CardCollection();
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
}
