using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace MyBasketballScores.Domain.Arguments.Score
{
    public class ScoreResponse
    {
        public Guid Id { get; set; }

        public DateTime GameDate { get; set; }
        public int TotalScore { get; set; }
        public bool IsRecord { get; set; }

        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public static explicit operator ScoreResponse(Entities.Score score)
        {
            return new ScoreResponse()
            {
                Id = score.Id,

                GameDate = score.GameDate,
                TotalScore = score.TotalScore,
                IsRecord = score.IsRecord,

                Notifications = score.Notifications
            };
        }
    }
}
