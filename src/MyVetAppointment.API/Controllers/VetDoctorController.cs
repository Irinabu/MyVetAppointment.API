using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class VetDoctorController : BaseController
    {
        private readonly IVetDoctorService _vetDoctorService;

        public VetDoctorController(IVetDoctorService vetDoctorService)
        {
            _vetDoctorService = vetDoctorService;
        }

        [HttpDelete("delete-vet/{id}")]
        public async Task<IActionResult> DeleteVet(string id)
        {
            return Ok(_vetDoctorService.DeleteVetDoctor(id));
        }
        [HttpGet("vets")]
        public async Task<IActionResult> GetVets()
        {
            return Ok(_vetDoctorService.GetAllAsync());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetVetByEmail(string email)
        {
            return Ok(_vetDoctorService.GetVetDoctorByEmailAsync(email));
        }

        /*
        [HttpPut("update-vet/{id}")]
        public async Task<IActionResult> UpdateVet(string id, [FromBody] UpdateRequest model)
        {
            return Ok(_vetDoctorService.UpdateVetDoctorAsync(id,model));
        }
        */
    }
}
