using GoldenHour.Maui.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace GoldenHour.Maui.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        private readonly TokenHandlerHelper _tokenHandlerHelper;

        public LoadingPageViewModel(TokenHandlerHelper tokenHandlerHelper)
        {
            _tokenHandlerHelper = tokenHandlerHelper;
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
            var token = await SecureStorage.GetAsync(Constants.TOKEN_KEY_SECURE_STORAGE);
            
            if (string.IsNullOrEmpty(token))
            {
                await GoToLoginPage();
            }
            else
            {
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove(Constants.TOKEN_KEY_SECURE_STORAGE);
                    await GoToLoginPage();
                }
                else
                {
                    _tokenHandlerHelper.FillUserInfo(jsonToken);

                    //MenuBuilder.BuildMenu();
                    await GoToMainPage();
                }
            }
        }

        private async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
        }

        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}", true);
        }
    }
}
