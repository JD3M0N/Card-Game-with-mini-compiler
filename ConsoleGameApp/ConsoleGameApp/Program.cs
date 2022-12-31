using System.Linq;
using System.Collections.Generic;
using System.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace War_Game
{
    public class Main_Game
    {
        private static string cardsPath = @"E:\Programming\GitDesktop\God-s_Snap\Cards.json";
        private static string decksPath = @"E:\Programming\GitDesktop\God-s_Snap\Decks.json";
        static void Main(string[] args)
        {
            #region Getting Cards and Decks from Json

            //List <Card> cardList = GetCards();
            //SerializeCardJsonFile(cardList);


            string jsonCards = GetCardsJsonFromFile();
            string jsonDeck = GetDecksJsonFromFile();
            DataSet dataset = new DataSet();
            dataset.cardsDataSet = DeserializeCardsJsonFile(jsonCards);
            dataset.deckDataSet = DeserializeDecksJsonFile(jsonDeck);
            #endregion

            SoundPlayer typingSound = new SoundPlayer("typewriter-2.wav");
            typingSound.Load();
            SoundPlayer backgroundMusic = new SoundPlayer("Pirates of the Caribbean theme.wav");
            backgroundMusic.Load();

            #region FirstMenuOption

            string prompt = @"

      ██████╗  ██████╗ ██████╗       ███████╗    ███████╗███╗   ██╗ █████╗ ██████╗ 
     ██╔════╝ ██╔═══██╗██╔══██╗      ██╔════╝    ██╔════╝████╗  ██║██╔══██╗██╔══██╗
     ██║  ███╗██║   ██║██║  ██║█████╗███████╗    ███████╗██╔██╗ ██║███████║██████╔╝
     ██║   ██║██║   ██║██║  ██║╚════╝╚════██║    ╚════██║██║╚██╗██║██╔══██║██╔═══╝ 
     ╚██████╔╝╚██████╔╝██████╔╝      ███████║    ███████║██║ ╚████║██║  ██║██║     
      ╚═════╝  ╚═════╝ ╚═════╝       ╚══════╝    ╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝     
                                                                                   
 
                                                                       
  
 Welcome to War Game! What would you like to do?
(Use the arrow keys to cycle through the options and press enter to select an option.)";

            string[] options = { "Play", "About", "Card Creation", "Deck Creation", "Exit" };
            Menu mainManu = new Menu(prompt, options);
            int selectedIndex = mainManu.Run();

            #endregion

            switch (selectedIndex)
            {
                case 0:
                    string newPrompt = "How would u like to play?";
                    string[] playOptions = { "Player vs Player", "Play vs Bot" };
                    Menu playManu = new Menu(newPrompt, playOptions);
                    int selectedPlayIndex = playManu.Run();

                    switch (selectedPlayIndex)
                    {

                        #region PlayVSPlayer 
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
                                            P1Deck.cards.Add(dataset.GetACard("Zeus"));
                                            break;

                                        case 1:
                                            P1Deck.cards.Add(dataset.GetACard("Hermes"));
                                            break;

                                        case 2:
                                            P1Deck.cards.Add(dataset.GetACard("Hera"));
                                            break;

                                        case 3:
                                            P1Deck.cards.Add(dataset.GetACard("Apolo"));
                                            break;

                                        case 4:
                                            P1Deck.cards.Add(dataset.GetACard("Poseidon"));
                                            break;

                                        case 5:
                                            P1Deck.cards.Add(dataset.GetACard("Artemisa"));
                                            break;

                                        case 6:
                                            P1Deck.cards.Add(dataset.GetACard("Afrodita"));
                                            break;

                                        case 7:
                                            P1Deck.cards.Add(dataset.GetACard("Hefesto"));
                                            break;

                                        case 8:
                                            P1Deck.cards.Add(dataset.GetACard("Ares"));
                                            break;

                                        case 9:
                                            P1Deck.cards.Add(dataset.GetACard("Demeter"));
                                            break;

                                        case 10:
                                            P1Deck.cards.Add(dataset.GetACard("Atenea"));
                                            break;

                                        case 11:
                                            P1Deck.cards.Add(dataset.GetACard("Hestia"));
                                            break;

                                        case 12:
                                            P1Deck.cards.Add(dataset.GetACard("Dionisio"));
                                            break;

                                        case 13:
                                            P1Deck.cards.Add(dataset.GetACard("Hades"));
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
                                            P2Deck.cards.Add(dataset.GetACard("Zeus"));
                                            break;

                                        case 1:
                                            P2Deck.cards.Add(dataset.GetACard("Hermes"));
                                            break;

                                        case 2:
                                            P2Deck.cards.Add(dataset.GetACard("Hera"));
                                            break;

                                        case 3:
                                            P2Deck.cards.Add(dataset.GetACard("Apolo"));
                                            break;

                                        case 4:
                                            P2Deck.cards.Add(dataset.GetACard("Poseidon"));
                                            break;

                                        case 5:
                                            P2Deck.cards.Add(dataset.GetACard("Artemisa"));
                                            break;

                                        case 6:
                                            P2Deck.cards.Add(dataset.GetACard("Afrodita"));
                                            break;

                                        case 7:
                                            P2Deck.cards.Add(dataset.GetACard("Hefesto"));
                                            break;

                                        case 8:
                                            P2Deck.cards.Add(dataset.GetACard("Ares"));
                                            break;

                                        case 9:
                                            P2Deck.cards.Add(dataset.GetACard("Demeter"));
                                            break;

                                        case 10:
                                            P2Deck.cards.Add(dataset.GetACard("Atenea"));
                                            break;

                                        case 11:
                                            P2Deck.cards.Add(dataset.GetACard("Hestia"));
                                            break;

                                        case 12:
                                            P2Deck.cards.Add(dataset.GetACard("Dionisio"));
                                            break;

                                        case 13:
                                            P2Deck.cards.Add(dataset.GetACard("Hades"));
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
                                backgroundMusic.PlayLooping();

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

                            backgroundMusic.Stop();
                            Console.Clear();
                            Console.WriteLine(@"

     ██╗    ██╗██╗███╗   ██╗███╗   ██╗███████╗██████╗ 
     ██║    ██║██║████╗  ██║████╗  ██║██╔════╝██╔══██╗
     ██║ █╗ ██║██║██╔██╗ ██║██╔██╗ ██║█████╗  ██████╔╝
     ██║███╗██║██║██║╚██╗██║██║╚██╗██║██╔══╝  ██╔══██╗
     ╚███╔███╔╝██║██║ ╚████║██║ ╚████║███████╗██║  ██║
      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                      
 
");

                            #endregion
                            Console.WriteLine(WhoWon(P1, P2));
                            break;


                        #region PlayVSBot
                        case 1:
                            Console.Clear();
                            Bot_easy DiazcaBot = new Bot_easy("DiazcaBot", dataset.GetADeck("BotDeck"));
                            DiazcaBot.PlayerDeck.Shuffled();

                            typingSound.PlayLooping();
                            ConsoleApp.PrintAnimation("Insert nick name Player : ", 50);
                            ConsoleApp.PrintAnimation("(no more than 12 characters)", 50);
                            typingSound.Stop();
                            nickNamePlayer1 = Console.ReadLine();

                            Player P3 = new Player(nickNamePlayer1, dataset.GetADeck("MydeckTexter"));
                            P3.PlayerDeck.Shuffled();

                            turn = 1;
                            cont1nue = "";

                            Card tempCard = new Card();

                            while (turn <= 6)
                            {
                                backgroundMusic.PlayLooping();

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

                            backgroundMusic.Stop();

                            Console.Clear();
                            Console.WriteLine(@"

     ██╗    ██╗██╗███╗   ██╗███╗   ██╗███████╗██████╗ 
     ██║    ██║██║████╗  ██║████╗  ██║██╔════╝██╔══██╗
     ██║ █╗ ██║██║██╔██╗ ██║██╔██╗ ██║█████╗  ██████╔╝
     ██║███╗██║██║██║╚██╗██║██║╚██╗██║██╔══╝  ██╔══██╗
     ╚███╔███╔╝██║██║ ╚████║██║ ╚████║███████╗██║  ██║
      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                      
 
");
                            #endregion
                            Console.WriteLine(WhoWon(P3, DiazcaBot));

                            break;
                    }
                    break;

                case 1:
                    Menu.DisplayAboutInfo();
                    break;

                case 2:
                    #region Card Creation
                    Console.Clear();
                    Card temp = new Card();
                    Console.WriteLine("Every card needs to have a name, an energy cost, and conquest value, and a effect in order to be a valid card");
                    Console.WriteLine("Make sure you have read alreaty the about seccion about how to play and how to create effects");
                    Console.WriteLine("Type the name of the card");
                    temp.cardName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Now set its energy cost");
                    bool catchFlag = true;
                    while (catchFlag)
                    {
                        try
                        {
                            temp.Energy = int.Parse(Console.ReadLine());
                            Console.Clear();
                            catchFlag = false;
                        }
                        catch (Exception ex)
                        {
                            catchFlag = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That's not a number");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine("Now set its conquest value");
                    catchFlag =  true;
                    while (catchFlag)
                    {
                        try
                        {
                            temp.Conquest = int.Parse(Console.ReadLine());
                            Console.Clear();
                            catchFlag = false;
                        }
                        catch (Exception ex)
                        {
                            catchFlag = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That's not a number");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine("Now it only rest the effect. How many effects do your new card has?");
                    int tempo = int.Parse(Console.ReadLine());
                    List<Token> tokens = new List<Token>();
                    for (int i = 0; i < tempo; i++)
                    {
                        Console.WriteLine($"Write the effect number {ReadANumber(i+1)}");
                        string effectText = Console.ReadLine();
                        List<Token> tempTokenList = Parse.Parsing(effectText);

                        foreach (Token token in tempTokenList)
                        {
                            tokens.Add(token);
                        }
                    }
                    Console.Clear();
                    Effect tempEffect = new Effect(tokens);
                    temp.Effecto = tempEffect;
                    Console.WriteLine("Congratz your card has been created");
                    ConsoleApp.PrintCard(temp);

                    dataset.cardsDataSet.Add(temp);
                    SerializeCardJsonFile(dataset.cardsDataSet);

                    #endregion

                    break;

                case 3:
                    #region Deck Creation
                    Console.Clear();
                    Console.WriteLine("Welcome to deck creation.");
                    Console.WriteLine("Make sure you have read already the about seccion about how to play and how to create decks");

                    string promptDeckCreation = @"Choose the way you want to create the deck";

                    string[] deckOptions = { "Create by cards names", "Create by choosing cards" };
                    Menu deckCreationMenu = new Menu(promptDeckCreation, deckOptions);
                    int selectedIndexDC = deckCreationMenu.Run();

                    switch (selectedIndexDC)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Type the name of your deck");
                            string deckName = Console.ReadLine();
                            Deck newDeck = new Deck();
                            newDeck.DeckName = deckName;
                            Console.Clear();
                            Console.WriteLine("Now let's add the cards");

                            for (int i = 0; i < 12; i++)
                            {
                                Console.WriteLine($"Add the card number {ReadANumber(i+1)} by typing it's name");
                                string cardName = Console.ReadLine();
                                Card card = dataset.GetACard(cardName);
                                newDeck.cards.Add(card);
                            }

                            Console.Clear();

                            if (newDeck.Validator())
                            {
                                Console.WriteLine($"Your deck have been createad susscefully, here is your deck ID: {newDeck.GetDeckID()}");
                                dataset.deckDataSet.Add(newDeck);
                                SerializeDeckJsonFile(dataset.deckDataSet);
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong, you didn't make a valid deck.");
                            }
                            break;

                        
                        case 1:
                            break;
                    }

#endregion
                    break;

                case 4:
                    Menu.ExitGame();
                    break;
            }


            void PlayACard(Player player, Card cardPlayed, int indexTerrain)
            {
                player.Terrains[indexTerrain].CardsPlayed.Add(cardPlayed);
                player.Terrains[indexTerrain].Conquest += cardPlayed.Conquest;
                player.CardsInHand.Remove(cardPlayed);
                player.Energy -= cardPlayed.Energy;
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
        #region Serializing Json
        public static List<Card> GetCards()
        {
            List<Card> cardList = new List<Card>();
            Effect newEffect = new Effect();
            List<Token> tokenList = new List<Token>();
            Token token1 = new Token("boolean", "true");
            tokenList.Add(token1);
            Token token2 = new Token("keyword", ":");
            tokenList.Add(token2);
            Token token3 = new Token("value", "empty");
            tokenList.Add(token3);
            Token token4 = new Token("keyword", ";");
            tokenList.Add(token4);
            Effect effect1 = new Effect(tokenList);

            Card Hestia = new Card("Hestia", 3, 3, effect1);
            cardList.Add(Hestia);
            Card Atenea = new Card("Atenea", 4, 5, newEffect);
            cardList.Add(Atenea);
            Card Demeter = new Card("Demeter", 2, 3, newEffect);
            cardList.Add(Demeter);
            Card Ares = new Card("Ares", 6, 12, newEffect);
            cardList.Add(Ares);
            Card Hefesto = new Card("Hefesto", 4, 5, newEffect);
            cardList.Add(Hefesto);
            Card Afrodita = new Card("Afrodita", 3, 3, newEffect);
            cardList.Add(Afrodita);
            Card Artemisa = new Card("Artemisa", 1, 1, newEffect);
            cardList.Add(Artemisa);
            Card Poseidon = new Card("Poseidon", 4, 6, newEffect);
            cardList.Add(Poseidon);
            Card Apolo = new Card("Apolo", 2, 2, newEffect);
            cardList.Add(Apolo);
            Card Zeus = new Card("Zeus", 5, 9, newEffect);
            cardList.Add(Zeus);
            Card Hermes = new Card("Hermes", 1, 2, newEffect);
            cardList.Add(Hermes);
            Card Hera = new Card("Hera", 3, 4, newEffect);
            cardList.Add(Hera);
            Card Dioniso = new Card("Dioniso", 1, 1, newEffect);
            cardList.Add(Dioniso);
            Card Hades = new Card("Hades", 6, 10, newEffect);
            cardList.Add(Hades);
            Card Raijin = new Card("Raijin", 3, 5, newEffect);
            cardList.Add(Raijin);
            Card Amateratsu = new Card("Amateratsu", 2, 4, newEffect);
            cardList.Add(Amateratsu);
            Card Susanoo = new Card("Susanoo", 6, 9, effect1);
            cardList.Add(Susanoo);

            return cardList;
        }

        public static List<Deck> GetDecks()
        {
            List<Deck> deckList = new List<Deck>();

            return deckList;
        }

        public static void SerializeCardJsonFile(List<Card> cardList)
        {
            string cardJson = JsonConvert.SerializeObject(cardList.ToArray(), Formatting.Indented);

            File.WriteAllText(cardsPath, cardJson);
        }

        public static void SerializeDeckJsonFile(List<Deck> deckList)
        {
            string deckJson = JsonConvert.SerializeObject(deckList.ToArray(), Formatting.Indented);

            File.WriteAllText(decksPath, deckJson);
        }
        #endregion

        #region Deserializing Json 
        public static string GetCardsJsonFromFile()
        {
            string cardJsonFromFile;
            using (var reader = new StreamReader(cardsPath))
            {
                cardJsonFromFile = reader.ReadToEnd();
            }

            return cardJsonFromFile;
        }
        public static string GetDecksJsonFromFile()
        {
            string deckJsonFromFile;
            using (var reader = new StreamReader(decksPath))
            {
                deckJsonFromFile = reader.ReadToEnd();
            }

            return deckJsonFromFile;
        }

        public static List<Card> DeserializeCardsJsonFile(string cardJasonFromFile)
        {
            List<Card> cardList = JsonConvert.DeserializeObject<List<Card>>(cardJasonFromFile);

            return cardList;
        }

        public static List<Deck> DeserializeDecksJsonFile(string deckJasonFromFile)
        {
            List<Deck> deckList = JsonConvert.DeserializeObject<List<Deck>>(deckJasonFromFile);

            return deckList;
        }
        #endregion

        #region Don't look at this, it's lame :/
        public static string ReadANumber(int num)
        {
            if (num == 1)
            {
                return "one";
            }
            if (num == 2)
            {
                return "two";
            }
            if (num == 3)
            {
                return "three";
            }
            if (num == 4)
            {
                return "four";
            }
            if (num == 5)
            {
                return "five";
            }
            if (num == 6)
            {
                return "six";
            }
            if (num == 7)
            {
                return "seve";
            }
            if (num == 8)
            {
                return "eight";
            }
            if (num == 9)
            {
                return "nine";
            }
            if (num == 10)
            {
                return "ten";
            }
            if (num == 11)
            {
                return "eleven";
            }
            if (num == 12)
            {
                return "twelve";
            }


            return "n";
        }
        #endregion
    }
}

//decks need to hace a deck ID to make sure players dont play with the same deck