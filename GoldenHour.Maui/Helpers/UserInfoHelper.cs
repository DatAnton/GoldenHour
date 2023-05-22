using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GoldenHour.Maui.Helpers
{
    public class UserInfoHelper
    {
        public void FillUserInfo(JwtSecurityToken token)
        {
            var name = token.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))?.Value;
            var role = token.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role))?.Value;
            var userId = token.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            App.UserInfo = new UserInfo
            {
                UserName = name,
                Role = role,
                UserId = userId
            };
        }

        public void CleanUserInfo()
        {
            if (App.UserInfo == null) return;
            File.Delete(QRCodeHelper.QrCodePath);
            App.UserInfo = null;
        }

        public void SaveUser(ServiceMan serviceMan)
        {
            var json = JsonConvert.SerializeObject(serviceMan);
            Preferences.Set(Constants.USER_PREFERENCES_KEY, json);
        }

        public void RemoveUserFromStore()
        {
            Preferences.Remove(Constants.USER_PREFERENCES_KEY);
        }

        public ServiceMan GetUser()
        {
            if(Preferences.ContainsKey(Constants.USER_PREFERENCES_KEY))
            {
                var json = Preferences.Get(Constants.USER_PREFERENCES_KEY, string.Empty);
                return JsonConvert.DeserializeObject<ServiceMan>(json);
            }
            return null;
        }
    }
}
