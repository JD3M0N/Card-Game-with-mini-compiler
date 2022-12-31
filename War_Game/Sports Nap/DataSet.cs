using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class DataSet
    {
        public  List <Card> cardsDataSet = new List<Card>();
        public List <Deck> deckDataSet = new List<Deck>();

        public DataSet()
        {

        }
        public Card GetACard (string cardName)
        {
            foreach (Card card in cardsDataSet)
            {
                if (cardName.ToLower() == card.cardName.ToLower())
                    return card;
            }

            throw new Exception("Card not found");
        }

        public Deck GetADeck (string deckName)
        {
            foreach (Deck deck in deckDataSet)
            {
                if (deckName.ToLower() == deck.DeckName.ToLower())
                {
                    return deck;
                }
            }

            throw new Exception("Deck not found");
        }
    }
}
