using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Pages;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
            _mainPageViewModel = mainPageViewModel;
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
    }
}