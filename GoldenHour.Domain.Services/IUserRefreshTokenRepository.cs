namespace GoldenHour.Domain.Services
{
    public interface IUserRefreshTokenRepository : IBaseRepository<UserRefreshToken>
    {
        Task<UserRefreshToken?> GetRefreshTokenByUserId(string userId);
        Task SetRefreshToken(string userId, string refreshToken, DateTime expire);
    }
}
