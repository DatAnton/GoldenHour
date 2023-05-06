using AutoMapper;
using GoldenHour.Application.Core;
using GoldenHour.Domain.Services;
using GoldenHour.DTO.Incidents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.Incidents
{
    public class List
    {
        public class Query : IRequest<List<Incident>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Incident>>
        {
            private readonly IIncidentsRepository _incidentsRepository;
            private readonly FileHelper _fileHelper;
            private readonly IMapper _mapper;

            public Handler(IIncidentsRepository incidentsRepository, FileHelper fileHelper, IMapper mapper)
            {
                _incidentsRepository = incidentsRepository;
                _fileHelper = fileHelper;
                _mapper = mapper;
            }
            public async Task<List<Incident>> Handle(Query request, CancellationToken cancellationToken)
            {
                var incidents = await _incidentsRepository.GetAll()
                    .Include(i => i.Medic).Include(i => i.ServiceMan.BloodGroup).Include(i => i.ServiceMan.Brigade)
                    .Include(i => i.HelpPhotos)
                    .ToListAsync();

                var resultDTOs = new List<Incident>();

                foreach (var incident in incidents)
                {
                    var dto = _mapper.Map<Incident>(incident);
                    dto.ServiceMan = _mapper.Map<DTO.Users.ServiceMan>(incident.ServiceMan);
                    dto.Images = new List<string>();
                    foreach(var photo in incident.HelpPhotos)
                    {
                        dto.Images.Add(await _fileHelper.GetPhoto(photo.Path));
                    }
                    resultDTOs.Add(dto);
                }

                return resultDTOs;
            }
        }
    }
}
