using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace GoldenHour.Maui.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly UserInfoHelper _userInfoHelper;
        private readonly TabsBuilder _tabsBuilder;

        public LoginPageViewModel(IAccountService accountService,
            IUserService userService,
            UserInfoHelper userInfoHelper,
            TabsBuilder tabsBuilder)
        {
            _accountService = accountService;
            _userService = userService;
            _userInfoHelper = userInfoHelper;
            _tabsBuilder = tabsBuilder;
        }

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                await DisplayLoginMessage("Invalid username or password");
                Password = string.Empty;
            }
            else
            {
                IsLoading = true;
                var loginModel = new LoginRequestModel
                {
                    UserName = UserName,
                    Password = Password
                };

                var response = await _accountService.Login(loginModel);

                if (response != null && !string.IsNullOrEmpty(response?.Token))
                {
                    await SecureStorage.SetAsync(Constants.TOKEN_KEY_SECURE_STORAGE, response.Token);
                    await SecureStorage.SetAsync(Constants.REFRESH_TOKEN_KEY_SECURE_STORAGE, response.RefreshToken);

                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;
                    _userInfoHelper.FillUserInfo(jsonToken);

                    _userInfoHelper.SaveUser(await _userService.GetInfoAsync());

                    _tabsBuilder.BuildNavTabs();
                    UserName = string.Empty;
                    Password = string.Empty;
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
                else
                {
                    await DisplayLoginMessage("Invalid username or password");
                }
                IsLoading = false;
            }
        }

        async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login attempt result", message, "Ok");
            Password = string.Empty;
        }
    }
}
