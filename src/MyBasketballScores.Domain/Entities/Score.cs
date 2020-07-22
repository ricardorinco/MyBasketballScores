using Flunt.Validations;
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
                .IsBetween(gameDate, new DateTime(DateTime.Now.Year, 01, 01), DateTime.Now, "Data do Jogo", "Informe uma data válida")
                .IsGreaterOrEqualsThan(totalScore, 0, "Pontuação", "Informe um valor válido")
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
