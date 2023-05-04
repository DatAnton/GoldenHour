using GoldenHour.Domain.Services;
using GoldenHour.Persistance;

namespace GoldenHour.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }
    }
}
