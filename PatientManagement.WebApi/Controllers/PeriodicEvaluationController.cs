using PatientManagement.Application.Evaluations.CreateEvaluation;
using PatientManagement.Application.Evaluations.GetEvaluations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PatientManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicEvaluationController : Controller
    {
        private readonly IMediator _mediator;
        public PeriodicEvaluationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreatePeriodicEvaluation([FromBody] CreatePeriodicEvaluationCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetPeriodicEvaluation()
        {
            try
            {
                var result = await _mediator.Send(new GetPeriodicEvaluationQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
