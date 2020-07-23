using System;

namespace MyBasketballScores.Domain.Arguments.Score
{
    public class ScoreRequest
    {
        public DateTime GameDate { get; set; }
        public int TotalScore { get; set; }
    }
}
