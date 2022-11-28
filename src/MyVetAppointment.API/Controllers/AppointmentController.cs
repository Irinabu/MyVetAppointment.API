using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Controllers
{
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

        [HttpPost("appointment")]
        public async Task<IActionResult> GetAppointments()
        {
            var user = HttpContext.Items["User"] as User;
            var response = await _appointmentService.GetUserAppointments(user);

            return Ok(response);
        }
    }
}