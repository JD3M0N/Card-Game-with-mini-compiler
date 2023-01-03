using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    internal class Language
    {
        public static void DestroyACard(Player P1, int TerrainIndex)
        {
            Random r = new Random();
            Card cardDestroyed = P1.Terrains[TerrainIndex].CardsPlayed[r.Next(0, P1.Terrains[TerrainIndex].CardsPlayed.Count())];
            if (P1.Terrains[TerrainIndex].CardsPlayed.Count() != 0)
            {
                P1.Terrains[TerrainIndex].CardsPlayed.Remove(cardDestroyed);
            }

            Console.WriteLine($"{cardDestroyed.cardName} was destroyed in terrain #{TerrainIndex}");
        }

        public static void DestroyCards(Player P1, int TerrainIndex, int cardToDestroy)
        {
            Random random = new Random();
            int terrainCards = P1.Terrains[TerrainIndex].CardsPlayed.Count();
            if (terrainCards <= cardToDestroy)
            {
                foreach (Card card in P1.Terrains[TerrainIndex].CardsPlayed)
                {
                    P1.Terrains[TerrainIndex].CardsPlayed.Remove(card);
                }
                return;
            }
            List <string> cardsDestroyed = new List <string>();
            if (terrainCards > cardToDestroy)
            {
                for (int i = 0; i < cardToDestroy; i++)
                {
                    Card cardDestroyed = P1.Terrains[TerrainIndex].CardsPlayed[random.Next(0, P1.Terrains[TerrainIndex].CardsPlayed.Count())];
                    cardsDestroyed.Add(cardDestroyed.cardName);
                    P1.Terrains[TerrainIndex].CardsPlayed.Remove(cardDestroyed);
                }

                string cardsdetroyed = "";
                foreach (string name in cardsDestroyed)
                {
                    cardsdetroyed += $" !{name}!";
                }

                Console.WriteLine($"{cardsdetroyed} were destroyed in terrain #{TerrainIndex}");
                return;
            }
        }

        public static void MoveACard(Player p, int start, int end, Card card)
        {
            p.Terrains[start].CardsPlayed.Remove(card);
            p.Terrains[end].CardsPlayed.Add(card);
        }

        public static void DiscardACard(Player p)
        {
            Random r = new Random();
            int cardsInHand = p.CardsInHand.Count();
            Card discarded = p.CardsInHand[r.Next(0, cardsInHand)];
            p.CardsInHand.Remove(discarded);

            Console.WriteLine($"{discarded.cardName} was descarted from {p.NickName}'s hand");
        }

        public static void PowerUp(Card card, int power)
        {
            card.Conquest += power;

            Console.WriteLine($"{card.cardName} was upgraded by {power} conquest points");
        }

        public static void PowerDown(Card card, int power)
        {
            card.Conquest -= power;

            Console.WriteLine($"{card.cardName} was degraded by {power} conquest points");
        }

        public static void Empty ()
        {

        }
    }
}
