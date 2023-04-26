using GoldenHour.Application.Users;
using GoldenHour.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldenHour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly UserManager<ServiceMan> _userManager;

        public UsersController(UserManager<ServiceMan> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Users");
        }

        [HttpGet("generateQr")]
        public async Task<IActionResult> GenerateQrCode()
        {
            return File(await Mediator.Send(new GenerateQRCode.Query 
                { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) }), "image/png");
        }
    }
}
