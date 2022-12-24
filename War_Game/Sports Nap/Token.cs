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

        public Token(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}
