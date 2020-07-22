using MyBasketballScores.Domain.Arguments.Score;

namespace MyBasketballScores.Domain.Interfaces.Services
{
    public interface IScoreService
    {
        ScoreResponse Save(ScoreRequest request);
    }
}
