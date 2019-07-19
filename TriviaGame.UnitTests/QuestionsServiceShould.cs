using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriviaGame.UnitTests
{
    [TestClass]
    public class QuestionsServiceShould
    {
        private QuestionsService questionsService;

        [TestInitialize]
        public void BeforeEach()
        {
            questionsService = new QuestionsService();
        }

        [TestMethod]
        public void Return_next_question()
        {
            Category category = Category.Rock;
            Question aQuestion = questionsService.Next(category);
            Question anotherQuestion = questionsService.Next(category);

            Assert.AreNotEqual(aQuestion, anotherQuestion);
        }
    }
}
