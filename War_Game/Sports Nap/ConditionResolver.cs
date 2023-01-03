using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War_Game
{
    public class ConditionResolver
    {

        #region Condition Resolver
        public static bool ResolveCondition(List<Token> tokenList)
        {
            //GetValues needs to be updated 
            int FirstIndex = 0;

            for (int i = 0; i < tokenList.Count; i++)
            {
                if (tokenList[i].Description == "[")
                {
                    FirstIndex = i;
                }
                if (tokenList[i].Description == "]")
                {
                    Token resultToken = Shunting_Yard(tokenList.GetRange(FirstIndex+1, i-FirstIndex+1));
                    tokenList.RemoveRange(FirstIndex, i-FirstIndex); // debug
                    tokenList.Insert(FirstIndex, resultToken);
                }
            }

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

        public static bool EatComparation(List<Token> tokenList)
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

        public static bool EatName(Token a, Token b)
        {
            if (a.nameValue == b.nameValue)
            {
                return true;
            }
            return false;
        }

        public static bool CalculateExpresion(List<Token> tokenList)
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

        #endregion
        public static void UpdateTokensValues(List<Token> tokenList, Player P1, Player P2, int turn, Card card)
        {
            foreach (Token token in tokenList)
            {
                token.GetValue(P1, P2, turn, card);
            }
        }

        public static void EffectResolver (List<Token> tokenList, Player P1, Player P2, int turn, Card card)
        {
            if (AritmeticsExpresions(tokenList))
            {
                int FirstIndex = 0;

                for (int i = 0; i < tokenList.Count; i++)
                {
                    if (tokenList[i].Description == "[")
                    {
                        FirstIndex = i;
                    }
                    if (tokenList[i].Description == "]")
                    {
                        Token resultToken = Shunting_Yard(tokenList.GetRange(FirstIndex+1, i-FirstIndex+1));
                        tokenList.RemoveRange(FirstIndex, i-FirstIndex); // debug
                        tokenList.Insert(FirstIndex, resultToken);
                    }
                }
            }

            string effect = tokenList[0].Description;

            if (effect == "destroy")
            {
                int terrainIndex = -1;

                for (int i = 0; i < 3; i++)
                {
                    if (P1.Terrains[i].CardsPlayed.Contains(card))
                    {
                        terrainIndex = i;
                    }
                }

                Language.DestroyACard(P2, terrainIndex);
            }
            if (effect == "destroycards")
            {
                int terrainIndex = -1;

                for (int i = 0; i < 3; i++)
                {
                    if (P1.Terrains[i].CardsPlayed.Contains(card))
                    {
                        terrainIndex = i;
                    }
                }

                int cardsToDestroy = 0;

                try
                {
                    cardsToDestroy = tokenList[1].value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Not valid effect. Espected a number of cards to destroy");
                }

                Language.DestroyCards(P2, terrainIndex, cardsToDestroy);
            }
            if (effect == "")
            {

            }
            if (effect == "")
            {

            }
            if (effect == "")
            {

            }
            if (effect == "")
            {

            }
            if (effect == "")
            {

            }
        }

        #region Shunting Yard
        public static Token Shunting_Yard(List<Token> tokenlist)
        {
            Queue<Token> queue = new Queue<Token>();
            Stack<Token> stack = new Stack<Token>();

            while (stack.Count() != 0 || tokenlist.Count() != 0)
            {
                if (tokenlist.Count() == 0)
                {
                    while (stack.Count() != 0)
                    {
                        Token tempToken = stack.Pop();
                        queue.Enqueue(tempToken);
                    }
                    break;
                }

                Token currentToken = tokenlist[0];
                tokenlist.RemoveAt(0);

                if (currentToken.Type == "number")
                {
                    queue.Enqueue(currentToken);
                    continue;
                }
                if (currentToken.Description == "(" || currentToken.Description == "*")
                {
                    stack.Push(currentToken);
                    continue;
                }
                if (currentToken.Description == "+" || currentToken.Description == "-")
                {
                    while (stack.Peek().Description == "*")
                    {
                        Token tempToken = stack.Pop();
                        queue.Enqueue(tempToken);
                        stack.Push(currentToken);
                    }
                    continue;
                }
                if (currentToken.Description == ")")
                {
                    while (stack.Peek().Description != "(")
                    {
                        Token tempToken = stack.Pop();
                        queue.Enqueue(tempToken);
                    }
                    stack.Pop();
                    continue;
                }
            }

            return QueueResolver(queue);
        }

        public static Token QueueResolver(Queue<Token> tokenQueue)
        {
            Stack <Token> stack = new Stack <Token>();

            while (tokenQueue.Count() != 0)
            {
                Token tempToken = tokenQueue.Dequeue();

                if (tempToken.Type == "number")
                {
                    stack.Push(tempToken);
                }
                if (tempToken.Description == "*")
                {
                    int b = stack.Pop().value;
                    int a = stack.Pop().value;

                    Token newToken = new Token("number", (a*b).ToString(), (a*b));
                    stack.Push(newToken);
                }
                if (tempToken.Description == "+")
                {
                    int b = stack.Pop().value;
                    int a = stack.Pop().value;

                    Token newToken = new Token("number", (a+b).ToString(), (a+b));
                    stack.Push(newToken);
                }
                if (tempToken.Description == "-")
                {
                    int b = stack.Pop().value;
                    int a = stack.Pop().value;

                    Token newToken = new Token("number", (a-b).ToString(), (a-b));
                    stack.Push(newToken);
                }
            }

            return stack.Pop();
        }

        #endregion

        public static bool AritmeticsExpresions (List <Token> tokenList)
        {
            foreach (Token token in tokenList)
            {
                if (token.Description == "[" || token.Description == "]")
                {
                    return true;
                }
            }
            return false;
        }
    }
}

// Debug Method
//if por cada uno de los effectos
