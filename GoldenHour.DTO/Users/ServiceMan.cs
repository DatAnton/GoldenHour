namespace GoldenHour.DTO.Users
{
    public class ServiceMan
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public Guid BloodGroupId { get; set; }
        public string BloodGroupName { get; set; }
        public Guid BrigadeId { get; set; }
        public string BrigadeName { get; set; }
        public string Roles { get; set; }
    }
}
