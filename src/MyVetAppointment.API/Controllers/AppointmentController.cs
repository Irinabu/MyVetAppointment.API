using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Services;
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
        var response = await _appointmentService.GetUserAppointments(user);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAppointment([FromBody] AppointmentRequest model)
    {
        var user = HttpContext.Items["User"] as User;
        var response = await _appointmentService.AddAppointment(model, user);
        return Created("af", response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentRequest model, Guid id)
    {
        var user = HttpContext.Items["User"] as User;
        var response = await _appointmentService.UpdateAppointment(model, id, user);
        return Ok(response);
    }
}