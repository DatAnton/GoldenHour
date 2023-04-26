namespace GoldenHour.Maui.Helpers
{
    public class QRCodeHelper
    {
        public string QrCodePath => 
            Path.Combine(FileSystem.AppDataDirectory, Constants.QR_CODE_NAME);

        public void SaveQr(byte[] qrCode)
        {
            File.WriteAllBytes(QrCodePath, qrCode);
        }
    }
}
