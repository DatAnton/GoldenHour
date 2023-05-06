using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BloodGroupsRepository : BaseRepository<BloodGroup>, IBloodGroupsRepository
    {
        public BloodGroupsRepository(DataContext dataContext) : base(dataContext) { }

        public Task<BloodGroup?> GetBySequenceNumber(int sequenceNumber)
        {
            return _dataContext.BloodGroups.FirstOrDefaultAsync(bg => bg.SequenceNumber == sequenceNumber);
        }
    }
}
