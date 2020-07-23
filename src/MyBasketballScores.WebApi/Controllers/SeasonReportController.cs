using Microsoft.AspNetCore.Mvc;
using MyBasketballScores.Domain.Arguments.SeasonReport;
using MyBasketballScores.Domain.Interfaces.Services;
using System;

namespace MyBasketballScores.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/season-report")]
    public class SeasonReportController : ControllerBase
    {
        private readonly ISeasonReportService seasonReportService;

        public SeasonReportController(ISeasonReportService seasonReportService)
        {
            this.seasonReportService = seasonReportService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<SeasonReportResponse> Get()
        {
            try
            {
                var response = seasonReportService.GetSeasonReport();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
    }
}
