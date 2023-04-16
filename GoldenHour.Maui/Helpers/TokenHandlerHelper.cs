using GoldenHour.Maui.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GoldenHour.Maui.Helpers
{
    public class TokenHandlerHelper
    {
        public void FillUserInfo(JwtSecurityToken token)
        {
            var name = token.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))?.Value;
            var role = token.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role))?.Value;
            var userId = token.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Sub))?.Value;

            App.UserInfo = new UserInfo
            {
                UserName = name,
                Role = role,
                UserId = userId
            };
        }
    }
}
