using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;

namespace MyVetAppointment.API.Controllers
{

    [ApiController]
    [Authorize]
    //[AllowAnonymous]
    [Route("[controller]")]
    public class VetDoctorController : BaseController
    {
        private readonly IMediator _mediator;

        public VetDoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("delete-vet/{id}")]
        public async Task<IActionResult> DeleteVetDoctor([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteVetDoctorByIdCommand
            {
                Id = id
            });
            if (result.IsNullOrEmpty())
            {
                return BadRequest($"No customer found with the id {id}");
            }
            return Ok(true);
        }

        [HttpGet("vets")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetVetDoctorsQuery());

            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            var result = await _mediator.Send(new GetVetDoctorByEmailQuery
            {
                Email = email
            });

            return Ok(result);
        }

    }
}