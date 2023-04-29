using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BrigadesRepository : BaseRepository<Brigade>, IBrigadesRepository
    {
        public BrigadesRepository(DataContext dataContext) : base(dataContext) { }

    }
}
