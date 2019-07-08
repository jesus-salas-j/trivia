using System.Collections.Generic;
using System.Linq;

namespace TriviaGame
{
    public class PlayersService
    {
        private List<Player> players;
        private Player current;

        public PlayersService()
        {
            players = new List<Player>();
        }

        public int Count()
        {
            return players.Count;
        }

        public void Add(Player player)
        {
            players.Add(player);
        }

        public void SetCurrent(Player player)
        {
            current = player;
        }

        public Player Current()
        {
            return current;
        }

        public void SetNextPlayerAsCurrent()
        {
            int currentPlayerPosition = players.FindIndex(x => x.Equals(current));
            current = players.ElementAt(currentPlayerPosition + 1);
        }
    }
}
