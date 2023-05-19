using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.DTO.Accounts;
using GoldenHour.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GoldenHour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ServiceMan> _userManager;
        private readonly TokenService _tokenService;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

        public AccountsController(UserManager<ServiceMan> userManager, 
            TokenService tokenService,
            IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(Login login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null) 
                return Unauthorized();

            var isValidPassword = await _userManager.CheckPasswordAsync(user, login.Password);

            return isValidPassword ? Ok(await CreateTokensObject(user)) : Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ActionResult<LoginResponse>> Refresh(Refresh refresh)
        {
            var userId = _tokenService.GetUserIdFromToken(refresh.AccessToken);
            if(!string.IsNullOrEmpty(userId))
            {
                var userRefreshTokenObject = await _userRefreshTokenRepository.GetRefreshTokenByUserId(userId);
                if(userRefreshTokenObject!.RefreshToken == refresh.RefreshToken && userRefreshTokenObject.Expire > DateTime.UtcNow)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    return Ok(await CreateTokensObject(user));
                }
            }
            throw new Exception("Invalid refresh token");    
        }

        [HttpGet]
        public async Task<ActionResult<LoginResponse>> GetCurrentUser()
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.Name));
            var role = (await _userManager.GetRolesAsync(user!)).First();

            return user != null ? 
                Ok(new LoginResponse { UserId = user.Id, UserName = user.UserName, Role = role }) 
                : Unauthorized();
        }


        private async Task<LoginResponse> CreateTokensObject(ServiceMan user)
        {
            var refreshToken = await _tokenService.GenerateRefreshToken(user.Id);
            var role = (await _userManager.GetRolesAsync(user!)).First();
            return new LoginResponse
            {
                Token = await _tokenService.GenerateToken(user),
                UserId = user.Id,
                UserName = user.UserName,
                RefreshToken = refreshToken,
                Role = role
            };
        }

    }
}
