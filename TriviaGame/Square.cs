using System.Collections.Generic;

namespace TriviaGame
{
    public class Square
    {
        public int Position { get; }
        public List<Player> Players { get; }

        public Square(int position)
        {
            Position = position;
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
                   Position == square.Position;
        }

        public override int GetHashCode()
        {
            return 1206833562 + Position.GetHashCode();
        }

    }
}