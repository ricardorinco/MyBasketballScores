using Microsoft.AspNetCore.Mvc;
using MyBasketballScores.Domain.Arguments.Score;
using MyBasketballScores.Domain.Interfaces.Services;
using MyBasketballScores.Infra.Data.Transactions;
using System;
using System.Linq;

namespace MyBasketballScores.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/score")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService scoreService;
        private readonly IUnitOfWork unitOfWork;

        public ScoreController(IScoreService scoreService, IUnitOfWork unitOfWork)
        {
            this.scoreService = scoreService;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ScoreResponse> Add([FromBody]ScoreRequest request)
        {
            var response = scoreService.Save(request);
            if (!response.Notifications.Any())
            {
                try
                {
                    unitOfWork.Commit();

                    return Created(string.Empty, response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                response.Notifications = response.Notifications;
                return BadRequest(response);
            }
        }
    }
}
