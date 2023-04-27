using CommunityToolkit.Maui.Views;
using Plugin.Maui.ScreenBrightness;

namespace GoldenHour.Maui.Pages;

public partial class QrPopup : Popup
{
    private float currentBrightness;
    public QrPopup(string qrCodePath)
	{
		InitializeComponent();
        QrImage.Source = qrCodePath;
        QrImage.IsVisible = true;
        currentBrightness = ScreenBrightness.Default.Brightness;
        ScreenBrightness.Default.Brightness = 1;
    }

    private void CloseBtn_Clicked(object sender, EventArgs e)
    {
        ScreenBrightness.Default.Brightness = currentBrightness;
        Close();
    }
}