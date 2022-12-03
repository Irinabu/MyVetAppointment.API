using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Services;

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

    /*
    [HttpPut("update-customer")]
    public async Task<IActionResult> UpdateCustomers([FromBody] UpdateRequest model)
    {
        return Ok();
    }
    */
}