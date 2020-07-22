using System;
using YouLearn.Domain.Entities.Base;

namespace MyBasketballScores.Domain.Entities
{
    public class Score : EntityBase
    {
        public Score() { }
        public Score(DateTime gameDate, int? totalScore, bool isRecord)
        {
            GameDate = gameDate;
            TotalScore = totalScore.HasValue ? totalScore.Value : 0;
            IsRecord = isRecord;
        }

        public DateTime GameDate { get; private set; }
        public int? TotalScore { get; private set; }
        public bool IsRecord { get; private set; }
    }
}
