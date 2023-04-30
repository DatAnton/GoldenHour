namespace GoldenHour.Domain.Services
{
    public interface IUserRepository
    {
        Task<ServiceMan> GetFullServiceMan(string userName);
    }
}
