using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game  
{
    public class Battle_Field
    {
        public Terrain Terrain1 = new Terrain();
        public Terrain Terrain2 = new Terrain();
        public Terrain Terrain3 = new Terrain();

        public Battle_Field()
        {
               
        }

        public Battle_Field(Terrain a, Terrain b, Terrain c)
        {
            Terrain1 = a;
            Terrain2 = b;
            Terrain3 = c;
        }

        /*public int NextTurn(Player P1, Player P2) // review error
        {
            if (P1.EndTurn && P2.EndTurn)
            {
                P1.EndTurn = false;
                Player.DrawACard(P1.CardsInHand, P1.PlayerDeck.cards);
                P2.EndTurn = false;
                Player.DrawACard(P2.CardsInHand, P2.PlayerDeck.cards);

                return turns++;
            }

            return turns;
        }*/
    }
}
