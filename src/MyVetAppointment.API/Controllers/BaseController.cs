using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyVetAppointment.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
    }
}