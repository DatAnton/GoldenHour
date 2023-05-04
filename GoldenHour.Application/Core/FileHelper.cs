using Microsoft.AspNetCore.Http;

namespace GoldenHour.Application.Core
{
    public class FileHelper
    {
        private const string PHOTO_FOLDER = "Incidents";
        private string GetPhotoRoute(string webRootPath) => Path.Combine(webRootPath, PHOTO_FOLDER);

        public async Task<List<string>> SaveFiles(string webRootPath, List<IFormFile> files, Guid incedentId)
        {
            string route = Path.Combine(GetPhotoRoute(webRootPath), incedentId.ToString());

            if (!Directory.Exists(route))
            {
                Directory.CreateDirectory(route);
            }

            var result = new List<string>();

            foreach (IFormFile file in files)
            {
                string fileRoute = Path.Combine(route, file.FileName);
                result.Add(fileRoute);
                using (var fileStream = File.Create(fileRoute))
                {
                    await file.OpenReadStream().CopyToAsync(fileStream);
                }
            }

            return result;
        }

        public async Task<byte[]> GetPhoto(string path)
        {
            return await File.ReadAllBytesAsync(path);
        }
    }
}
