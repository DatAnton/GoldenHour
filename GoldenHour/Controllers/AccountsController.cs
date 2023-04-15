using GoldenHour.DTO.Accounts;
using GoldenHour.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public AccountsController(UserManager<IdentityUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(Login login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null) 
                return Unauthorized();

            var isValidPassword = await _userManager.CheckPasswordAsync(user, login.Password);

            return isValidPassword ? Ok(await CreateUserObject(user)) : Unauthorized();
        }

        private async Task<LoginResponse> CreateUserObject(IdentityUser user)
        {
            return new LoginResponse
            {
                Token = await _tokenService.GenerateToken(user),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

    }
}
