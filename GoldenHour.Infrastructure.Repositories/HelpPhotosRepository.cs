using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using GoldenHour.Persistance;

namespace GoldenHour.Infrastructure.Repositories
{
    public class HelpPhotosRepository : BaseRepository<HelpPhoto>, IHelpPhotosRepository
    {
        public HelpPhotosRepository(DataContext dataContext) : base(dataContext) { }

        public async Task SavePhotoRange(List<HelpPhoto> helpPhotos)
        {
            await _dataContext.HelpPhotos.AddRangeAsync(helpPhotos);     
            await _dataContext.SaveChangesAsync();
        }
    }
}
