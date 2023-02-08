using System.Collections.Generic;

namespace Models
{
    public class Result
    {
        public List<Answer> AnswersList;
        public int RoundIndex;
        public double GameTime;

        public Result(List<Answer> answers, int roundIndex, double gameTime)
        {
            AnswersList = answers;
            RoundIndex = roundIndex;
            GameTime = gameTime;
        }
    }
}