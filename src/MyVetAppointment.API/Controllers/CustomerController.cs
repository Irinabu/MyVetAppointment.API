using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CustomerController : BaseController

{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpDelete("delete-customer/{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        return Ok(_customerService.DeleteCustomer(id));
    }


    [HttpGet("customers")]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(_customerService.GetAllAsync());
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetCustomerByEmail(string email)
    {
        return Ok(_customerService.GetCustomerByEmailAsync(email));
    }

    [HttpPost("add-animal")]
    public async Task<IActionResult> AddNewAnimal([FromBody] AnimalRequest model)
    {
        var user = HttpContext.Items["User"] as User;
        var response = await _customerService.AddAnimalAsync(model, user);
        return Created("af", response);
    }
}