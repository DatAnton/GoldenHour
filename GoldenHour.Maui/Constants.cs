namespace GoldenHour.Maui
{
    public static class Constants
    {
        public const string ANDROID_LOCALHOST = "http://10.0.2.2:8020";
        public const string LOCALHOST = "http://localhost:8020";
        public static string BASE_ADDRESS = DeviceInfo.Platform == DevicePlatform.Android ? ANDROID_LOCALHOST : LOCALHOST;

        public const string TOKEN_KEY_SECURE_STORAGE = "Token";
        public const string REFRESH_TOKEN_KEY_SECURE_STORAGE = "RefreshToken";
        public const string AUTH_HEADER_BEARER = "Bearer";

        public const string QR_CODE_NAME = "{0}_qrCode.png";

        public const string MEDIC_ROLE_NAME = "Medic";
        public const string USER_PREFERENCES_KEY = "User";

        public const int COORDINATES_ROUND_NUMBERS = 4;
    }
}
