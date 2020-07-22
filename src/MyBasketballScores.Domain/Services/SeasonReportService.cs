using MyBasketballScores.Domain.Arguments.SeasonReport;
using MyBasketballScores.Domain.Interfaces.Repositories;
using MyBasketballScores.Domain.Interfaces.Services;
using System.Linq;

namespace MyBasketballScores.Domain.Services
{
    public class SeasonReportService : ISeasonReportService
    {
        private readonly IScoreRepository scoreRepository;

        public SeasonReportService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public SeasonReportResponse GetSeasonReport()
        {
            var season = scoreRepository.GetSeason();

            var response = new SeasonReportResponse()
            {
                Season = new SeasonResponse
                {
                    Start = season.FirstOrDefault(x => x.Key == "start").Value,
                    End = season.FirstOrDefault(x => x.Key == "end").Value
                },

                TotalGamesPlayed = scoreRepository.GetTotalGamesPlayed(),
                TotalSeasonScores = scoreRepository.GetTotalSeasonScores(),
                AverageSeasonScores = scoreRepository.GetAverageSeasonScores(),
                MaxScore = scoreRepository.GetMaxScore(),
                MinimumScore = scoreRepository.GetMinimumScore(),
                TotalRecordBroken = scoreRepository.GetTotalRecordBroken()
            };

            return response;
        }
    }
}
