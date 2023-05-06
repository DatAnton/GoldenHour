namespace GoldenHour.Domain.Services
{
    public interface IBloodGroupsRepository : IBaseRepository<BloodGroup>
    {
        Task<BloodGroup?> GetBySequenceNumber(int sequenceNumber);
    }
}
