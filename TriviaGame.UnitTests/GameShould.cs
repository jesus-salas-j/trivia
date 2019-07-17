using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class GameShould
    {
        [TestMethod]
        public void Run_game()
        {
            Game game = new Game();
            game.Run();
        }
    }
}
