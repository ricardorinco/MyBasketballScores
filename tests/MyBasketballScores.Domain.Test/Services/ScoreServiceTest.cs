using Moq;
using MyBasketballScores.Domain.Arguments.Score;
using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Domain.Interfaces.Repositories;
using MyBasketballScores.Domain.Services;
using MyBasketballScores.Domain.Test.Utils;
using Xunit;

namespace MyBasketballScores.Domain.Test.Services
{
    public class ScoreServiceTest
    {
        private readonly ScoreService scoreService;
        private readonly Mock<IScoreRepository> scoreRepositoryMock;

        public ScoreServiceTest()
        {
            scoreRepositoryMock = new Mock<IScoreRepository>();

            scoreService = new ScoreService(scoreRepositoryMock.Object);
        }

        [Fact]
        public void Should_Add_New_Score()
        {
            ScoreRequest scoreRequest = new ScoreRequest
            {
                GameDate = DataGenerator.GameDateValid,
                TotalScore = DataGenerator.TotalScoreValid
            };

            scoreService.Save(scoreRequest);

            scoreRepositoryMock.Verify(x =>
                x.Save(
                    It.Is<Score>(s => 
                        s.GameDate == scoreRequest.GameDate
                        && s.TotalScore == scoreRequest.TotalScore
                        && s.IsRecord == false
                    )
                )
            );
        }

        [Fact]
        public void Should_Add_New_Score_Record()
        {
            scoreRepositoryMock.Setup(x => x.GetMaxScore()).Returns(1);

            ScoreRequest scoreRequest = new ScoreRequest
            {
                GameDate = DataGenerator.GameDateValid,
                TotalScore = DataGenerator.TotalScoreValid
            };

            scoreService.Save(scoreRequest);

            scoreRepositoryMock.Verify(x =>
                x.Save(
                    It.Is<Score>(s =>
                        s.GameDate == scoreRequest.GameDate
                        && s.TotalScore == scoreRequest.TotalScore
                        && s.IsRecord == true
                    )
                )
            );
        }
    }
}
