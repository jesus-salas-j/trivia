using System.Collections.Generic;

namespace TriviaGame
{
    public class Question
    {
        public string Content { get; }
        public Category Category { get; }

        public Question(string content, Category category)
        {
            Content = content;
            Category = category;
        }

        public override bool Equals(object obj)
        {
            return obj is Question question &&
                   Content == question.Content &&
                   Category == question.Category;
        }

        public override int GetHashCode()
        {
            var hashCode = 650245699;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            return hashCode;
        }
    }
}
