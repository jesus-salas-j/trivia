using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class PlayerShould
    {
        private string name = "any name";

        [TestMethod]
        public void Be_created_with_zero_coins_in_purse()
        {
            Player player = new Player(name);

            Assert.AreEqual(0, player.GoldCoins());
        }
    }
}
