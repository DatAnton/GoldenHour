using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;

namespace GoldenHour.Infrastructure.Repositories
{
    public class IncidentsRepository : BaseRepository<Incident>, IIncidentsRepository
    {
        public IncidentsRepository(DataContext dataContext) : base(dataContext) { }
    }
}
