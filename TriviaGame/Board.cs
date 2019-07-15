using System.Collections.Generic;

namespace TriviaGame
{
    public class Board
    {
        List<Player> playersInPenaltyBox;

        public Board()
        {
            playersInPenaltyBox = new List<Player>();
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
    }
}
