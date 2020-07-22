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
            // TODO: Tratamento para verificar se a pontuação inserida é um novo recorde pessoal
            var score = new Score(request.GameDate, request.Total, true);

            scoreRepository.Save(score);

            return (ScoreResponse)score;
        }
    }
}
