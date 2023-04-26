using CommunityToolkit.Maui.Views;
using Plugin.Maui.ScreenBrightness;

namespace GoldenHour.Maui.Pages;

public partial class QrPopupPage : Popup
{
    private float currentBrightness;
    public QrPopupPage(string qrCodePath)
	{
		InitializeComponent();
        QrImage.Source = qrCodePath;
        currentBrightness = ScreenBrightness.Default.Brightness;
        ScreenBrightness.Default.Brightness = 1;
    }

    private void CloseBtn_Clicked(object sender, EventArgs e)
    {
        ScreenBrightness.Default.Brightness = currentBrightness;
        Close();
    }
}