using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Effect
    {
        public List<Token> effect = new List<Token>();
        public Effect()
        {

        }

        public Effect(List<Token> tokenList)
        {
            foreach (Token token in tokenList)
            {
                effect.Add(token);
            }
        }
    }
}
