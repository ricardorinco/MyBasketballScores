namespace MyBasketballScores.Domain.Arguments.Score
{
    public class LastMaxScoreResponse
    {
        public int TotalScore { get; set; }

        public static explicit operator LastMaxScoreResponse(int score)
        {
            return new LastMaxScoreResponse()
            {
                TotalScore = score
            };
        }
    }
}
