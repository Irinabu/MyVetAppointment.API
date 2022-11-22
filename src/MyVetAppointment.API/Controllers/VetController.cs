using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;

namespace MyVetAppointment.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class VetController : ControllerBase
    {
        [HttpDelete("delete-vet")]
        public async Task<IActionResult> DeleteVet([FromBody] DeleteRequest model)
        {
            return Ok();

        }
        [HttpGet("vets")]
        public async Task<IActionResult> GetVets()
        {
            return Ok();

        }
        [HttpPut("update-vet")]
        public async Task<IActionResult> UpdateVet([FromBody] UpdateRequest model)
        {
            return Ok();
        }

    }
}
