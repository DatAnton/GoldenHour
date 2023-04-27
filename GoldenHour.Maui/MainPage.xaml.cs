using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Interfaces;
using GoldenHour.Maui.Pages;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly QRCodeHelper _QRCodeHelper;
        private readonly IUserService _userService;

        public MainPage(MainPageViewModel mainPageViewModel, QRCodeHelper QRCodeHelper, IUserService userService)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
            _QRCodeHelper = QRCodeHelper;
            _userService = userService;
        }

        private async void ShowQrBtn_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(_QRCodeHelper.QrCodePath))
            {
                var qrCode = await _userService.GetImageAsync();

                _QRCodeHelper.SaveQr(qrCode);
            }
            await this.ShowPopupAsync(new QrPopup(_QRCodeHelper.QrCodePath));
        }

        private async void ScanQrBtn_Clicked(object sender, EventArgs e)
        {
            var resultUserId = await this.ShowPopupAsync(new QrCodeScannerPopup());
            await Shell.Current.DisplayAlert("Info", "Detected succesfully", "Ok");
            Dispatcher.Dispatch(() =>
            {
                UserIdLbl.Text = resultUserId.ToString();
            });
        }
    }
}