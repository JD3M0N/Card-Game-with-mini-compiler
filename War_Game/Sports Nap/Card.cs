using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Card
    {
        public string cardName;
        public int Energy;
        public int Conquest;
        public Effect Effecto;

        public Card ()
        {

        }

        public Card (string aCardName, int aEnergy, int aConquest, Effect aEffect)
        {
            cardName = aCardName;
            Energy = aEnergy;
            Conquest = aConquest;
            Effecto = aEffect;
        }

        public static bool CardCanBePlayed(Player p, Card c)
        {
            if(p.Energy < c.Energy)
            {
                return false;
            }
            return true;
        }
    }
}
