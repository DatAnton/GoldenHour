using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class IncidentsRepository : BaseRepository<Incident>, IIncidentsRepository
    {
        public IncidentsRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<Incident> GetFullIncidentById(Guid guid)
        {
            return await _dataContext.Incidents.Include(i => i.Medic)
                .Include(i => i.ServiceMan.BloodGroup).Include(i => i.ServiceMan.Brigade)
                .Include(i => i.HelpPhotos).FirstAsync(i => i.Id == guid);
        }
    }
}
