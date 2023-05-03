using CommunityToolkit.Maui.Views;
using GoldenHour.Maui.Models;
using ZXing.Net.Maui;

namespace GoldenHour.Maui.Pages;

public partial class QrCodeScannerPopup : Popup
{
	public QrCodeScannerPopup()
	{
		InitializeComponent();
        BarcodeReader.Options = new BarcodeReaderOptions
        {
            TryHarder = true,
            AutoRotate = true
        };
    }

    private void BarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        BarcodeReader.IsDetecting = false;
        var result = new ScannerResult();
        if(!string.IsNullOrEmpty(e.Results[0].Value) && e.Results[0].Value.Contains("|"))
        {
            var parts = e.Results[0].Value.Split("|");
            result.UserId = parts[0];
            result.NickName = parts[1];
        }    
        Close(result);
    }
}