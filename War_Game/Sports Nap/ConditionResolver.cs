using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class ConditionResolver
    {
        public bool ResolveCondition(List<Token> tokenList)
        {
            //GetValues needs to be updated 

            for (int i = 0; i < tokenList.Count; i++)
            {
                if (tokenList[i].Type == "number")
                {
                    List<Token> newList = new List<Token>();
                    newList.Add(tokenList[i]);
                    newList.Add(tokenList[i+1]);
                    newList.Add(tokenList[i+2]);
                    bool tempComp = EatComparation(newList);
                    tokenList.RemoveRange(i, i+2);
                    tokenList.Insert(i, new Token("boolean", tempComp.ToString()));
                }
            }
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (!tokenList[i].Type.Equals("name"))
                {
                    bool tempComp = EatName(tokenList[i], tokenList[i+2]);
                    tokenList.RemoveRange(i, i+2);
                    tokenList.Insert(i, new Token("boolean", tempComp.ToString()));
                }
            }
            while (tokenList.Count > 1)
            {
                int lasIndexOf = -1;
                for (int j = 0; j < tokenList.Count; j++)
                {
                    if (lasIndexOf > tokenList.Count)
                    {
                        lasIndexOf = -1;
                    }
                    if (tokenList[j].Description == "(")
                    {
                        lasIndexOf = j;
                    }
                    if (tokenList[j].Description == ")")
                    {
                        bool temp = CalculateExpresion(tokenList.GetRange(lasIndexOf, j));
                        tokenList.RemoveRange(lasIndexOf, j);
                        tokenList.Insert(lasIndexOf, new Token("boolean", temp.ToString()));
                    }
                }
            }

            if (tokenList[0].Description == "true")
            {
                return true;
            }
            return false;
        }

        public bool EatComparation(List<Token> tokenList)
        {
            if (tokenList[1].Description == "lowerthan")
            {
                return (tokenList[0].value < tokenList[2].value);
            }
            if (tokenList[1].Description == "loweriqualof")
            {
                return (tokenList[0].value <= tokenList[2].value);
            }
            if (tokenList[1].Description == "greaterthan")
            {
                return (tokenList[0].value > tokenList[2].value);
            }
            if (tokenList[1].Description == "greateriqualof")
            {
                return (tokenList[0].value >= tokenList[2].value);
            }
            if (tokenList[1].Description == "iqualof")
            {
                return (tokenList[0].value == tokenList[2].value);
            }

            return false;
        }

        public bool EatName(Token a, Token b)
        {
            if (a.nameValue == b.nameValue)
            {
                return true;
            }
            return false;
        }

        public bool CalculateExpresion (List<Token> tokenList)
        {
            if (tokenList.Count == 3)
            {
                if (tokenList[1].Description == "true")
                {
                    return true;
                }
                return false;
            }

            if (tokenList[2].Description == "and")
            {
                bool a = false;
                bool b = false;

                if (tokenList[1].Description == "true")
                {
                    a = true;
                }
                if (tokenList[3].Description == "true")
                {
                    b = true;
                }

                return (a && b);
            }
            if (tokenList[2].Description == "or")
            {
                bool a = false;
                bool b = false;

                if (tokenList[1].Description == "true")
                {
                    a = true;
                }
                if (tokenList[3].Description == "true")
                {
                    b = true;
                }

                return (a || b);
            }
            return false;
        }

        public void UpdateTokensValues(List<Token> tokenList, Player P1, Player P2, int turn, Card card)
        {
            foreach (Token token in tokenList)
            {
                token.GetValue(P1, P2, turn, card);
            }
        }
    }
}
