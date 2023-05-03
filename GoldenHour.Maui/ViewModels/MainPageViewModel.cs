using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldenHour.Maui.DTO;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;

namespace GoldenHour.Maui.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly UserInfoHelper _userInfoHelper;
        private readonly QRCodeHelper _qrCodeHelper;
        private readonly IUserService _userService;

        private readonly NetworkAccess _accessType = Connectivity.Current.NetworkAccess;

        public MainPageViewModel(UserInfoHelper userInfoHelper, 
            QRCodeHelper qrCodeHelper, 
            IUserService userService)
        {
            _userInfoHelper = userInfoHelper;
            _qrCodeHelper = qrCodeHelper;
            _userService = userService;
        }

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string nickName;

        [ObservableProperty]
        string bloodGroupName;

        [ObservableProperty]
        string brigade;

        [ObservableProperty]
        string role;

        [RelayCommand]
        async Task Logout()
        {
            if(await Shell.Current.DisplayAlert
                ("Confirmation", "Are you sure you want to log out?", "Yes", "No"))
            {
                CleanAuthData();
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        public void CleanAuthData()
        {
            SecureStorage.Remove(Constants.TOKEN_KEY_SECURE_STORAGE);
            _userInfoHelper.CleanUserInfo();
            _userInfoHelper.RemoveUserFromStore();
            TabsBuilder.BuildNavTabs();
        }

        [RelayCommand]
        async Task UpdateInfo()
        {
            IsLoading = true;
            _userInfoHelper.SaveUser(await _userService.GetInfoAsync());
            await PrepareUserInfo();
            IsLoading = false;
        }

        public async Task PrepareUserInfo()
        {
            if (!File.Exists(QRCodeHelper.QrCodePath))
            {
                var qrCode = await _userService.GetImageAsync();

                _qrCodeHelper.SaveQr(qrCode);
            }

            var user = _userInfoHelper.GetUser() ?? new ServiceMan();

            UserName = user.UserName;
            NickName = user.NickName;
            BloodGroupName = user.BloodGroupName;
            Brigade = user.BrigadeShortName;
            Role = App.UserInfo.Role;
        }
    }
}
