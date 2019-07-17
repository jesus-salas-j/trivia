using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class GameShould
    {
        [TestMethod]
        public void Run_game()
        {
            string expectedOutput = File.ReadAllText("../../../Output/expected_output.txt");

            Game game = new Game();
            game.Run();

            string actualOutput = File.ReadAllText("./actual_output.txt");

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
