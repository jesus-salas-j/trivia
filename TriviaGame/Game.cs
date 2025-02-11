﻿using System;
using System.Collections.Generic;
using System.IO;

namespace TriviaGame
{
    public class Game
    {
        private const int COINS_TO_WIN = 6;
        private bool notAWinner;

        private PlayersService playersService;
        private QuestionsService questionsService;
        private Board board;

        private StreamWriter writer;

        public Game()
        {
            SetConsoleOutputToFile();

            playersService = new PlayersService();
            questionsService = new QuestionsService();
            board = new Board();
        }

        public void Run()
        {
            InitializePlayers();

            List<int> rolls = CreateRollsSequence();
            List<int> squares = CreateSquaresSequence();

            int next = 0;

            do
            {
                Roll(rolls[next]);

                if (squares[next] == 7)
                {
                    notAWinner = true;
                    MessagingService.Send("Question was incorrectly answered");
                    MessagingService.Send(playersService.Current().Name + " was sent to the penalty box");
                    board.PutInPenaltyBox(playersService.Current());
                    playersService.SetNextPlayerAsCurrent();
                }
                else
                {
                    if (board.IsInPenaltyBox(playersService.Current()))
                    {
                        playersService.SetNextPlayerAsCurrent();
                        notAWinner = true;
                    }
                    else
                    {
                        MessagingService.Send("Answer was corrent!!!!");
                        playersService.Current().IncrementGoldCoins();
                        MessagingService.Send(playersService.Current().Name
                                + " now has "
                                + playersService.Current().GoldCoins()
                                + " Gold Coins.");

                        notAWinner = playersService.Current().GoldCoins() != COINS_TO_WIN;
                        playersService.SetNextPlayerAsCurrent();
                    }
                }

                next++;
            } while (notAWinner);

            writer.Close();
        }

        public void Add(String playerName)
        {
            Player player = new Player(playerName);
            playersService.Add(player);
            board.Add(player);

            MessagingService.Send(playerName + " was added");
            MessagingService.Send("They are player number " + playersService.Count());
        }

        public void Roll(int roll)
        {
            MessagingService.Send(playersService.Current().Name + " is the current player");
            MessagingService.Send("They have rolled a " + roll);

            if (board.IsInPenaltyBox(playersService.Current()))
            {
                if (IsPair(roll))
                {
                    board.TakeOffPenaltyBox(playersService.Current());                    
                    board.MovePlayerForward(playersService.Current(), roll);

                    MessagingService.Send(playersService.Current().Name + " is getting out of the penalty box");
                    MessagingService.Send(playersService.Current().Name
                            + "'s new location is "
                            + board.PositionOf(playersService.Current()));
                    MessagingService.Send("The category is " + CurrentCategory().ToString());

                    AskQuestion();
                }
                else
                {
                    MessagingService.Send(playersService.Current().Name + " is not getting out of the penalty box");
                }
            }
            else
            {
                board.MovePlayerForward(playersService.Current(), roll);

                MessagingService.Send(playersService.Current().Name
                        + "'s new location is "
                        + board.PositionOf(playersService.Current()));
                MessagingService.Send("The category is " + CurrentCategory().ToString());

                AskQuestion();
            }
        }

        private static bool IsPair(int roll)
        {
            return roll % 2 != 0;
        }

        private void InitializePlayers()
        {
            Add("Chet");
            Add("Pat");
            Add("Sue");

            playersService.SetFirstPlayerAsCurrent();
        }

        private void SetConsoleOutputToFile()
        {
            writer = new StreamWriter("./actual_output.txt");
            Console.SetOut(writer);
        }

        private void AskQuestion()
        {
            MessagingService.Send(questionsService.Next(CurrentCategory()).Content);
        }

        private Category CurrentCategory()
        {
            int currentPosition = board.PositionOf(playersService.Current());
            return board.CategoryFrom(currentPosition);
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
