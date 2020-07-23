using MyBasketballScores.Domain.Arguments.SeasonReport;

namespace MyBasketballScores.Domain.Interfaces.Services
{
    public interface ISeasonReportService
    {
        SeasonReportResponse GetSeasonReport();
    }
}
