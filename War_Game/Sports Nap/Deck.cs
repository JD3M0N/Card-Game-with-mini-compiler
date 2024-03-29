﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Deck
    {
        public string DeckName;
        public List<Card> cards = new List<Card>();
        public int DeckID;

        public Deck()
        {
            Random random = new Random();
             DeckID =  random.Next(10000, 100000000);
        }
        public Deck(int deckID)
        {
            this.DeckID = deckID;
        }

        public bool ValidDeck(List<Card> aDeck)
        {
            if (aDeck.Count < 12 || aDeck.Count > 12)
            {
                return false;
            }

            return true;
        }

        public List<Card> Shuffled ()
        {
            Random rand = new Random();
            List<Card> list = new List<Card>();

            while (cards.Count() != 0)
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

        public bool Validator ()
        {
            if (this.cards.Count != 12)
            {
                return false;
            }

            List<Card> Templist = new List<Card>();

            foreach (Card card in this.cards)
            {
                if (Templist.Contains(card))
                {
                    return false;
                }
                Templist.Add(card);
            }

            return true;
        }

        public int GetDeckID()
        {
            return DeckID;
        }
    }
}
