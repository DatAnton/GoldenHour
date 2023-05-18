namespace GoldenHour.Domain
{
    public class UserRefreshToken
    {
        public Guid Id { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expire { get; set; }
        public string ServiceManId { get; set; }
        public ServiceMan ServiceMan { get; set; }
    }
}
