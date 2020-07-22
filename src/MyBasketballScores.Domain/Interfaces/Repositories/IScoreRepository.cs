using MyBasketballScores.Domain.Entities;

namespace MyBasketballScores.Domain.Interfaces.Repositories
{
    public interface IScoreRepository
    {
        Score Save(Score score);
    }
}
