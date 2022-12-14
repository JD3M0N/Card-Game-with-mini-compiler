using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Deck : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string DeckName;
        public List<Card> cards = new List<Card>();

        public Deck()
        {

        }

        public bool ValidDeck(List<Card> aDeck)
        {
            if (aDeck.Count < 12 || aDeck.Count > 12)
            {
                return false;
            }

            return true;
        }

        public static List<Card> Shuffled (List<Card> cards)
        {
            Random rand = new Random();
            List<Card> list = new List<Card>();

            for (int i = 0; i < 12; i++)
            {
                int cardRandIndex = rand.Next(0, cards.Count);
                list.Add(cards[cardRandIndex]);
                cards.RemoveAt(cardRandIndex);
            }
            foreach (Card card in list)
            {
                cards.Add(card);
            }

            return list;
        }
    }
}
