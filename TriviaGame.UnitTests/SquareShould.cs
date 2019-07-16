using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class SquareShould
    {
        private Player A_PLAYER = new Player("John");

        [TestMethod]
        public void Add_player()
        {
            Square square = new Square(position: 0);

            square.Add(A_PLAYER);

            Assert.IsTrue(square.Players.Contains(A_PLAYER));
        }

        [TestMethod]
        public void Remove_player()
        {
            Square square = new Square(position: 0);

            square.Add(A_PLAYER);
            square.Remove(A_PLAYER);

            Assert.IsFalse(square.Players.Contains(A_PLAYER));
        }
    }
}
