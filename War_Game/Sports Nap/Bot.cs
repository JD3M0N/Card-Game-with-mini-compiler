using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Bot : Player
    {
        public static void BotPlay (Player bot, Player player)
        {
            Card cardToPlay = bot.CardsInHand[1];

            foreach (Card card in bot.CardsInHand)
            {
                if (card.Energy <= bot.Energy && card.Conquest > cardToPlay.Conquest)
                {
                    cardToPlay = card;
                }
            }

            int terrainToPlayIndex = 0;
            int minDifferenceToPlay = 0;
            int differenceToPlay = 0;

            for (int i = 0; i < 3; i++)
            {
                differenceToPlay = bot.Terrains[i].Conquest - player.Terrains[i].Conquest;

                if (minDifferenceToPlay > 0 && minDifferenceToPlay > differenceToPlay)
                {
                    minDifferenceToPlay = 0;
                }
                if (differenceToPlay < 0 && differenceToPlay > minDifferenceToPlay)
                {
                    terrainToPlayIndex = i;
                }
                if (differenceToPlay < 0)
                {
                    minDifferenceToPlay = differenceToPlay;
                }
            }

            ConsoleApp.PlayACard(bot, cardToPlay, terrainToPlayIndex);
        }
    }
}
