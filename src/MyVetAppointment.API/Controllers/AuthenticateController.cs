using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers;

public class AuthenticateController : BaseController
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost("login")]
   


    public IActionResult Login([FromBody] LoginRequest model)
    {
        // var response = _authenticateService.Login(model);
        //
        // return Ok(response);
        return Ok();
    }
    [HttpPost("register-customer")]
    public IActionResult RegisterCustomer([FromBody] RegisterRequest model)
    {
        var response = _authenticateService.RegisterCustomerAsync(model);

        return Created("af", model);
    }
    [HttpPost("register-vet-doctor")]
    public IActionResult RegisterVetDoctor([FromBody] RegisterRequest model)
    {
        var response = _authenticateService.RegisterVetDoctorAsync(model);

        return Created("af", model);
    }
}
