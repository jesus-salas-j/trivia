using System.Collections.Generic;

namespace TriviaGame
{
    public class Player
    {
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }
    }
}
