using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class PlayersServiceShould
    {
        private PlayersService playersService;

        private Player A_PLAYER = new Player("John");
        private Player ANOTHER_PLAYER = new Player("Ann");

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

        [TestMethod]
        public void Set_next_player_as_current()
        {
            playersService.Add(A_PLAYER);
            playersService.Add(ANOTHER_PLAYER);

            playersService.SetCurrent(A_PLAYER);
            playersService.SetNextPlayerAsCurrent();

            Assert.AreEqual(ANOTHER_PLAYER, playersService.Current());
        }

        [TestMethod]
        public void Set_first_player_as_current_when_current_player_is_the_last()
        {
            playersService.Add(A_PLAYER);
            playersService.Add(ANOTHER_PLAYER);

            playersService.SetCurrent(A_PLAYER);
            playersService.SetNextPlayerAsCurrent();
            playersService.SetNextPlayerAsCurrent();

            Assert.AreEqual(A_PLAYER, playersService.Current());
        }

        [TestMethod]
        public void Increment_player_gold_coins()
        {
            Player player = new Player("Charles");
            playersService.Add(player);

            playersService.IncrementGoldCoinsFor(player);

            Assert.AreEqual(1, player.GoldCoins());
        }
    }
}
