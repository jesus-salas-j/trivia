﻿using System;
using System.Collections.Generic;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            List<int> rolls = CreateRollsSequence();
            List<int> squares = CreateSquaresSequence();

            int next = 0;

            do
            {

                aGame.roll(rolls[next]);

                if (squares[next] == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }

                next++;

            } while (notAWinner);

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

