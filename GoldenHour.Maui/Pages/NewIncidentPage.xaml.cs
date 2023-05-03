using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Models;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui.Pages;

public partial class NewIncidentPage : ContentPage
{
    private readonly NewIncidentPageViewModel _viewModel;
    private readonly UserInfoHelper _userInfoHelper;

    public NewIncidentPage(NewIncidentPageViewModel viewModel,
        UserInfoHelper userInfoHelper)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;
        _userInfoHelper = userInfoHelper;
    }

    private async void QrCodeScanner_Clicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new QrCodeScannerPopup(_userInfoHelper));
        if(result != null)
        {
            var scannerResult = (ScannerResult)result;
            await Shell.Current.DisplayAlert("Info", $"Detected succesfully \"{scannerResult.NickName}\"", "Ok");
            _viewModel.SetQrCodeResult(scannerResult);
            _viewModel.SetCurrentDateTime();
            await _viewModel.SetCurrentLocation();
        }
    }

    private async void BinBtn_Clicked(object sender, EventArgs e)
    {
        var currentItem = (Photo)Carousel.CurrentItem;
        if(currentItem != null)
            await _viewModel.RemovePhoto(currentItem);
    }
}