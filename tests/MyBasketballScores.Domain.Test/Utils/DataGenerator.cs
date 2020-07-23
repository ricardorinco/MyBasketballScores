using Bogus;
using System;

namespace MyBasketballScores.Domain.Test.Utils
{
    public static class DataGenerator
    {
        #region GameDate

        public static DateTime GameDateInvalid = new Faker().Date.Between(
            new DateTime(2010, 01, 01),
            new DateTime(2010, 12, 31)
        );
        public static DateTime GameDateValid = new Faker().Date.Between(
            new DateTime(DateTime.Now.Year, 01, 01),
            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        );

        #endregion

        #region TotalScore

        public static int TotalScoreInvalid = new Faker().Random.Int(-99, -1);
        public static int TotalScoreValid = new Faker().Random.Int(2, 99);

        #endregion
    }
}
