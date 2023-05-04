using GoldenHour.Application.Users;
using GoldenHour.DTO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldenHour.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Create(ServiceMan user)
        {
            return Ok(await Mediator.Send(new Create.Command { User = user }));
        }

        [HttpPut]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Update(ServiceMan user)
        {
            return Ok(await Mediator.Send(new Update.Command { User = user }));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.ADMIN_ROLE)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpGet("generateQr")]
        public async Task<IActionResult> GenerateQrCode()
        {
            return File(await Mediator.Send(new GenerateQRCode.Query 
                { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier), 
                    UserName = User.FindFirstValue(ClaimTypes.Name) }), "image/png");
        }

        [HttpGet("getInfo")]
        public async Task<IActionResult> GetInfo()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            return !string.IsNullOrEmpty(userName) ? Ok(await Mediator.Send(new Details.Query
                { UserName = userName })) : Unauthorized();
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordData changePassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok(await Mediator.Send
                (new ChangePassword.Command { UserId = userId, Data = changePassword }));
        }
    }
}
