using GoldenHour.Application.Incidents;
using GoldenHour.DTO.Incidents;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{photoId}")]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> GetImage(Guid photoId)
        {
            return File(await Mediator.Send(new PhotoDetail.Query { Id = photoId }), "image/jpeg");
        }

        [HttpPost]
        [Authorize(Roles = Constants.MEDIC_ROLE)]
        public async Task<IActionResult> Create([FromForm]IncidentCreate incident)
        {
            return Ok(await Mediator.Send(new Create.Command 
                { Incident = incident, WebRootPath = _webHostEnvironment.WebRootPath }));
        }
    }
}
