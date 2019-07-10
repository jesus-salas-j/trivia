using System;
using System.Collections.Generic;
using System.Linq;

namespace TriviaGame
{
    public class Game
    {
        private const int COINS_TO_WIN = 6;
        private const int QUESTIONS_NUMBER = 50;
        private bool notAWinner;

        private int[] places = new int[6];
        private bool[] inPenaltyBox = new bool[6];

        private LinkedList<string> popQuestions = new LinkedList<string>();
        private LinkedList<string> scienceQuestions = new LinkedList<string>();
        private LinkedList<string> sportsQuestions = new LinkedList<string>();
        private LinkedList<string> rockQuestions = new LinkedList<string>();

        private int currentPlayer = 0;
        private bool isGettingOutOfPenaltyBox;

        private PlayersService playersService;

        public Game()
        {
            InitializeQuestions();

            playersService = new PlayersService();
        }

        private void InitializeQuestions()
        {
            for (int i = 0; i < QUESTIONS_NUMBER; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
            }
        }

        public void Run()
        {
            add("Chet");
            add("Pat");
            add("Sue");

            Random rand = new Random();

            do
            {
                roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = true;
                    Console.WriteLine("Question was incorrectly answered");
                    Console.WriteLine(playersService.Current().Name + " was sent to the penalty box");
                    inPenaltyBox[currentPlayer] = true;

                    currentPlayer++;
                    if (currentPlayer == playersService.Count()) currentPlayer = 0;
                }
                else
                {
                    notAWinner = wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }

        public void add(String playerName)
        {
            playersService.Add(new Player(playerName));
            places[playersService.Count()] = 0;
            inPenaltyBox[playersService.Count()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + playersService.Count());
        }

        public void roll(int roll)
        {
            Console.WriteLine(playersService.Current().Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(playersService.Current().Name + " is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(playersService.Current().Name
                            + "'s new location is "
                            + places[currentPlayer]);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(playersService.Current().Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Console.WriteLine(playersService.Current().Name
                        + "'s new location is "
                        + places[currentPlayer]);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory()
        {
            if (places[currentPlayer] == 0) return "Pop";
            if (places[currentPlayer] == 4) return "Pop";
            if (places[currentPlayer] == 8) return "Pop";
            if (places[currentPlayer] == 1) return "Science";
            if (places[currentPlayer] == 5) return "Science";
            if (places[currentPlayer] == 9) return "Science";
            if (places[currentPlayer] == 2) return "Sports";
            if (places[currentPlayer] == 6) return "Sports";
            if (places[currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    playersService.Current().IncrementGoldCoins();
                    Console.WriteLine(playersService.Current().Name
                            + " now has "
                            + playersService.Current().GoldCoins()
                            + " Gold Coins.");

                    bool winner = playersService.Current().GoldCoins() != COINS_TO_WIN;
                    currentPlayer++;
                    if (currentPlayer == playersService.Count()) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == playersService.Count()) currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Console.WriteLine("Answer was corrent!!!!");
                playersService.Current().IncrementGoldCoins();
                Console.WriteLine(playersService.Current().Name
                        + " now has "
                        + playersService.Current().GoldCoins()
                        + " Gold Coins.");

                bool winner = playersService.Current().GoldCoins() != COINS_TO_WIN;
                currentPlayer++;
                if (currentPlayer == playersService.Count()) currentPlayer = 0;

                return winner;
            }
        }

    }

}
