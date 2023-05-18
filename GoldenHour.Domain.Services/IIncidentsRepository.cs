namespace GoldenHour.Domain.Services
{
    public interface IIncidentsRepository : IBaseRepository<Incident>
    {
        Task<Incident> GetFullIncidentById(Guid guid);
    }
}
