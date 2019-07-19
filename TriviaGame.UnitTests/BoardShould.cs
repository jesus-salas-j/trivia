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
        public void Initialize_with_twelve_squares()
        {
            Assert.AreEqual(12, board.Squares.Count);
        }

        [TestMethod]
        public void Set_player_in_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            Assert.IsTrue(board.IsInPenaltyBox(A_PLAYER));
        }

        [TestMethod]
        public void Take_player_off_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            board.TakeOffPenaltyBox(A_PLAYER);

            Assert.AreEqual(0, board.PlayersInPenaltyBox());
        }

        [TestMethod]
        public void Check_if_player_is_in_penalty_box()
        {
            board.PutInPenaltyBox(A_PLAYER);

            Assert.IsTrue(board.IsInPenaltyBox(A_PLAYER));
        }

        [TestMethod]
        public void Put_player_in_board()
        {
            Square square = new Square(position: 0, category: Category.Pop);

            board.Add(A_PLAYER);

            Assert.IsTrue(board.GetPlayersIn(square).Contains(A_PLAYER));
        }

        [TestMethod]
        public void Move_player_forward()
        {
            int positions = 3;
            Square originSquare = new Square(position: 0, category: Category.Pop);
            Square endSquare = new Square(position: 3, category: Category.Pop);
            board.Add(A_PLAYER);

            board.MovePlayerForward(player: A_PLAYER, positions: positions);

            Assert.IsFalse(board.GetPlayersIn(originSquare).Contains(A_PLAYER));
            Assert.IsTrue(board.GetPlayersIn(endSquare).Contains(A_PLAYER));
        }

        [TestMethod]
        public void Move_player_circular()
        {
            int positions = 14;
            Square originSquare = new Square(position: 0, category: Category.Pop);
            Square endSquare = new Square(position: 2, category: Category.Pop);
            board.Add(A_PLAYER);

            board.MovePlayerForward(player: A_PLAYER, positions: positions);

            Assert.IsFalse(board.GetPlayersIn(originSquare).Contains(A_PLAYER));
            Assert.IsTrue(board.GetPlayersIn(endSquare).Contains(A_PLAYER));
        }

        [TestMethod]
        public void Tell_a_player_position()
        {
            board.Add(A_PLAYER);

            Assert.AreEqual(0, board.PositionOf(A_PLAYER));
        }

        [TestMethod]
        public void Return_position_category()
        {
            Assert.AreEqual(Category.Pop, board.CategoryFrom(position: 0));
        }
    }
}
