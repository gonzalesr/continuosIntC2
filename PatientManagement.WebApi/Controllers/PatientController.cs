using PatientManagement.Application.Patients.CreatePatient;
using PatientManagement.Application.Patients.GetPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PatientManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient([FromBody] CreatePatientCommand command)
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
        public async Task<ActionResult> GetPatients()
        {
            try
            {
                var result = await _mediator.Send(new GetPatientsQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
