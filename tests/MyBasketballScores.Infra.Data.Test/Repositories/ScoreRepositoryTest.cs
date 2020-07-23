using Microsoft.EntityFrameworkCore;
using Moq;
using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Domain.Test.Utils;
using MyBasketballScores.Infra.Data.Persistences.DataContext;
using MyBasketballScores.Infra.Data.Persistences.Repositories;
using Xunit;

namespace MyBasketballScores.Infra.Data.Test.Repositories
{
    public class ScoreRepositoryTest
    {
        private readonly Mock<MyBasketballScoresContext> contextMock;
        private readonly Mock<DbSet<Score>> dbSetMock;

        public ScoreRepositoryTest()
        {
            contextMock = new Mock<MyBasketballScoresContext>();
            dbSetMock = new Mock<DbSet<Score>>();
        }

        [Fact]
        public void Should_Add_New_Score()
        {
            var score = new Score(
                DataGenerator.GameDateValid,
                DataGenerator.TotalScoreValid,
                true
            );
            
            dbSetMock.Setup(x => x.Add(score));
            contextMock.Setup(x => x.Set<Score>()).Returns(dbSetMock.Object);

            var scoreRepository = new ScoreRepository(contextMock.Object);
            var scoreReturned = scoreRepository.Save(score);

            Assert.NotNull(scoreReturned);
            Assert.IsAssignableFrom<Score>(score);
        }
    }
}
