using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace War_Game
{
    //asd
    public class ConsoleApp
    {
        public static void PrintBoard(Player one1, Player two2)
        {
            Console.Clear();
            Console.WriteLine("Player 1: " + one1.NickName + " ENERGY => " + one1.Energy + " <= ");

            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("========================================================");
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"==>>TERRAIN{j+1}<<==");
                Console.WriteLine("========================================================");

                Console.WriteLine(one1.NickName + " => Conquest: " + one1.Terrains[j].Conquest);
                Console.WriteLine();
                PrintTerrain(one1.Terrains[j]);

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine(two2.NickName + " => Conquest: " + two2.PublicTerrain[j].Conquest);
                Console.WriteLine();
                PrintTerrain(two2.PublicTerrain[j]);

                Console.WriteLine("========================================================");
            }
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("========================================================");
            Console.WriteLine("========================================================");

            Console.WriteLine("Player 2: " + two2.NickName  + " ENERGY => " + two2.Energy + " <= ");
        }

        public static void PrintCard(Card card)
        {
            Console.Write("Name: " + card.cardName + " Energy Cost: " + card.Energy + " Conquest Power: " + card.Conquest);
        }

        public static void PrintTerrain(Terrain x)
        {
            int i = 1;

            foreach (Card card in x.CardsPlayed)
            {
                Console.Write(i + " :");
                PrintCard(card);
                Console.WriteLine();
                i++;
            }
        }

        public static void PrintAnimation(string text, int sleepTime = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(sleepTime);
            }
            Console.WriteLine();
        }

        public static void Loading()
        {
            string temp = "Game is loading!";
            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.WriteLine(temp);
                Console.WriteLine("Progress: " + i + "%");
                System.Threading.Thread.Sleep(20);
            }
        }

        public static void ItsYourTurn(Player P, Player X)
        {

            string newPrompt = "It's ur turn " + P.NickName + "\n What whould you want to do?";
            string[] playOptions = { "Play a card", "Check GameBoard", "End Turn" };
            Menu playManu = new Menu(newPrompt, playOptions);
            int selectedPlayIndex = playManu.Run();

            switch (selectedPlayIndex)
            {
                case 0:
                    if (P.CardsInHand.Count > 0 && P.Energy > 0)
                    {
                        string finish = "";
                        while (finish != "y")
                        {
                            PlayACardPrinter(P);
                            Console.WriteLine("Are u finish?");
                            Console.WriteLine("Write 'y' for finish and 'n' to play another card.");
                            finish = Console.ReadLine();
                        }
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        if (P.CardsInHand.Count == 0)
                        {
                            string WhatToDo = "";
                            Console.WriteLine("You don't have any card to play");
                            Console.WriteLine("Write 'et' to end turn or press any key to go back");
                            WhatToDo = Console.ReadLine();

                            if (WhatToDo == "et")
                            {
                                P.EndTurn = true;
                                break;
                            }
                            break;
                        }
                        if (P.Energy == 0)
                        {
                            string WhatToDo = "";
                            Console.WriteLine("You don't have enough energy to play a card");
                            Console.WriteLine("Write 'et' to end turn or press any key to go back");
                            WhatToDo = Console.ReadLine();

                            if (WhatToDo == "et")
                            {
                                P.EndTurn = true;
                                break;
                            }
                            break;
                        }
                    }
                    break;

                case 1:
                    string GoBack = "";
                    while (GoBack != "gb")
                    {
                        PrintBoard(P, X);
                        Console.WriteLine("If you want to go back write 'gb'.");
                        GoBack = Console.ReadLine();
                    }
                    break;

                case 2:
                    P.EndTurn = true;
                    Console.Clear();
                    break;
            }

        }

        static void PlayACardPrinter(Player P)
        {
            Console.Clear();

            int i = 1;
            Console.WriteLine("Player 1: " + P.NickName + "'s hand: ");
            Console.WriteLine("========================================================");
            foreach (Card card in P.CardsInHand)
            {
                Console.Write("#" + i + ":");
                PrintCard(card);
                Console.Write("  ||  ");
                Console.WriteLine();
                i++;
            }

            Console.WriteLine("Player Energy: " + P.Energy);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int imputTerrain = 0;
            int imputCard = 0;
            Console.WriteLine("Write the number of the card that u want to play: ");
            bool flag = false;
            while (!flag)
            {
                imputCard = int.Parse(Console.ReadLine()) - 1;  // poner exepcion al enter
                flag = true;
                if (imputCard <= - 1 || imputCard > P.CardsInHand.Count() - 1)
                {
                    Console.WriteLine("Sorry, that number isn't valid, try again");
                    flag = false;
                }
            }

            if (Card.CardCanBePlayed(P, P.CardsInHand[imputCard]))
            {
                Console.WriteLine("Write in what terrain u want to play?: ");
                imputTerrain = int.Parse(Console.ReadLine()) - 1;

                while (!Terrain.TerrainHaveSpace(P.Terrains[imputTerrain]))
                {
                    Console.WriteLine("You have already played 4 cards in Terrain #" + (imputTerrain + 1));
                    Console.WriteLine("Choose another terrain to play your card");
                    imputTerrain = int.Parse(Console.ReadLine()) - 1;
                }
                PlayACard(P, P.CardsInHand[imputCard], imputTerrain);
            }
            else
            {
                Console.WriteLine("You don`t have enough Energy to play this card");
            }
        }
        public static void PlayACard(Player player, Card cardPlayed, int indexTerrain)
        {
            player.Energy -= cardPlayed.Energy;
            player.Terrains[indexTerrain].CardsPlayed.Add(cardPlayed);
            player.Terrains[indexTerrain].Conquest += cardPlayed.Conquest;
            player.CardsInHand.Remove(cardPlayed);
        }
    }
}
