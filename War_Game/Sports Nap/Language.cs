using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    internal class Language
    {
        public void DestroyACard (Player P1, int TerrainIndex, Card card)
        {
            P1.Terrains[TerrainIndex].CardsPlayed.Remove(card);
        }

        public void MoveACard (Player p, int start, int end, Card card)
        {
            p.Terrains[start].CardsPlayed.Remove (card);
            p.Terrains[end].CardsPlayed.Add (card);
        }

        public void DiscardACard (Player p, Card card)
        {
            p.CardsInHand.Remove(card);
        }

        public void PowerUp (Card card, int power)
        {
            card.Conquest += power;
        }

        public void PowerDown (Card card, int power)
        {
            card.Conquest -= power;
        }
    }
}
