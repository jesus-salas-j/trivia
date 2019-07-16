using System;
using System.Collections.Generic;

namespace TriviaGame
{
    public class Square
    {
        private readonly int position;
        public List<Player> Players { get; }

        public Square(int position)
        {
            this.position = position;
            Players = new List<Player>();
        }

        public void Add(Player player)
        {
            Players.Add(player);
        }

        public void Remove(Player player)
        {
            Players.Remove(player);
        }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   position == square.position;
        }

        public override int GetHashCode()
        {
            return 1206833562 + position.GetHashCode();
        }

    }
}