using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers
{
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
            if (!result)
            {
                return BadRequest($"No vet found with the id {id}");
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateVetDoctorModel)
        {
            var user = HttpContext.Items["User"] as User;
            if (user != null)
            {
                if (updateVetDoctorModel!.Password!.Equals(updateVetDoctorModel.PasswordConfirm))
                {
                    var result = await _mediator.Send(new UpdateVetDoctorCommand
                    {
                        UpdateVetDoctorRequest = updateVetDoctorModel,
                        VetDoctorId = user.Id
                    });

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Wrong PasswordConfirm");
                }
            }

            return BadRequest();
        }

    }
}