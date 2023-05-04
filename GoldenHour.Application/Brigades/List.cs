using AutoMapper;
using GoldenHour.Domain.Services;
using GoldenHour.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.Brigades
{
    public class List
    {
        public class Query : IRequest<IList<BaseEntity>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<BaseEntity>>
        {
            private readonly IBrigadesRepository _brigadesRepository;
            private readonly IMapper _mapper;

            public Handler(IBrigadesRepository brigadesRepository, IMapper mapper)
            {
                _brigadesRepository = brigadesRepository;
                _mapper = mapper;
            }
            public async Task<IList<BaseEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IList<BaseEntity>>(await _brigadesRepository.GetAll().OrderBy(x => x.Name).ToListAsync());
            }
        }
    }
}
