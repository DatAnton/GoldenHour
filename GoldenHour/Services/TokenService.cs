using GoldenHour.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenHour.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ServiceMan> _userManager;

        public TokenService(IConfiguration config, 
            UserManager<ServiceMan> userManager)
        {
            _config = config;
            _userManager = userManager;
        }


        public async Task<string> GenerateToken(ServiceMan user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var tokenClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("email_confirmed", user.EmailConfirmed.ToString())
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
    }
}
