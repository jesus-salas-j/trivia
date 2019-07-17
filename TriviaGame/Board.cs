using System;
using System.Collections.Generic;
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

        public void TakeOutOfPenaltyBox(Player player)
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

            for (int i = 0; i < NUMBER_OF_SQUARES; i++)
            {
                Squares.Add(new Square(i));
            }
        }

        public void MovePlayerForward(Player player, int positions)
        {
            Square square = Squares.Single(x => x.Players.Contains(player));
            square.Players.Remove(player);
            Squares
                .Single(x => x.Position == square.Position + positions)
                .Players.Add(player);
        }
    }
}
