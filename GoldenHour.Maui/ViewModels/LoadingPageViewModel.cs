using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace GoldenHour.Maui.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        private readonly UserInfoHelper _userInfoHelper;
        private readonly TabsBuilder _tabsBuilder;
        private readonly IAccountService _accountService;

        public LoadingPageViewModel(UserInfoHelper userInfoHelper, TabsBuilder tabsBuilder, IAccountService accountService)
        {
            _userInfoHelper = userInfoHelper;
            _tabsBuilder = tabsBuilder;
            _accountService = accountService;
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
                    var refreshToken = await SecureStorage.GetAsync(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE);
                    var result = await _accountService.Refresh(token, refreshToken);
                    if(result != null)
                    {
                        await SecureStorage.SetAsync(Constants.TOKEN_KEY_SECURE_STORAGE, result.Token);
                        await SecureStorage.SetAsync(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE, result.RefreshToken);

                        var refreshedJsonToken = new JwtSecurityTokenHandler().ReadToken(result.Token) as JwtSecurityToken;
                        _userInfoHelper.FillUserInfo(refreshedJsonToken);

                        _tabsBuilder.BuildNavTabs();
                        await GoToMainPage();
                    }
                    else
                    {
                        SecureStorage.Remove(Constants.TOKEN_KEY_SECURE_STORAGE);
                        SecureStorage.Remove(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE);
                        await GoToLoginPage();
                    }
                }
                else
                {
                    _userInfoHelper.FillUserInfo(jsonToken);

                    _tabsBuilder.BuildNavTabs();
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
