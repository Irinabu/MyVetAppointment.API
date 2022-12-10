using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class DrugController : ControllerBase
{
    private readonly IDrugService _drugService;

    public DrugController(IDrugService drugService)
    {
        _drugService = drugService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrugs()
    {
        var response = await _drugService.GetAllDrugsAsync();
        if (response.Count == 0)
        {
            return NoContent();
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddDrug([FromBody] DrugRequest model)
    {
        var response = await _drugService.AddDrugAsync(model);
        return Created("af", response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrug(Guid id)
    {
        await _drugService.DeleteDrugAsync(id);
        return NoContent();
    }

}