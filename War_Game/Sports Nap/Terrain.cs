using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Terrain
    {
        public string Name = "";
        public int Conquest = 0;
        private List<Card> cardsPlayed = new List<Card>(); 
        //public Effect Effecto; 

        public Terrain()
        {
            
        }


        //check that a player didn't play more then 4 cards
        public List<Card> CardsPlayed
        {
            get { return cardsPlayed; }
            set 
            {
                if(value.Count > 4)
                {
                    //lanza un error pq no se pueden jugar mas de 4 cartas en un mismo campo
                }
                else
                {
                    cardsPlayed = value;
                }
            }
        }

        public static bool TerrainHaveSpace(Terrain t)
        {
            if(t.CardsPlayed.Count < 4)
            {
                return true;
            }
            return false;
        }

        // crear terreno solo con nombre y efecto
    }
}
