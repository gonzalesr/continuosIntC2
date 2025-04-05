using PatientManagement.Application.InitialConsultation.CreateInitialConsultation;
using PatientManagement.Application.InitialConsultation.GetInitialConsultations;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace PatientManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialConsultationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InitialConsultationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateInitialConsultation([FromBody] CreateInitialConsultationCommand command)
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
        public async Task<ActionResult> GetInitialConsultations()
        {
            try
            {
                var result = await _mediator.Send(new GetInitialConsultationQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
