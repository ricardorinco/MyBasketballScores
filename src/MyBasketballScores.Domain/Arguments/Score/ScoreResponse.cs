using System;

namespace MyBasketballScores.Domain.Arguments.Score
{
    public class ScoreResponse
    {
        public Guid Id { get; set; }

        public DateTime GameDate { get; set; }
        public int TotalScore { get; set; }
        public bool IsRecord { get; set; }


        public static explicit operator ScoreResponse(Entities.Score score)
        {
            return new ScoreResponse()
            {
                Id = score.Id,

                GameDate = score.GameDate,
                TotalScore = score.TotalScore.Value,
                IsRecord = score.IsRecord
            };
        }
    }
}
