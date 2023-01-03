using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Parse
    {
        public static List<Token> Parsing(string efect)
        {
            List<Token> tokens = new List<Token>();
            string[] keywords = efect.Split(' ');

            foreach (string keyword in keywords)
            {
                if (keyword == "+" || keyword == "*" || keyword == "-" || keyword == "[" || keyword == "]" || keyword == "(" || keyword == ")" || keyword == "and" || keyword == "or" || keyword == "lowerthan" || keyword == "lowerequalthan" || keyword == "greaterthan" || keyword == "greaterequalthan" || keyword == "equalof" || keyword == "not" || keyword == ";" || keyword == ":")
                {
                    tokens.Add(new Token("symbol", keyword));
                }
                else
                {
                    if (keyword == "true" || keyword == "false")
                    {
                        tokens.Add(new Token("boolean", keyword));
                    }
                    else
                    {
                        if (IsNumber(keyword))
                        {
                            tokens.Add(new Token("number", keyword, int.Parse(keyword)));
                        }
                        else
                        {

                            if (IsToken(keyword))
                            {
                                tokens.Add(new Token("value", keyword));

                            }
                            else
                            {
                                throw new Exception($"{keyword} is not a keyword");
                            }
                        }
                    }
                }
            }
            return tokens;
        }

        public static bool IsToken(string token)
        {
            if (token == "destroycards" || token == "[" || token == "]" || token == "true" || token == "false" || token == "(" || token == ")" || token == "terrain.name" || token == "terrain.conquest" ||token == "terrain.opponent.conquest" ||token == "terrain.opponent.cardsamount" || token == "terrain.cardsamount" || token == "topterrain.name" || token == "topterrain.conquest" ||token == "topterrain.opponent.conquest" ||token == "topterrain.opponent.cardsamount" ||token == "topterrain.cardsamount" || token == "centerterrain.name" || token == "centerterrain.conquest" ||token == "centerterrain.opponent.conquest" ||token == "centerterrain.opponent.cardsamount" ||token == "centerterrain.cardsamount" || token == "bottomterrain.name" ||token == "bottomterrain.conquest" ||token == "bottomterrain.cardsamount" ||token == "bottomterrain.opponent.cardsamount" ||token == "bottomterrain.opponent.conquest" ||token == "player.cardsinhand" ||token == "player.cardsindeck" ||token == "opponent.cardsinhand" ||token == "opponent.cardsindeck" ||token == "card.energycost" ||token == "card.consquest" ||token == "card.name" ||token == "turn" ||token == "allcards" ||token == "destroy" ||token == "move.right" ||token == "discard" ||token == "move.left" ||token == "move.center" || token == "empty" ||token == "powerup" ||token == "powerdown" ||token == "and" || token == "or" || token == "lowerthan" ||token == "greaterthan" ||token == "iqualof" || token == "loweriqualof" || token == "greateriqualof" || token == ";" || token == ":" || token == "Empty" || token == "+" || token == "-" || token == "*")
            {
                return true;
            }

            return false;
        }

        public static bool IsNumber(string token)
        {
            try
            {
                int temp = int.Parse(token);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static List<Token> GetCondition (List<Token> tokenList)
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (tokenList[i].Description == ":")
                {
                    return tokenList.GetRange(0, i);
                }
            }

            throw new Exception("Not valid effect");
        }

        public static List<Token> GetEffect (List<Token> tokenList)
        {
            int index = 0;

            for (int i = 0; i < tokenList.Count; i++)
            {
                if (tokenList[i].Description == ":")
                {
                    index = i;
                }
                if (tokenList[i].Description == ";")
                {
                    return tokenList.GetRange(index +1, i -1);
                }
            }

            throw new Exception("Not valid effect");
        }
    }
}
// textear el parser 
// hacer un for por toda la lista de localizacioones 