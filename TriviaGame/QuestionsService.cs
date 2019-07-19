using System.Collections.Generic;

namespace TriviaGame
{
    public class QuestionsService
    {
        private const int QUESTIONS_NUMBER = 50;

        private List<Question> PopQuestions = new List<Question>();
        private List<Question> ScienceQuestions = new List<Question>();
        private List<Question> SportsQuestions = new List<Question>();
        private List<Question> RockQuestions = new List<Question>();

        int nextPopQuestion = 0;
        int nextScienceQuestion = 0;
        int nextSportsQuestion = 0;
        int nextRockQuestion = 0;

        public QuestionsService()
        {
            for (int i = 0; i < QUESTIONS_NUMBER; i++)
            {
                PopQuestions.Add(new Question("Pop Question " + i, Category.Pop));
                ScienceQuestions.Add(new Question("Science Question " + i, Category.Science));
                SportsQuestions.Add(new Question("Sports Question " + i, Category.Sports));
                RockQuestions.Add(new Question("Rock Question " + i, Category.Rock));
            }
        }

        public Question Next(Category category)
        {
            Question question = null;

            switch (category)
            {
                case Category.Pop:
                    question = PopQuestions[nextPopQuestion];
                    nextPopQuestion++;
                    break;
                case Category.Science:
                    question = ScienceQuestions[nextScienceQuestion];
                    nextScienceQuestion++;
                    break;
                case Category.Sports:
                    question = SportsQuestions[nextSportsQuestion];
                    nextSportsQuestion++;
                    break;
                case Category.Rock:
                    question = RockQuestions[nextRockQuestion];
                    nextRockQuestion++;
                    break;
            }

            return question;
        }
    }
}
