using AutoMapper;
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
            private readonly IMapper _mapper;

            public Handler(IIncidentsRepository incidentsRepository, IMapper mapper)
            {
                _incidentsRepository = incidentsRepository;
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
                    dto.Images = incident.HelpPhotos.Select(p => p.Id).ToList();
                    resultDTOs.Add(dto);
                }

                return resultDTOs;
            }
        }
    }
}
