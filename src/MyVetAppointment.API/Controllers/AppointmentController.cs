using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Validators;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var user = HttpContext.Items["User"] as User;
        if(user != null)
        {
            var response = await _appointmentService.GetUserAppointments(user);
            return Ok(response);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment([FromBody] AppointmentRequest model)
    {
        AppointmentValidator validator = new AppointmentValidator();
        var validationResult = validator.Validate(model);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var user = HttpContext.Items["User"] as User;
        if (user != null)
        {
            var response = await _appointmentService.AddAppointment(model, user);
            return Created("af", response);
        }
        return NotFound();
    }

    [HttpPost("update-appointment")]
    public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentRequest model, [FromQuery]string id)
    {
        AppointmentValidator validator = new AppointmentValidator();
        var validationResult = validator.Validate(model);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var _id = Guid.Parse(id);
        var user = HttpContext.Items["User"] as User;
        if (user != null)
        {
            var response = await _appointmentService.UpdateAppointment(model, _id, user);
            return Ok(response);
        }
        return NotFound();  
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        await _appointmentService.DeleteAppointment(id);
        return NoContent();
    }

}