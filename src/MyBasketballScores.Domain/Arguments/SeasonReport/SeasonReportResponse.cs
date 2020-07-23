namespace MyBasketballScores.Domain.Arguments.SeasonReport
{
    public class SeasonReportResponse
    {
        public SeasonResponse Season { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalSeasonScores { get; set; }
        public int AverageSeasonScores { get; set; }
        public int MaxScore { get; set; }
        public int MinimumScore { get; set; }
        public int TotalRecordBroken { get; set; }
    }
}
