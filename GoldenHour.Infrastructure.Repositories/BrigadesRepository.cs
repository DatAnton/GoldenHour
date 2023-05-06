using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BrigadesRepository : BaseRepository<Brigade>, IBrigadesRepository
    {
        public BrigadesRepository(DataContext dataContext) : base(dataContext) { }

        public Task<Brigade?> GetByShortName(string shortName)
        {
            return _dataContext.Brigades.FirstOrDefaultAsync(x => x.ShortName == shortName);
        }
    }
}
