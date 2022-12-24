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

        public void GetValue (Player P1, Player P2)
        {
            // swicth case por cada uno de los valores posibles de cada uno de los tokens
        }
    }
}
