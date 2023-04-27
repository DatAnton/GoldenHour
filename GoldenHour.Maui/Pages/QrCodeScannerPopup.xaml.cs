using CommunityToolkit.Maui.Views;
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
        Close(e.Results[0].Value);
    }
}