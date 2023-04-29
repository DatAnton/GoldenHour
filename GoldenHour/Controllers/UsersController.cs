using GoldenHour.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldenHour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        public UsersController()
        {
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("generateQr")]
        public async Task<IActionResult> GenerateQrCode()
        {
            return File(await Mediator.Send(new GenerateQRCode.Query 
                { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) }), "image/png");
        }
    }
}
