using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BloodGroupsRepository : BaseRepository<BloodGroup>, IBloodGroupsRepository
    {
        public BloodGroupsRepository(DataContext dataContext) : base(dataContext) { }
    }
}
