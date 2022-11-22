using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class VetDoctorController : BaseController
    {
        private readonly IVetDoctorService _vetDoctorService;

        public VetDoctorController(IVetDoctorService vetDoctorService)
        {
            _vetDoctorService= vetDoctorService;
        }

        [HttpDelete("delete-vet")]
        public async Task<IActionResult> DeleteVet([FromBody] DeleteRequest model)
        {
            return Ok(_vetDoctorService.DeleteVetDoctor(model.id));

        }
        [HttpGet("vets")]
        public async Task<IActionResult> GetVets()
        {
            return Ok(_vetDoctorService.GetAllVetDoctorsAsync());

        }
        [HttpPut("update-vet")]
        public async Task<IActionResult> UpdateVet([FromBody] UpdateRequest model)
        {
            return Ok();
        }

    }
}
