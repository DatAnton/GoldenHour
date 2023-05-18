namespace GoldenHour.DTO.Accounts
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
