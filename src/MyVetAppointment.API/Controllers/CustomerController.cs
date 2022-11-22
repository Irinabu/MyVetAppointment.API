using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CustomerController : BaseController

    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpDelete("delete-customer")]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteRequest model)
        {
            return Ok(_customerService.DeleteCustomer(model.id));
        }
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_customerService.GetAllCustomersAsync());

        }
        [HttpPut("update-customer")]
        public async Task<IActionResult> UpdateCustomers([FromBody] UpdateRequest model)
        {
            return Ok();
        }

    }
}
