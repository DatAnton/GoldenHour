using GoldenHour.Domain;
using GoldenHour.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace GoldenHour.Application.Core
{
    public class CsvService
    {
        private readonly IBrigadesRepository _brigadesRepository;
        private readonly IBloodGroupsRepository _bloodGroupsRepository;

        public CsvService(IBrigadesRepository brigadesRepository, 
            IBloodGroupsRepository bloodGroupsRepository)
        {
            _brigadesRepository = brigadesRepository;
            _bloodGroupsRepository = bloodGroupsRepository;
        }

        public async Task<List<ServiceMan>> ReadCsv(IFormFile file)
        {
            var result = new List<ServiceMan>();
            using (var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            {
                string row;
                while ((row = reader.ReadLine()) != null)
                {
                    var rowParts = row.Split(',');
                    var bloodGroup = await _bloodGroupsRepository.GetBySequenceNumber(Convert.ToInt32(rowParts[2]));
                    var brigade = await _brigadesRepository.GetByShortName(rowParts[3]);
                    var model = new ServiceMan()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = rowParts[0],
                        Email = rowParts[1],
                        FullName = rowParts[4],
                        NickName = rowParts[5],
                        BloodGroupId = bloodGroup.Id,
                        BrigadeId = brigade.Id,
                        EmailConfirmed = true
                    };

                    result.Add(model);
                }
            }

            return result;
        }
    }
}
