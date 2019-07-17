using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TriviaGame
{
    public class Game
    {
        private const int COINS_TO_WIN = 6;
        private const int QUESTIONS_NUMBER = 50;
        private bool notAWinner;

        private LinkedList<string> popQuestions = new LinkedList<string>();
        private LinkedList<string> scienceQuestions = new LinkedList<string>();
        private LinkedList<string> sportsQuestions = new LinkedList<string>();
        private LinkedList<string> rockQuestions = new LinkedList<string>();

        private bool isGettingOutOfPenaltyBox;

        private PlayersService playersService;
        private Board board;

        private StreamWriter writer;

        public Game()
        {
            SetConsoleOutputToFile();
            InitializeQuestions();

            playersService = new PlayersService();
            board = new Board();
        }

        public void Run()
        {
            add("Chet");
            add("Pat");
            add("Sue");

            playersService.SetFirstPlayerAsCurrent();

            List<int> rolls = CreateRollsSequence();
            List<int> squares = CreateSquaresSequence();

            int next = 0;

            do
            {
                roll(rolls[next]);

                if (squares[next] == 7)
                {
                    notAWinner = true;
                    Console.WriteLine("Question was incorrectly answered");
                    Console.WriteLine(playersService.Current().Name + " was sent to the penalty box");
                    board.PutInPenaltyBox(playersService.Current());
                    playersService.SetNextPlayerAsCurrent();
                }
                else
                {
                    notAWinner = wasCorrectlyAnswered();
                }

                next++;
            } while (notAWinner);

            writer.Close();
        }

        public void add(String playerName)
        {
            Player player = new Player(playerName);
            playersService.Add(player);
            board.Add(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + playersService.Count());
        }

        public void roll(int roll)
        {
            Console.WriteLine(playersService.Current().Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (board.IsInPenaltyBox(playersService.Current()))
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(playersService.Current().Name + " is getting out of the penalty box");
                    board.MovePlayerForward(playersService.Current(), roll);

                    Console.WriteLine(playersService.Current().Name
                            + "'s new location is "
                            + board.PositionOf(playersService.Current()));
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
                board.MovePlayerForward(playersService.Current(), roll);

                Console.WriteLine(playersService.Current().Name
                        + "'s new location is "
                        + board.PositionOf(playersService.Current()));
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }

        }

        private void SetConsoleOutputToFile()
        {
            writer = new StreamWriter("./actual_output.txt");
            Console.SetOut(writer);
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
            if (board.PositionOf(playersService.Current()) == 0) return "Pop";
            if (board.PositionOf(playersService.Current()) == 4) return "Pop";
            if (board.PositionOf(playersService.Current()) == 8) return "Pop";
            if (board.PositionOf(playersService.Current()) == 1) return "Science";
            if (board.PositionOf(playersService.Current()) == 5) return "Science";
            if (board.PositionOf(playersService.Current()) == 9) return "Science";
            if (board.PositionOf(playersService.Current()) == 2) return "Sports";
            if (board.PositionOf(playersService.Current()) == 6) return "Sports";
            if (board.PositionOf(playersService.Current()) == 10) return "Sports";
            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (board.IsInPenaltyBox(playersService.Current()))
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
                    playersService.SetNextPlayerAsCurrent();

                    return winner;
                }
                else
                {
                    playersService.SetNextPlayerAsCurrent();
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
                playersService.SetNextPlayerAsCurrent();

                return winner;
           } 
        }

        private static List<int> CreateSquaresSequence()
        {
            return new List<int>
            {
                6,9,2,4,7,0,5,1,0,2,8,4,2,3,8,1,2,5,1,7,8,4,5,7,8,
                1,3,1,9,2,9,6,2,2,1,0,2,6,1,2,8,9,7,1,3,5,2,5,1,3,
            };
        }

        private static List<int> CreateRollsSequence()
        {
            return new List<int>
            {
                6,6,6,1,3,1,6,4,1,2,4,6,1,2,3,4,2,3,1,1,6,1,6,6,3,
                4,6,4,4,2,6,4,2,5,5,4,6,4,1,6,5,5,5,5,1,2,3,3,4,4
            };
        }

    }

}
