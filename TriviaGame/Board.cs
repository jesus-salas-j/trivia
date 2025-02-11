﻿using System.Collections.Generic;
using System.Linq;

namespace TriviaGame
{
    public class Board
    {
        private const int NUMBER_OF_SQUARES = 12;
        private List<Player> playersInPenaltyBox;
        public List<Square> Squares { get; private set; }

        public Board()
        {
            playersInPenaltyBox = new List<Player>();
            InitializeSquares();
        }


        public void PutInPenaltyBox(Player player)
        {
            playersInPenaltyBox.Add(player);
        }

        public bool IsInPenaltyBox(Player player)
        {
            return playersInPenaltyBox.Contains(player);
        }

        public void TakeOffPenaltyBox(Player player)
        {
            playersInPenaltyBox.Remove(player);
        }

        public int PlayersInPenaltyBox()
        {
            return playersInPenaltyBox.Count;
        }

        public void Add(Player player)
        {
            Squares.First().Add(player);
        }

        public List<Player> GetPlayersIn(Square square)
        {
            return Squares
                .Single(x => x.Equals(square))
                .Players;
        }

        private void InitializeSquares()
        {
            Squares = new List<Square>();

            for (int position = 0; position < NUMBER_OF_SQUARES; position++)
            {
                Squares.Add(new Square(position, GetCategoryFrom(position)));
            }
        }

        public void MovePlayerForward(Player player, int positions)
        {
            Square square = Squares.Single(x => x.Players.Contains(player));
            square.Players.Remove(player);
            int newPosition = (square.Position + positions) % NUMBER_OF_SQUARES;
            Squares
                .Single(x => x.Position == newPosition)
                .Players.Add(player);
        }

        public int PositionOf(Player player)
        {
            return Squares
                .Single(x => x.Players.Contains(player))
                .Position;
        }

        public Category CategoryFrom(int position)
        {
            return Squares
                .Single(x => x.Position == position)
                .Category;
        }

        private Category GetCategoryFrom(int position)
        {
            if (position % 4 == 0)
            {
                return Category.Pop;
            }
            else if (position % 4 == 1)
            {
                return Category.Science;
            }
            else if (position % 4 == 2)
            {
                return Category.Sports;
            }

            return Category.Rock;
        }
    }
}
