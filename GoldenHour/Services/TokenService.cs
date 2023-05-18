using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GoldenHour.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ServiceMan> _userManager;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

        public TokenService(IConfiguration config, 
            UserManager<ServiceMan> userManager,
            IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _config = config;
            _userManager = userManager;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }


        public async Task<string> GenerateToken(ServiceMan user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var tokenClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            }
            .Union(claims)
            .Union(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var securityToken = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: tokenClaims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["JwtSettings:DurationInMin"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<string> GenerateRefreshToken(string userId)
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var refreshToken =  Convert.ToBase64String(randomNumber);

            await _userRefreshTokenRepository.SetRefreshToken(userId, refreshToken, 
                DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["JwtSettings:RefreshDurationInMin"])));

            return refreshToken;
        }

        public string? GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var userId = tokenHandler.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            return userId?.Value;

        }
    }
}
