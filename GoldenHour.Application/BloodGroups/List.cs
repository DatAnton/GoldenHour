using AutoMapper;
using GoldenHour.Domain.Services;
using GoldenHour.DTO;
using MediatR;

namespace GoldenHour.Application.BloodGroups
{
    public class List
    {
        public class Query : IRequest<IList<BaseEntity>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<BaseEntity>>
        {
            private readonly IBloodGroupsRepository _bloodGroupsRepository;
            private readonly IMapper _mapper;

            public Handler(IBloodGroupsRepository bloodGroupsRepository, IMapper mapper)
            {
                _bloodGroupsRepository = bloodGroupsRepository;
                _mapper = mapper;
            }
            public async Task<IList<BaseEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IList<BaseEntity>>((await _bloodGroupsRepository.GetAll()).OrderBy(x => x.SequenceNumber));
            }
        }
    }
}
