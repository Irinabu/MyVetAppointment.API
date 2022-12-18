using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyVetAppointment.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
    }
}