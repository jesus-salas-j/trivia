using System;
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
            if (IsLastPosition(CurrentPlayerPosition()))
            {
                current = players.ElementAt(0);
            }
            else
            {
                current = players.ElementAt(CurrentPlayerPosition() + 1);
            }            
        }

        private bool IsLastPosition(int position)
        {
            return position == players.Count - 1;
        }

        private int CurrentPlayerPosition()
        {
            return players.FindIndex(x => x.Equals(current));
        }

        public void IncrementGoldCoinsFor(Player player)
        {
            player.IncrementGoldCoins();
        }

        public void SetFirstPlayerAsCurrent()
        {
            current = players.First();
        }
    }
}
