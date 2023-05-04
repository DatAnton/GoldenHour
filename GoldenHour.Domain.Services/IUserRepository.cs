namespace GoldenHour.Domain.Services
{
    public interface IUserRepository
    {
        Task<ServiceMan> GetFullServiceManByUserName(string userName);
    }
}
