using GoldenHour.Application.Core;
using GoldenHour.Domain.Services;
using MediatR;

namespace GoldenHour.Application.Incidents
{
    public class PhotoDetail
    {
        public class Query : IRequest<byte[]>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, byte[]>
        {
            private readonly IHelpPhotosRepository _helpPhotosRepository;
            private readonly FileHelper _fileHelper;

            public Handler(IHelpPhotosRepository helpPhotosRepository, 
                FileHelper fileHelper)
            {
                _helpPhotosRepository = helpPhotosRepository;
                _fileHelper = fileHelper;
            }

            public async Task<byte[]> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _fileHelper.GetPhoto(await _helpPhotosRepository.GetPathById(request.Id));
            }
        }
    }
}
