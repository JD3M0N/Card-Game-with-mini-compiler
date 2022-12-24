using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class Parse
    {
        public List<Token> Parsing(string efect)
        {
            List<Token> tokens = new List<Token>();
            string[] keywords = efect.Split(' ', ':', ';');

            foreach (string keyword in keywords)
            {
                if(keyword == "and" || keyword == "or" || keyword == "lowerthan" || keyword == "lowerequalthan" || keyword == "greaterthan" || keyword == "greaterequalthan" || keyword == "equalof" || keyword == "not")
                {
                    tokens.Add(new Token("operator", keyword));
                }
                else
                {
                    tokens.Add(new Token("keyword", keyword));
                }
            }
            return tokens;
        }
    }
}
