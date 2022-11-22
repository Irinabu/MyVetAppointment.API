using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers;

[AllowAnonymous]
public class AuthenticateController : BaseController
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

   
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        var response =await _authenticateService.LoginAsync(model);
        
        return Ok(response);
    }
    [HttpPost("register-customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterRequest model)
    {
        await _authenticateService.RegisterCustomerAsync(model);

        return Created("af", model);
    }
    [HttpPost("register-vet-doctor")]
    public async Task<IActionResult> RegisterVetDoctor([FromBody] RegisterRequest model)
    {
        await _authenticateService.RegisterVetDoctorAsync(model);

        return Created("af", model);
    }
}
