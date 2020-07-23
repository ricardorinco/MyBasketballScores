using Flunt.Validations;
using MyBasketballScores.Domain.Resources;
using System;
using YouLearn.Domain.Entities.Base;

namespace MyBasketballScores.Domain.Entities
{
    public class Score : EntityBase
    {
        public Score() { }
        public Score(DateTime gameDate, int totalScore, bool isRecord)
        {
            AddNotifications(new Contract()
                .IsBetween(
                    gameDate,
                    new DateTime(DateTime.Now.Year, 01, 01),
                    DateTime.Now,
                    NotificationMessages.GameDateProperty,
                    NotificationMessages.GameDateInvalid
                )
                .IsGreaterOrEqualsThan(
                    totalScore,
                    0,
                    NotificationMessages.TotalScoreProperty,
                    NotificationMessages.TotalScoreInvalid
                )
            );

            GameDate = gameDate;
            TotalScore = totalScore;
            IsRecord = isRecord;
        }

        public DateTime GameDate { get; private set; }
        public int TotalScore { get; private set; }
        public bool IsRecord { get; private set; }
    }
}
