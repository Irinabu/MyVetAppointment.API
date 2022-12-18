using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;

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
            return await Task.Run(() => Ok(_vetDoctorService.DeleteVetDoctor(id)));
        }

        [HttpGet("vets")]
        public async Task<IActionResult> GetVets()
        {
            return await Task.Run(() => Ok(_vetDoctorService.GetAllAsync()));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetVetByEmail(string email)
        {
            return await Task.Run(() => Ok(_vetDoctorService.GetVetDoctorByEmailAsync(email)));
        }

    }
}