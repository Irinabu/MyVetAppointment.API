using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers
{

    [ApiController]
    [Authorize]
    //[AllowAnonymous]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator, ICustomerService customerService)
        {
            _mediator = mediator;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCustomersQuery());

            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            var result = await _mediator.Send(new GetCustomerByEmailQuery
            {
                Email = email
            });

            return Ok(result);
        }
        
        [HttpDelete("delete-customer/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
        {
            var result = await _mediator.Send(new DeleteCustomerByIdCommand
            {
                Id = id
            });
            if(result.IsNullOrEmpty()) {
                return BadRequest($"No customer found with the id {id}");
            }
            return Ok(true);
        }


        [HttpGet("animals")]
        public async Task<IActionResult> GetAnimals()
        {
            var user = HttpContext.Items["User"] as User;
            if (user != null)
            {
                var result = await _mediator.Send(new GetCustomerAnimalsQuery
                {
                    Id = user.Id.ToString()
                });
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("add-animal")]
        public async Task<IActionResult> AddNewAnimal([FromBody] AnimalRequest model)
        {
            var user = HttpContext.Items["User"] as User;
            if (user != null)
            {
                var result = await _mediator.Send(new AddNewAnimalCommand
                {
                    AnimalRequest=model,
                    UserId = user.Id.ToString()
                });
                return Created("af", result);
            }

            return BadRequest();
        }
    }
}