namespace GoldenHour.Domain.Services
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task Create(T entity);
    }
}
