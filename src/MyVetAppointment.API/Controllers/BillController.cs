using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpPost("{idAppointment}")]
    public async Task<IActionResult> AddAppointment([FromBody] BillRequest model, Guid idAppointment)
    {
        var response = await _billService.AddBillAsync(model, idAppointment);
        return Created("af", response);
    }
}