using GoldenHour.Application.Incidents;
using GoldenHour.DTO.Incidents;
using GoldenHour.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GoldenHour.Controllers
{
    public class IncidentsController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHubContext<IncidentsHub> _hubContext;

        public IncidentsController(IWebHostEnvironment webHostEnvironment, IHubContext<IncidentsHub> hubContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        [Authorize(Roles = Constants.MEDIC_ROLE)]
        public async Task<IActionResult> Create([FromForm]IncidentCreate incident)
        {
            var result = await Mediator.Send(new Create.Command 
                { Incident = incident, WebRootPath = _webHostEnvironment.WebRootPath });

            await _hubContext.Clients.All.SendAsync("ReceivedIncident", result);
            return Ok();
        }
    }
}
