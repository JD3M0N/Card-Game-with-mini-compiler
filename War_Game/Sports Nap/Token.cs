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
        public string nameValue = "";

        public Token()
        {

        }

        public Token(string type, string description)
        {
            Type = type;
            Description = description;
        }

        public Token(string type, string description, int value)
        {
            Type = type;
            Description = description;
            this.value = value;
        }

        public void GetValue (Player P1, Player P2, int turn, Card card)
        {
            switch (Description)
            {
                case "terrain.name":
                    {
                        this.Type = "name";
                        foreach (Terrain t in P1.Terrains)
                        {
                            if (t.CardsPlayed.Contains (card))
                            {
                                this.Description = t.Name;
                                break;
                            }
                        }
                    }
                    break;
                case "terrain.conquest":
                    {
                        this.Type = "number";
                        foreach (Terrain t in P1.Terrains)
                        {
                            if (t.CardsPlayed.Contains(card))
                            {
                                this.value = t.Conquest;
                                break;
                            }
                        }
                    }
                    break;
                case "terrain.cardsamount":
                    {
                        this.Type = "number";
                        foreach (Terrain t in P1.Terrains)
                        {
                            if (t.CardsPlayed.Contains(card))
                            {
                                this.value = t.CardsPlayed.Count;
                                break;
                            }
                        }
                    }
                    break;
                case "terrain.opponent.cardsamount":
                    {
                        //fix
                    }
                    break;
                case "terrain.opponent.conquest":
                    {
                        //fix
                    }
                    break;
                case "topterrain.name":
                    {
                        this.Type = "name";
                        this.nameValue = P1.Terrains[1].Name;
                    }
                    break;
                case "topterrain.conquest":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[1].Conquest;
                    }
                    break;
                case "topterrain.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[1].CardsPlayed.Count();
                    }
                    break;
                case "topterrain.opponent.conquest":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[1].Conquest;
                    }
                    break;
                case "topterrain.opponent.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[1].CardsPlayed.Count();
                    }
                    break;
                case "bottomterrain.name":
                    {
                        this.Type = "name";
                        this.nameValue = P1.Terrains[3].Name;
                    }
                    break;
                case "bottomterrain.conquest":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[3].Conquest;
                    }
                    break;
                case "bottomterrain.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[3].CardsPlayed.Count();
                    }
                    break;
                case "bottomterrain.opponent.conquest":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[3].Conquest;
                    }
                    break;
                case "bottomterrain.opponent.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[3].CardsPlayed.Count();
                    }
                    break;
                case "centerterrain.name":
                    {
                        this.Type = "name";
                        this.nameValue = P1.Terrains[2].Name;
                    }
                    break;
                case "centerterrain.conquest":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[2].Conquest;
                    }
                    break;
                case "centerterrain.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P1.Terrains[2].CardsPlayed.Count();
                    }
                    break;
                case "centerterrain.opponent.conquest":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[2].Conquest;
                    }
                    break;
                case "centerterrain.opponent.cardsamount":
                    {
                        this.Type = "number";
                        this.value = P2.Terrains[2].CardsPlayed.Count();
                    }
                    break;
                case "player.cardsinhand":
                    {
                        this.Type = "number";
                        this.value = P1.CardsInHand.Count();
                    }
                    break;
                case "player.cardsindeck":
                    {
                        this.Type = "number";
                        this.value = P1.PlayerDeck.cards.Count();
                    }
                    break;
                case "opponent.cardsinhand":
                    {
                        this.Type = "number";
                        this.value = P2.CardsInHand.Count();
                    }
                    break;
                case "opponent.cardsindeck":
                    {
                        this.Type = "number";
                        this.value = P2.PlayerDeck.cards.Count();
                    }
                    break;
                case "turn":
                    {
                        this.Type = "number";
                        this.value = turn;
                    }
                    break;
                case "card.name":
                    {
                        this.Type = "name";
                        this.nameValue = card.cardName;
                    }
                    break;
                case "card.energycost":
                    {
                        this.Type = "number";
                        this.value = card.Energy;
                    }
                    break;
                case "card.conquest":
                    {
                        this.Type = "number";
                        this.value = card.Conquest;
                    }
                    break;
                case "move.right":
                    {
                        this.Type = "accion";
                        this.value = -1;
                    }
                    break;
                case "move.left":
                    {
                        this.Type = "accion";
                        this.value = -1;
                    }
                    break;
                case "move.center":
                    {
                        this.Type = "accion";
                        this.value = -1;
                    }
                    break;
                case "destroy":
                    {
                        this.Type = "accion";
                        this.value = -1;
                    }
                    break;
                case "destroycards":
                    {
                        this.Type = "accion";
                        this.value = -1;
                    }
                    break;
                case "discard":
                    {
                        this.Type = "accion";
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
                case "greateriqualof":
                    {
                        this.value = -1;
                    }
                    break;
                case "loweriqualof":
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
                        this.value = -1;
                    }
                    break;
                case "(":
                    {
                        this.value = -1;
                    }
                    break;
                case ")":
                    {
                        this.value = -1;
                    }
                    break;
                case "+":
                    {
                        this.value = -1;
                    }
                    break;
                case "-":
                    {
                        this.value = -1;
                    }
                    break;
                case "*":
                    {
                        this.value = -1;
                    }
                    break;
                case "[":
                    {
                        this.value = -1;
                    }
                    break;
                case "]":
                    {
                        this.value = -1;
                    }
                    break;
            }
        }
    }
}

