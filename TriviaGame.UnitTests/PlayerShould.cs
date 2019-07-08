using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class PlayerShould
    {
        const string A_NAME = "any player name";

        [TestMethod]
        public void Be_created_with_zero_coins_in_purse()
        {
            Player player = new Player(A_NAME);

            Assert.AreEqual(0, player.GoldCoins());
        }

        [TestMethod]
        public void Increment_gold_coins()
        {
            Player player = new Player(A_NAME);

            player.IncrementGoldCoins();

            Assert.AreEqual(1, player.GoldCoins());
        }
    }
}
