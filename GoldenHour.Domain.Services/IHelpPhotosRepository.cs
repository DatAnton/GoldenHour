using Microsoft.AspNetCore.Http;

namespace GoldenHour.Domain.Services
{
    public interface IHelpPhotosRepository : IBaseRepository<HelpPhoto>
    {
        Task SavePhotoRange(List<HelpPhoto> helpPhotos);
    }
}
