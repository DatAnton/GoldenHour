using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Helpers;
using GoldenHour.Maui.Models;
using ZXing.Net.Maui;

namespace GoldenHour.Maui.Pages;

public partial class QrCodeScannerPopup : Popup
{
    private readonly UserInfoHelper _userInfoHelper;

    public QrCodeScannerPopup(UserInfoHelper userInfoHelper)
	{
		InitializeComponent();
        BarcodeReader.IsDetecting = true;
        BarcodeReader.Options = new BarcodeReaderOptions
        {
            TryHarder = true,
            AutoRotate = true
        };
        _userInfoHelper = userInfoHelper;
    }

    private void BarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        BarcodeReader.IsDetecting = false;
        BarcodeReader.IsEnabled = false;
        var result = new ScannerResult();
        if(!string.IsNullOrEmpty(e.Results[0].Value) && e.Results[0].Value.Contains("|"))
        {
            var parts = e.Results[0].Value.Split("|");
            result.UserId = parts[0];
            result.NickName = parts[1];
        }    
        Close(result);
    }

    private void CloseBtn_Clicked(object sender, EventArgs e)
    {
        Close(null);
    }

    private void MeBtm_Clicked(object sender, EventArgs e)
    {
        BarcodeReader.IsDetecting = false;
        BarcodeReader.IsEnabled = false;
        var user = _userInfoHelper.GetUser();
        var result = new ScannerResult
        {
            UserId = App.UserInfo.UserId,
            NickName =user.NickName
        };
        Close(result);
    }
}