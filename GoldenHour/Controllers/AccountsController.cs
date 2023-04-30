using GoldenHour.Domain;
using GoldenHour.DTO.Accounts;
using GoldenHour.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GoldenHour.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ServiceMan> _userManager;
        private readonly TokenService _tokenService;

        public AccountsController(UserManager<ServiceMan> userManager, 
            TokenService tokenService)
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<DTO.Users.ServiceMan>> GetCurrentUser()
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.Name));
            var role = (await _userManager.GetRolesAsync(user!)).First();

            return user != null ? 
                Ok(new LoginResponse { UserId = user.Id, UserName = user.UserName, Role = role }) 
                : Unauthorized();
        }


        private async Task<LoginResponse> CreateUserObject(ServiceMan user)
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
