using GoldenHour.Domain.Services;
using GoldenHour.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }
    }
}
