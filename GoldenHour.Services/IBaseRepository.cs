namespace GoldenHour.Domain.Services
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
    }
}
