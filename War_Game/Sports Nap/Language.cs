using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    internal class Language
    {
        public static string DestroyACard(Player P1, int TerrainIndex)
        {
            if (P1.Terrains[TerrainIndex].CardsPlayed.Count != 0)
            {

                Random r = new Random();
                Card cardDestroyed = P1.Terrains[TerrainIndex].CardsPlayed[r.Next(0, P1.Terrains[TerrainIndex].CardsPlayed.Count())];
                if (P1.Terrains[TerrainIndex].CardsPlayed.Count() != 0)
                {
                    P1.Terrains[TerrainIndex].CardsPlayed.Remove(cardDestroyed);
                }

                return $"{cardDestroyed.cardName} was destroyed in terrain #{TerrainIndex + 1}";
            }

            return "No cards to destroy";
        }

        public static string DestroyCards(Player P1, int TerrainIndex, int cardToDestroy)
        {
            Random random = new Random();
            int terrainCards = P1.Terrains[TerrainIndex].CardsPlayed.Count();

            List<string> cardsDestroyed = new List<string>();

            if (terrainCards <= cardToDestroy)
            {
                foreach (Card card in P1.Terrains[TerrainIndex].CardsPlayed)
                {
                    cardsDestroyed.Add(card.cardName);
                    P1.Terrains[TerrainIndex].CardsPlayed.Remove(card);
                }
                string cardsdetroyed = "";
                foreach (string name in cardsDestroyed)
                {
                    cardsdetroyed += $" !{name}!";
                }
                return $"{cardsdetroyed} were destroyed in terrain #{TerrainIndex + 1}";
            }

            cardsDestroyed.Clear();

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

                return $"{cardsdetroyed} were destroyed in terrain #{TerrainIndex + 1}";
            }

            return "";
        }

        public static string MoveACard(Player p, int start, int end, Card card)
        {
            if (start == end)
            {
                return $"{card.cardName} couldn't be move";
            }
            p.Terrains[start].CardsPlayed.Remove(card);
            p.Terrains[start].Conquest -= card.Conquest;
            p.Terrains[end].CardsPlayed.Add(card);
            p.Terrains[end].Conquest += card.Conquest;

            return $"{card.cardName} was moved from terrain: {start + 1} to terrain {end + 1}";
        }

        public static string DiscardACard(Player p)
        {
            if (p.CardsInHand.Count != 0)
            {
                Random r = new Random();
                int cardsInHand = p.CardsInHand.Count();
                Card discarded = p.CardsInHand[r.Next(0, cardsInHand)];
                p.CardsInHand.Remove(discarded);

                return $"{discarded.cardName} was descarted from {p.NickName}'s hand";
            }

            return "No cards to discard";
        }

        public static string PowerUp(Card card, int power, Terrain t)
        {
            card.Conquest += power;
            t.Conquest += power;

            return $"{card.cardName} was upgraded by {power} conquest points";
        }

        public static string PowerDown(Card card, int power, Terrain t)
        {
            card.Conquest -= power;
            t.Conquest -= power;

            return $"{card.cardName} was degraded by {power} conquest points";
        }

        public static string Empty()
        {
            return "Empty effect.";
        }
    }
}
