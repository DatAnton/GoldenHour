using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Pages;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly ChangePasswordViewModel _popupViewModel;

        public MainPage(MainPageViewModel mainPageViewModel, 
            ChangePasswordViewModel popupViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
            _mainPageViewModel = mainPageViewModel;
            _popupViewModel = popupViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _mainPageViewModel.PrepareUserInfo();
        }

        private async void ShowQrBtn_Clicked(object sender, EventArgs e)
        {
            await this.ShowPopupAsync(new QrPopup(QRCodeHelper.QrCodePath));
        }

        private async void Setting_Clicked(object sender, EventArgs e)
        {
            var passwordIsChanged = await this.ShowPopupAsync(new ChangePasswordPopup(_popupViewModel));
            if((bool)passwordIsChanged)
            {
                _mainPageViewModel.CleanAuthData();
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }
    }
}