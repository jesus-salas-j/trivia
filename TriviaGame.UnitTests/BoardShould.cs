using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class BoardShould
    {
        private Board board;
        private Player A_PLAYER = new Player("John");

        [TestInitialize]
        public void Init()
        {
            board = new Board();
        }

        [TestMethod]
        public void Set_a_player_in_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            Assert.IsTrue(board.IsInPenaltyBox(A_PLAYER));
        }

        [TestMethod]
        public void Take_player_out_of_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            board.TakeOutOfPenaltyBox(A_PLAYER);

            Assert.AreEqual(0, board.PlayersInPenaltyBox());
        }

        [TestMethod]
        public void Check_if_player_is_in_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            Assert.IsTrue(board.IsInPenaltyBox(A_PLAYER));
        }
    }
}
