using Bogus;
using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Domain.Resources;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MyBasketballScores.Domain.Test.Entities
{
    public class ScoreTest : IDisposable
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly Faker faker;

        private bool isRecord;

        public ScoreTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            faker = new Faker();

            isRecord = faker.Random.Bool();

            this.testOutputHelper.WriteLine("ScoreTest sendo executado.");
        }

        [Fact]
        public void Should_Create_Score()
        {
            var gameDate = faker.Date.Between(
                new DateTime(DateTime.Now.Year, 01, 01),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            );
            var totalScore = faker.Random.Int(0, 99);

            var expected = new { GameDate = gameDate, TotalScore = totalScore, IsRecord = isRecord };

            var score = new Score(gameDate, totalScore, isRecord);

            Assert.Equal(0, score.Notifications.Count);
            Assert.Equal(expected.GameDate, score.GameDate);
            Assert.Equal(expected.TotalScore, score.TotalScore);
        }

        [Fact]
        public void Not_Should_Create_Score()
        {
            var gameDate = faker.Date.Between(
                new DateTime(2010, 01, 01),
                new DateTime(2010, 12, 31)
            );
            var totalScore = faker.Random.Int(-99, -1);

            var score = new Score(gameDate, totalScore, isRecord);

            Assert.Equal(2, score.Notifications.Count);
            Assert.Equal(
                NotificationMessages.GameDateInvalid,
                score.Notifications.Where(x => x.Property == NotificationMessages.GameDateProperty).FirstOrDefault().Message
            );
            Assert.Equal(
                NotificationMessages.TotalScoreInvalid,
                score.Notifications.Where(x => x.Property == NotificationMessages.TotalScoreProperty).FirstOrDefault().Message
            );
        }

        [Fact]
        public void Not_Should_Create_Score_With_GameDate_Invalid()
        {
            var gameDate = faker.Date.Between(
                new DateTime(2010, 01, 01),
                new DateTime(2010, 12, 31)
            );
            var totalScore = faker.Random.Int(1, 99);

            var score = new Score(gameDate, totalScore, isRecord);

            Assert.Equal(1, score.Notifications.Count);
            Assert.Equal(
                NotificationMessages.GameDateInvalid,
                score.Notifications.Where(x => x.Property == NotificationMessages.GameDateProperty).FirstOrDefault().Message
            );
        }

        [Fact]
        public void Not_Should_Create_Score_With_TotalScore_Invalid()
        {
            var gameDate = faker.Date.Between(
                new DateTime(DateTime.Now.Year, 01, 01),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            );
            var totalScore = faker.Random.Int(-99, -1);

            var score = new Score(gameDate, totalScore, isRecord);

            Assert.Equal(1, score.Notifications.Count);
            Assert.Equal(
                NotificationMessages.TotalScoreInvalid,
                score.Notifications.Where(x => x.Property == NotificationMessages.TotalScoreProperty).FirstOrDefault().Message
            );
        }

        public void Dispose()
        {
            testOutputHelper.WriteLine("ScoreTest dispose sendo executado.");
        }
    }
}
