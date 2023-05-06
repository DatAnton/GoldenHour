namespace GoldenHour.Domain.Services
{
    public interface IBrigadesRepository : IBaseRepository<Brigade>
    {
        Task<Brigade?> GetByShortName(string shortName);
    }
}
