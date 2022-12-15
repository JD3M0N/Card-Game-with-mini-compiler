using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    internal class Bot_easy : Player
    {
        Random random = new Random();

        public int TerrainToPlay(Player player)
        {
            if (player.Terrains[0].Conquest == 0 && player.Terrains[1].Conquest == 0 && player.Terrains[2].Conquest == 0)
            {
                return random.Next(0, 3);
            }

            int minDifferenceTowinTerrrain = 0;
            int terrainToPlayIndex = 0;
            int difference = 0;

            for (int i = 0; i < 3; i++)
            {
                difference = 0;
                if (player.Terrains[i].Conquest > Terrains[i].Conquest)
                {
                    if (minDifferenceTowinTerrrain < Math.Abs(player.Terrains[i].Conquest - Terrains[i].Conquest))
                    {
                        minDifferenceTowinTerrrain = Math.Abs(player.Terrains[i].Conquest - Terrains[i].Conquest);
                        terrainToPlayIndex = i;
                    }
                }
            }

            return terrainToPlayIndex;
        }
        public Card CardToPlay()
        {
            Card card = new Card();

            foreach (Card card_ in CardsInHand)
            {
                while (card.Energy == null)
                {
                    if (Energy <= card_.Energy)
                    {
                        card = card_;
                    }
                }

                if (card.Energy <= card_.Energy && card.Energy <= Energy && card_.Energy <= Energy && card.Conquest < card_.Conquest)
                {
                    card = card_;
                }
            }

            return card;
        }

    }
}
