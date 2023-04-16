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
        private readonly TokenHandlerHelper _tokenHandlerHelper;

        public LoginPageViewModel(IAccountService accountService,
            TokenHandlerHelper tokenHandlerHelper)
        {
            _accountService = accountService;
            _tokenHandlerHelper = tokenHandlerHelper;
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
                var loginModel = new LoginRequestModel
                {
                    UserName = UserName,
                    Password = Password
                };

                var response = await _accountService.Login(loginModel);

                if (response != null && !string.IsNullOrEmpty(response?.Token))
                {
                    await SecureStorage.SetAsync(Constants.TOKEN_KEY_SECURE_STORAGE, response.Token);

                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;
                    _tokenHandlerHelper.FillUserInfo(jsonToken);

                    //MenuBuilder.BuildMenu();
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                }
                else
                {
                    await DisplayLoginMessage("Invalid username or password");
                }
            }
        }

        async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login attempt result", message, "Ok");
            Password = string.Empty;
        }
    }
}
