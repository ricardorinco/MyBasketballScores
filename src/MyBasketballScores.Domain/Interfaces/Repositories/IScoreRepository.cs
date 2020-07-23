using MyBasketballScores.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyBasketballScores.Domain.Interfaces.Repositories
{
    public interface IScoreRepository
    {
        Score Save(Score score);

        Dictionary<string, DateTime> GetSeason();
        int GetTotalGamesPlayed();
        int GetTotalSeasonScores();
        int GetAverageSeasonScores();
        int GetMaxScore();
        int GetMinimumScore();
        int GetTotalRecordBroken();
    }
}
