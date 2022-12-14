using System.Linq;
using System.Collections.Generic;

namespace War_Game
{
    public class Main_Game
    {
        static void Main(string[] args)
        {
            ConsoleApp.PrintAnimation("Insert nick name Player 1: ", 100);  // (C-APK)
            ConsoleApp.PrintAnimation("(no more than 12 characters)", 100);  // (C-APK)

            //Console.WriteLine("Insert nick name Player 1: ");      //Console APK (C-APK)
            //Console.WriteLine("(no more than 12 characters)");      //Console APK (C-APK)
            string nickNamePlayer1 = Console.ReadLine();           //Console APK (C-APK)

            ConsoleApp.PrintAnimation("Insert nick name Player 2: ", 100);  // (C-APK)
            ConsoleApp.PrintAnimation("(no more than 12 characters)", 100);  // (C-APK)
            //Console.WriteLine("Insert nick name Player 2: ");           //Console APK (C-APK)
            //Console.WriteLine("(no more than 12 characters)");          //Console APK (C-APK)
            string nickNamePlayer2 = Console.ReadLine();           //Console APK (C-APK)

            #region Deck Creation

            Effect effect = new Effect();
            Deck deck1 = new Deck();
            Card card1 = new Card("card11", 1, 2, effect);
            deck1.cards.Add(card1);
            Card card2 = new Card("card12", 2, 3, effect);
            deck1.cards.Add(card2);
            Card card3 = new Card("card12", 3, 4, effect);
            deck1.cards.Add(card3);
            Card card4 = new Card("card11", 4, 5, effect);
            deck1.cards.Add(card4);
            Card card5 = new Card("card12", 2, 3, effect);
            deck1.cards.Add(card5);
            Card card6 = new Card("card12", 3, 4, effect);
            deck1.cards.Add(card6);
            Card card7 = new Card("card11", 1, 2, effect);
            deck1.cards.Add(card7);
            Card card8 = new Card("card12", 2, 3, effect);
            deck1.cards.Add(card8);
            Card card9 = new Card("card12", 3, 4, effect);
            deck1.cards.Add(card9);
            Card card10 = new Card("card11", 4, 6, effect);
            deck1.cards.Add(card10);
            Card card11 = new Card("card12", 2, 3, effect);
            deck1.cards.Add(card11);
            Card card12 = new Card("card12", 6, 10, effect);
            deck1.cards.Add(card12);
            #endregion          

            Random rand = new Random();
            var shuffled = deck1.cards.OrderBy(_ => rand.Next()).ToList();
            Player P1 = new Player(nickNamePlayer1, deck1);

            shuffled = deck1.cards.OrderBy(_ => rand.Next()).ToList();
            Player P2 = new Player(nickNamePlayer2, deck1);

            int turn = 1;

            while (turn <= 6)
            {
                Console.Clear();
                ConsoleApp.PrintBoard(P1, P2);

                while (!P1.EndTurn)
                {

                }
                while (!P2.EndTurn)
                {

                }

                P1.EndTurn = false;
                P2.EndTurn = false;

                turn++;
            }

            Console.Clear();
            Console.WriteLine(WhoWon(P1, P2));

            void PlayACard(Player player, Card cardPlayed, int indexTerrain)
            {
                player.Terrains[indexTerrain].CardsPlayed.Add(cardPlayed);
                player.Terrains[indexTerrain].Conquest += cardPlayed.Conquest;
                player.CardsInHand.Remove(cardPlayed);
            }

            string WhoWon(Player one, Player two)
            {
                int onePlayerConquestTerrain = 0;
                int twoPlayerConquestTerrain = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (one.Terrains[i].Conquest < two.Terrains[i].Conquest)
                    {
                        twoPlayerConquestTerrain++;
                    }
                    else onePlayerConquestTerrain++;
                }

                if (onePlayerConquestTerrain == twoPlayerConquestTerrain)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        onePlayerConquestTerrain += one.Terrains[i].Conquest;
                        twoPlayerConquestTerrain += two.Terrains[i].Conquest;
                    }

                    if (onePlayerConquestTerrain == twoPlayerConquestTerrain)
                    {
                        return "TIE!!!";
                    }

                    if (onePlayerConquestTerrain < twoPlayerConquestTerrain)
                    {
                        return two.NickName;
                    } else return one.NickName;
                }

                if (onePlayerConquestTerrain < twoPlayerConquestTerrain)
                {
                    return two.NickName;
                }
                else return one.NickName;
            }
        }

    }
}