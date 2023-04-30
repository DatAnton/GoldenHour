using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<ServiceMan>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<ServiceMan> GetFullServiceMan(string userName)
        {
            return await _dataContext.Users.Include(u => u.BloodGroup).Include(u => u.Brigade)
                .FirstAsync(u => u.UserName == userName);
        }
    }
}
