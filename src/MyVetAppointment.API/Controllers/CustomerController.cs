using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers
{
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
            if (result==false)
            {
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateCustomerModel)
        {
            var user = HttpContext.Items["User"] as User;
            if (user != null)
            {
                if (updateCustomerModel!.Password.Equals(updateCustomerModel.PasswordConfirm))
                {
                    var result = await _mediator.Send(new UpdateCustomerCommand
                    {
                        UpdateCustomerRequest = updateCustomerModel,
                        CustomerId = user.Id
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