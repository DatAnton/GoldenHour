using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository : BaseRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<UserRefreshToken?> GetRefreshTokenByUserId(string userId)
        {
            return await _dataContext.UserRefreshTokens.FirstOrDefaultAsync(u => u.ServiceManId == userId);
        }

        public async Task SetRefreshToken(string userId, string refreshToken, DateTime expire)
        {
            var existedObject = await GetRefreshTokenByUserId(userId);
            if (existedObject != null)
            {
                existedObject.RefreshToken = refreshToken;
                existedObject.Expire = expire;
            }
            else
            {
                await _dataContext.UserRefreshTokens.AddAsync(new UserRefreshToken
                {
                    Id = Guid.NewGuid(),
                    RefreshToken = refreshToken,
                    Expire = expire,
                    ServiceManId = userId
                });
            }
            await _dataContext.SaveChangesAsync();
        }
    }
}
