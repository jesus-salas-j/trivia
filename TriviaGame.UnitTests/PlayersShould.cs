using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class PlayersShould
    {
        private PlayersService playersService;

        private readonly Player A_PLAYER = new Player("John");

        [TestInitialize]
        public void Init()
        {
            playersService = new PlayersService();
        }

        [TestMethod]
        public void Count_zero_players_when_no_players_are_added()
        {
            Assert.AreEqual(0, playersService.Count());
        }

        [TestMethod]
        public void Count_players_when_players_are_added()
        {
            playersService.Add(A_PLAYER);

            Assert.AreEqual(1, playersService.Count());
        }

        [TestMethod]
        public void Set_current_player_if_exists()
        {
            playersService.Add(A_PLAYER);

            playersService.SetCurrent(A_PLAYER);

            Assert.AreEqual(A_PLAYER, playersService.Current());
        }
    }
}
