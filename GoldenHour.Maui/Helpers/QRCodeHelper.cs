namespace GoldenHour.Maui.Helpers
{
    public class QRCodeHelper
    {
        public static string QrCodePath => 
            Path.Combine(FileSystem.AppDataDirectory, 
                string.Format(Constants.QR_CODE_NAME, App.UserInfo.UserId));

        public void SaveQr(byte[] qrCode)
        {
            File.WriteAllBytes(QrCodePath, qrCode);
        }
    }
}
