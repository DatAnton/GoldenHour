using GoldenHour.Application.Brigades;
using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    public class BrigadesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }
    }
}
