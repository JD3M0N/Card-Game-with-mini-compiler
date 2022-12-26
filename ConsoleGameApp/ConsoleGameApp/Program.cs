using System.Linq;
using System.Collections.Generic;
using System.Media;


namespace War_Game
{
    public class Main_Game
    {
        static void Main(string[] args)
        {
            #region CardsCreationAndBotDeck

            Effect Elefecto = new Effect();
            Card Hestia = new Card("Hestia", 3, 3, Elefecto);
            Card Atenea = new Card("Atenea", 4, 5, Elefecto);
            Card Demeter = new Card("Demeter", 2, 3, Elefecto);
            Card Ares = new Card("Ares", 6, 12, Elefecto);
            Card Hefesto = new Card("Hefesto", 4, 5, Elefecto);
            Card Afrodita = new Card("Afrodita", 3, 3, Elefecto);
            Card Artemisa = new Card("Artemisa", 1, 1, Elefecto);
            Card Poseidon = new Card("Poseidon", 4, 6, Elefecto);
            Card Apolo = new Card("Apolo", 2, 2, Elefecto);
            Card Zeus = new Card("Zeus", 5, 9, Elefecto);
            Card Hermes = new Card("Hermes", 1, 2, Elefecto);
            Card Hera = new Card("Hera", 3, 4, Elefecto);
            Card Dioniso = new Card("Dioniso", 1, 1, Elefecto);
            Card Hades = new Card("Hades", 6, 10, Elefecto);

            Deck BotDeck = new Deck();
            Deck MyDeckTexter = new Deck();
            BotDeck.cards.Add(Zeus);
            MyDeckTexter.cards.Add(Zeus);
            BotDeck.cards.Add(Hermes);
            MyDeckTexter.cards.Add(Hermes);
            BotDeck.cards.Add(Hera);
            MyDeckTexter.cards.Add(Hera);
            BotDeck.cards.Add(Apolo);
            MyDeckTexter.cards.Add(Apolo);
            BotDeck.cards.Add(Poseidon);
            MyDeckTexter.cards.Add(Poseidon);
            BotDeck.cards.Add(Artemisa);
            MyDeckTexter.cards.Add(Artemisa);
            BotDeck.cards.Add(Afrodita);
            MyDeckTexter.cards.Add(Afrodita);
            BotDeck.cards.Add(Hefesto);
            MyDeckTexter.cards.Add(Hefesto);
            BotDeck.cards.Add(Ares);
            MyDeckTexter.cards.Add(Ares);
            BotDeck.cards.Add(Demeter);
            MyDeckTexter.cards.Add(Demeter);
            BotDeck.cards.Add(Atenea);
            MyDeckTexter.cards.Add(Atenea);
            BotDeck.cards.Add(Dioniso);
            MyDeckTexter.cards.Add(Dioniso);

            #endregion

            SoundPlayer typingSound = new SoundPlayer("typewriter-2.wav");
            typingSound.Load();

            string prompt = @"

      ██████╗  ██████╗ ██████╗       ███████╗    ███████╗███╗   ██╗ █████╗ ██████╗ 
     ██╔════╝ ██╔═══██╗██╔══██╗      ██╔════╝    ██╔════╝████╗  ██║██╔══██╗██╔══██╗
     ██║  ███╗██║   ██║██║  ██║█████╗███████╗    ███████╗██╔██╗ ██║███████║██████╔╝
     ██║   ██║██║   ██║██║  ██║╚════╝╚════██║    ╚════██║██║╚██╗██║██╔══██║██╔═══╝ 
     ╚██████╔╝╚██████╔╝██████╔╝      ███████║    ███████║██║ ╚████║██║  ██║██║     
      ╚═════╝  ╚═════╝ ╚═════╝       ╚══════╝    ╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝     
                                                                                   
 
                                                                       
  
 Welcome to War Game! What would you like to do?
(Use the arrow keys to cycle through the options and press enter to select an option.)";

            string[] options = { "Play", "About", "Exit" };
            Menu mainManu = new Menu(prompt, options);
            int selectedIndex = mainManu.Run();

            switch (selectedIndex)
            {
                case 0:
                    string newPrompt = "How would u like to play?";
                    string[] playOptions = { "Player vs Player", "Play vs Bot" };
                    Menu playManu = new Menu(newPrompt, playOptions);
                    int selectedPlayIndex = playManu.Run();

                    switch (selectedPlayIndex)
                    {
                        case 0:
                            Console.Clear();

                            typingSound.PlayLooping();
                            ConsoleApp.PrintAnimation("Insert nick name Player 1: ", 50);  // (C-APK)
                            ConsoleApp.PrintAnimation("(no more than 12 characters)", 50);  // (C-APK)
                            typingSound.Stop();
                            string nickNamePlayer1 = Console.ReadLine();           //Console APK (C-APK)
                            Deck P1Deck = new Deck();

                            Console.Clear();

                            string newPromptDeck = @"Choose the cards that you want to play with: 
(press enter to add a card)
(you cannot add the same card twice)";
                            string[] cards = { "Zeus", "Hermes", "Hera", "Apolo", "Poseidon", "Artemisa", "Afrodita", "Hefesto", "Ares", "Demeter", "Atenea", "Hestia", "Dioniso", "Hades", "Raijin", "Amaterasu", "Tsuki-Yomi", "Susanoo", "Fujin", "Rayujin", "Tenjin", "Hachiman", "Inari", "Omoikane", "Saruta-Hiko", "Kagutsuchi" };



                            Menu deckMenu = new Menu(newPromptDeck, cards);
                            bool validator = false;

                            #region CardDeckPlayersCreation
                            while (!validator)
                            {

                                while (P1Deck.cards.Count() < (12))
                                {
                                    int deckMenuIndex = deckMenu.Run();

                                    switch (deckMenuIndex)
                                    {
                                        case 0:
                                            P1Deck.cards.Add(Zeus);
                                            break;

                                        case 1:
                                            P1Deck.cards.Add(Hermes);
                                            break;

                                        case 2:
                                            P1Deck.cards.Add(Hera);
                                            break;

                                        case 3:
                                            P1Deck.cards.Add(Apolo);
                                            break;

                                        case 4:
                                            P1Deck.cards.Add(Poseidon);
                                            break;

                                        case 5:
                                            P1Deck.cards.Add(Artemisa);
                                            break;

                                        case 6:
                                            P1Deck.cards.Add(Afrodita);
                                            break;

                                        case 7:
                                            P1Deck.cards.Add(Hefesto);
                                            break;

                                        case 8:
                                            P1Deck.cards.Add(Ares);
                                            break;

                                        case 9:
                                            P1Deck.cards.Add(Demeter);
                                            break;

                                        case 10:
                                            P1Deck.cards.Add(Atenea);
                                            break;

                                        case 11:
                                            P1Deck.cards.Add(Hestia);
                                            break;

                                        case 12:
                                            P1Deck.cards.Add(Dioniso);
                                            break;

                                        case 13:
                                            P1Deck.cards.Add(Hades);
                                            break;
                                    }
                                }

                                if (P1Deck.Validator())
                                {
                                    validator = true;
                                }
                                if (!P1Deck.Validator())
                                {
                                    Console.Clear();
                                    P1Deck.cards.Clear();
                                    Console.WriteLine("Your deck have not the correct format, please make sure you have 12 cards, no more no less, and you don't have any card twice.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }

                            P1Deck.Shuffled();
                            Player P1 = new Player(nickNamePlayer1, P1Deck);
                            Console.Clear();

                            typingSound.PlayLooping();
                            ConsoleApp.PrintAnimation("Insert nick name Player 2: ", 50);  // (C-APK)
                            ConsoleApp.PrintAnimation("(no more than 12 characters)", 50);  // (C-APK)
                            typingSound.Stop();
                            string nickNamePlayer2 = Console.ReadLine();           //Console APK (C-APK)

                            Deck P2Deck = new Deck();

                            Console.Clear();

                            validator = false;

                            while (!validator)
                            {

                                while (P2Deck.cards.Count() < (12))
                                {
                                    int deckMenuIndex = deckMenu.Run();

                                    switch (deckMenuIndex)
                                    {
                                        case 0:
                                            P2Deck.cards.Add(Zeus);
                                            break;

                                        case 1:
                                            P2Deck.cards.Add(Hermes);
                                            break;

                                        case 2:
                                            P2Deck.cards.Add(Hera);
                                            break;

                                        case 3:
                                            P2Deck.cards.Add(Apolo);
                                            break;

                                        case 4:
                                            P2Deck.cards.Add(Poseidon);
                                            break;

                                        case 5:
                                            P2Deck.cards.Add(Artemisa);
                                            break;

                                        case 6:
                                            P2Deck.cards.Add(Afrodita);
                                            break;

                                        case 7:
                                            P2Deck.cards.Add(Hefesto);
                                            break;

                                        case 8:
                                            P2Deck.cards.Add(Ares);
                                            break;

                                        case 9:
                                            P2Deck.cards.Add(Demeter);
                                            break;

                                        case 10:
                                            P2Deck.cards.Add(Atenea);
                                            break;

                                        case 11:
                                            P2Deck.cards.Add(Hestia);
                                            break;

                                        case 12:
                                            P2Deck.cards.Add(Dioniso);
                                            break;

                                        case 13:
                                            P2Deck.cards.Add(Hades);
                                            break;
                                    }
                                }

                                if (P2Deck.Validator())
                                {
                                    validator = true;
                                }
                                if (!P2Deck.Validator())
                                {
                                    Console.Clear();
                                    P2Deck.cards.Clear();
                                    Console.WriteLine("Your deck have not the correct format, please make sure you have 12 cards, no more no less, and you don't have any card twice.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            P2Deck.Shuffled();
                            Player P2 = new Player(nickNamePlayer2, P2Deck);

                            #endregion

                            int turn = 1;
                            string cont1nue = "";


                            while (turn <= 6)
                            {
                                P1.Energy = turn;
                                P2.Energy = turn;

                                P1.UpdatePublicTerrain();
                                P2.UpdatePublicTerrain();

                                Console.Clear();
                                Console.WriteLine($"TURN: {turn}");
                                ConsoleApp.PrintBoard(P1, P2);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Write something to continue: ");
                                cont1nue = Console.ReadLine();
                                Console.Clear();

                                while (!P1.EndTurn)
                                {
                                    ConsoleApp.ItsYourTurn(P1, P2);
                                }
                                while (!P2.EndTurn)
                                {
                                    ConsoleApp.ItsYourTurn(P2, P1);
                                }

                                P1.EndTurn = false;
                                P2.EndTurn = false;

                                P1.DrawACard();
                                P2.DrawACard();

                                turn++;
                            }

                            Console.Clear();
                            Console.WriteLine(@"

     ██╗    ██╗██╗███╗   ██╗███╗   ██╗███████╗██████╗ 
     ██║    ██║██║████╗  ██║████╗  ██║██╔════╝██╔══██╗
     ██║ █╗ ██║██║██╔██╗ ██║██╔██╗ ██║█████╗  ██████╔╝
     ██║███╗██║██║██║╚██╗██║██║╚██╗██║██╔══╝  ██╔══██╗
     ╚███╔███╔╝██║██║ ╚████║██║ ╚████║███████╗██║  ██║
      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                      
 
");
                            Console.WriteLine(WhoWon(P1, P2));
                            break;

                        case 1:
                            Console.Clear();
                            BotDeck.Shuffled();
                            Bot_easy DiazcaBot = new Bot_easy("DiazcaBot", BotDeck);

                            typingSound.PlayLooping();
                            ConsoleApp.PrintAnimation("Insert nick name Player : ", 50); 
                            ConsoleApp.PrintAnimation("(no more than 12 characters)", 50);
                            typingSound.Stop();
                            nickNamePlayer1 = Console.ReadLine();         

                            MyDeckTexter.Shuffled();
                            Player P3 = new Player(nickNamePlayer1, MyDeckTexter);

                            turn = 1;
                            cont1nue = "";

                            Card tempCard = new Card();

                            while (turn <= 6)
                            {
                                P3.Energy = turn;
                                DiazcaBot.Energy = turn;

                                P3.UpdatePublicTerrain();
                                DiazcaBot.UpdatePublicTerrain();

                                Console.Clear();
                                Console.WriteLine($"TURN: {turn}");
                                ConsoleApp.PrintBoard(P3, DiazcaBot);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Write something to continue: ");
                                cont1nue = Console.ReadLine();
                                
                                Console.Clear();

                                while (!P3.EndTurn)
                                {
                                    ConsoleApp.ItsYourTurn(P3, DiazcaBot);
                                }
                                while (!DiazcaBot.EndTurn)
                                {
                                    tempCard = null;
                                    tempCard = DiazcaBot.CardToPlay();

                                    if (tempCard != null)
                                    {
                                        ConsoleApp.PlayACard(DiazcaBot, tempCard, DiazcaBot.TerrainToPlay(P3));
                                    }
                                }

                                P3.EndTurn = false;
                                DiazcaBot.EndTurn = false;

                                P3.DrawACard();
                                DiazcaBot.DrawACard();

                                turn++;
                            }

                            Console.Clear();
                            Console.WriteLine(@"

     ██╗    ██╗██╗███╗   ██╗███╗   ██╗███████╗██████╗ 
     ██║    ██║██║████╗  ██║████╗  ██║██╔════╝██╔══██╗
     ██║ █╗ ██║██║██╔██╗ ██║██╔██╗ ██║█████╗  ██████╔╝
     ██║███╗██║██║██║╚██╗██║██║╚██╗██║██╔══╝  ██╔══██╗
     ╚███╔███╔╝██║██║ ╚████║██║ ╚████║███████╗██║  ██║
      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                      
 
");
                            Console.WriteLine(WhoWon(P3, DiazcaBot));

                            break;
                    }
                    break;

                case 1:
                    Menu.DisplayAboutInfo();
                    break;

                case 2:
                    Menu.ExitGame();
                    break;
            }


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
                    }
                    else return one.NickName;
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