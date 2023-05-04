using AutoMapper;
using GoldenHour.Application.Core;
using GoldenHour.Domain.Services;
using GoldenHour.DTO.Incidents;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoldenHour.Application.Incidents
{
    public class Create
    {
        public class Command : IRequest
        {
            public Incident Incident { get; set; }
            public string WebRootPath { get;set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IIncidentsRepository _incidentsRepository;
            private readonly IHelpPhotosRepository _helpPhotosRepository;
            private readonly FileHelper _fileHelper;
            private readonly IMapper _mapper;

            public Handler(IIncidentsRepository incidentsRepository, 
                IHelpPhotosRepository helpPhotosRepository,
                FileHelper fileHelper,
                IMapper mapper)
            {
                _incidentsRepository = incidentsRepository;
                _helpPhotosRepository = helpPhotosRepository;
                _fileHelper = fileHelper;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var incident = _mapper.Map<Domain.Incident>(request.Incident);
                incident.Id = Guid.NewGuid();

                await _incidentsRepository.Create(incident);

                var createdFiles = await _fileHelper.SaveFiles(request.WebRootPath, 
                    request.Incident.Files, incident.Id);

                await _helpPhotosRepository.SavePhotoRange(
                    createdFiles.Select(file => new Domain.HelpPhoto
                        {
                            Id = Guid.NewGuid(),
                            IncidentId = incident.Id,
                            Path = file
                        })
                    .ToList());
                    

                return Unit.Value;
            }
        }
    }
}
