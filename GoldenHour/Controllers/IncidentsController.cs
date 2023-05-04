using GoldenHour.Application.Incidents;
using GoldenHour.DTO.Incidents;
using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    public class IncidentsController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IncidentsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Incident incident)
        {
            return Ok(await Mediator.Send(new Create.Command 
                { Incident = incident, WebRootPath = _webHostEnvironment.WebRootPath }));
        }
    }
}
