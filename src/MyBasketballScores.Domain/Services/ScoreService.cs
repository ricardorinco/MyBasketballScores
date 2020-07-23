using MyBasketballScores.Domain.Arguments.Score;
using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Domain.Interfaces.Repositories;
using MyBasketballScores.Domain.Interfaces.Services;

namespace MyBasketballScores.Domain.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public ScoreResponse Save(ScoreRequest request)
        {
            bool newRecord = false;
            var lastMaxScore = GetMaxScore();

            if (request.TotalScore > lastMaxScore.TotalScore && lastMaxScore.TotalScore > 0)
            {
                newRecord = true;
            }

            var score = new Score(request.GameDate, request.TotalScore, newRecord);
            if (score.Valid)
            {
                scoreRepository.Save(score);
            }

            return (ScoreResponse)score;
        }

        public LastMaxScoreResponse GetMaxScore()
        {
            return (LastMaxScoreResponse)scoreRepository.GetMaxScore();
        }
    }
}
