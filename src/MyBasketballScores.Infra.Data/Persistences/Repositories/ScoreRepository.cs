using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Domain.Interfaces.Repositories;
using MyBasketballScores.Infra.Data.Persistences.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBasketballScores.Infra.Data.Persistences.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly MyBasketballScoresContext context;

        public ScoreRepository(MyBasketballScoresContext context)
        {
            this.context = context;
        }

        public Score Save(Score score)
        {
            context.Scores.Add(score);

            return score;
        }

        public Dictionary<string, DateTime> GetSeason()
        {
            var start = context.Scores
                .OrderBy(x => x.GameDate)
                .Select(x => x.GameDate)
                .FirstOrDefault();

            var end = context.Scores
                .OrderByDescending(x => x.GameDate)
                .Select(x => x.GameDate)
                .FirstOrDefault();

            return new Dictionary<string, DateTime>()
            {
                { "start", start },
                { "end", end },
            };
        }

        public int GetTotalGamesPlayed()
        {
            return context.Scores.Count();
        }
        public int GetTotalSeasonScores()
        {
            return context.Scores.Sum(x => x.TotalScore);
        }
        public int GetAverageSeasonScores()
        {
            var averageSeasonScores = context.Scores
                .Average(x => (int?)x.TotalScore) ?? 0;

            return Convert.ToInt32(averageSeasonScores);
        }
        public int GetMaxScore()
        {
            var maxScore = context.Scores
                .OrderByDescending(x => x.TotalScore)
                .FirstOrDefault();

            return maxScore == null ? 0 : maxScore.TotalScore;
        }
        public int GetMinimumScore()
        {
            var minimumScore = context.Scores
                .OrderBy(x => x.TotalScore)
                .FirstOrDefault();

            return minimumScore == null ? 0 : minimumScore.TotalScore;
        }
        public int GetTotalRecordBroken()
        {
            return context.Scores.Where(x => x.IsRecord).Count();
        }
    }
}
