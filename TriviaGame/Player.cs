using System.Collections.Generic;

namespace TriviaGame
{
    public class Player
    {
        public string Name { get; }
        private int goldCoins = 0;

        public Player(string name)
        {
            Name = name;
        }

        public int GoldCoins()
        {
            return goldCoins;
        }

        public void IncrementGoldCoins()
        {
            goldCoins++;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name;
        }
        
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

    }
}
