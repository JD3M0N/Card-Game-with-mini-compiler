using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Player
    {
        public string NickName;
        public Deck PlayerDeck;
        public List<Card> CardsInHand;
        public int Energy;
        public bool EndTurn = false;
        public Terrain [] Terrains = new Terrain [3];
        public Terrain [] PublicTerrain = new Terrain [3];

        public Player ()
        {

        }

        public Player(string NickName, Deck PlayerDeck)
        {
            this.NickName = NickName;
            this.PlayerDeck = PlayerDeck;
            CardsInHand = new List<Card>();
            Energy = 1;

            for (int i = 0; i < 3; i++)
            {
                DrawACard();
            }
            
            for (int i = 0; i < 3; i++)
            {
                Terrains[i] = new Terrain();
            }
        }
        public string nickName
        {
            get { return nickName; }
            set
            {
                if (value.Length == 0 || value.Length > 12)
                {
                    Random r = new Random();
                    NickName = "Username" + r.Next(100, 999);
                }
                else
                {
                    NickName = value;
                }
            }
        }

        public void DrawACard ()
        {
            CardsInHand.Add(PlayerDeck.cards.Last());
            PlayerDeck.cards.Remove(PlayerDeck.cards.Last());
        }

        public void UpdatePublicTerrain ()
        {
            for (int i = 0; i < 3; i++)
            {
                PublicTerrain[i] = Terrains[i];
            }
        }
    }
}

// crear metodo pick card que cre3ee una instancia de deck para el player 