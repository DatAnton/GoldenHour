using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Models;
using GoldenHour.Maui.ViewModels;

namespace GoldenHour.Maui.Pages;

public partial class NewIncidentPage : ContentPage
{
    private readonly NewIncidentPageViewModel _viewModel;

    public NewIncidentPage(NewIncidentPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private async void QrCodeScanner_Clicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new QrCodeScannerPopup());
        if(result is ScannerResult)
        {
            var scannerResult = (ScannerResult)result;
            await Shell.Current.DisplayAlert("Info", $"Detected succesfully \"{scannerResult.NickName}\"", "Ok");
            _viewModel.SetQrCodeResult(scannerResult);
        }
    }

    private async void BinBtn_Clicked(object sender, EventArgs e)
    {
        var currentItem = (Photo)Carousel.CurrentItem;
        if(currentItem != null)
            await _viewModel.RemovePhoto(currentItem);
    }
}