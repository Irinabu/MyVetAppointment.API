using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Validators;

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
        BillValidator validator = new BillValidator();
        var validationResult = validator.Validate(model);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var response = await _billService.AddBillAsync(model, idAppointment);
        return Created("af", response);
    }
}