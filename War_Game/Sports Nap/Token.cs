using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Token
    {
        public string Type;
        public string Description;
        public int value = -1;
        public Token(string type, string description)
        {
            Type = type;
            Description = description;
        }

        public void GetValue (Player P1, Player P2, int turn, Card card)
        {
            switch (Description)
            {
                case "terrain.name":
                    {
                        //en el terreno que se encuentra esta carta. name
                    }
                    break;
                case "terrain.conquest":
                    {
                        // fix
                    }
                    break;
                case "terrain.cardsamount":
                    {
                        // fix
                    }
                    break;
                case "terrain.opponent.cardsamount":
                    {
                        // fix
                    }
                    break;
                case "terrain.opponent.conquest":
                    {
                        // fix
                    }
                    break;
                case "topterrain.name":
                    {
                        // fix
                    }
                    break;
                case "topterrain.conquest":
                    {
                        this.value = P1.Terrains[1].Conquest;
                    }
                    break;
                case "topterrain.cardsamount":
                    {
                        this.value = P1.Terrains[1].CardsPlayed.Count();
                    }
                    break;
                case "topterrain.opponent.conquest":
                    {
                        this.value = P2.Terrains[1].Conquest;
                    }
                    break;
                case "topterrain.opponent.cardsamount":
                    {
                        this.value = P2.Terrains[1].CardsPlayed.Count();
                    }
                    break;
                case "bottomterrain.name":
                    {
                        // fix
                    }
                    break;
                case "bottomterrain.conquest":
                    {
                        this.value = P1.Terrains[3].Conquest;
                    }
                    break;
                case "bottomterrain.cardsamount":
                    {
                        this.value = P1.Terrains[3].CardsPlayed.Count();
                    }
                    break;
                case "bottomterrain.opponent.conquest":
                    {
                        this.value = P2.Terrains[3].Conquest;
                    }
                    break;
                case "bottomterrain.opponent.cardsamount":
                    {
                        this.value = P2.Terrains[3].CardsPlayed.Count();
                    }
                    break;
                case "centerterrain.name":
                    {
                        // fix
                    }
                    break;
                case "centerterrain.conquest":
                    {
                        this.value = P1.Terrains[2].Conquest;
                    }
                    break;
                case "centerterrain.cardsamount":
                    {
                        this.value = P1.Terrains[2].CardsPlayed.Count();
                    }
                    break;
                case "centerterrain.opponent.conquest":
                    {
                        this.value = P2.Terrains[2].Conquest;
                    }
                    break;
                case "centerterrain.opponent.cardsamount":
                    {
                        this.value = P2.Terrains[2].CardsPlayed.Count();
                    }
                    break;
                case "player.cardsinhand":
                    {
                        this.value = P1.CardsInHand.Count();
                    }
                    break;
                case "player.cardsindeck":
                    {
                        this.value = P1.PlayerDeck.cards.Count();
                    }
                    break;
                case "opponent.cardsinhand":
                    {
                        this.value = P2.CardsInHand.Count();
                    }
                    break;
                case "opponent.cardsindeck":
                    {
                        this.value = P2.PlayerDeck.cards.Count();
                    }
                    break;
                case "turn":
                    {
                        this.value = turn;
                    }
                    break;
                case "card.name":
                    {
                        //fix
                    }
                    break;
                case "card.energycost":
                    {
                        this.value = card.Energy;
                    }
                    break;
                case "card.conquest":
                    {
                        this.value = card.Conquest;
                    }
                    break;
                case "move.right":
                    {
                        this.value = -1;
                    }
                    break;
                case "move.left":
                    {
                        this.value = -1;
                    }
                    break;
                case "move.center":
                    {
                        this.value = -1;
                    }
                    break;
                case "destroy":
                    {
                        this.value = -1;
                    }
                    break;
                case "discard":
                    {
                        this.value = -1;
                    }
                    break;
                case "and":
                    {
                        this.value = -1;
                    }
                    break;
                case "or":
                    {
                        this.value = -1;
                    }
                    break;
                case "lowerthan":
                    {
                        this.value = -1;
                    }
                    break;
                case "greaterthan":
                    {
                        this.value = -1;
                    }
                    break;
                case "iqualof":
                    {
                        this.value = -1;
                    }
                    break;
                case "powerup":
                    {
                        this.value = -1;
                    }
                    break;
                case "powerdown":
                    {
                        this.value = -1;
                    }
                    break;
                case "allcards":
                    {
                        this.value= -1;
                    }
                    break;
            }

            //cambiar turno y carta para una exepcion
        }
    }
}
