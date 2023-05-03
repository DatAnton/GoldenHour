using GoldenHour.Application.Roles;
using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    public class RolesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }
    }
}
