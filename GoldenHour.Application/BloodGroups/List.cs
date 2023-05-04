using AutoMapper;
using GoldenHour.Domain.Services;
using GoldenHour.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.BloodGroups
{
    public class List
    {
        public class Query : IRequest<List<BaseEntity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<BaseEntity>>
        {
            private readonly IBloodGroupsRepository _bloodGroupsRepository;
            private readonly IMapper _mapper;

            public Handler(IBloodGroupsRepository bloodGroupsRepository, IMapper mapper)
            {
                _bloodGroupsRepository = bloodGroupsRepository;
                _mapper = mapper;
            }
            public async Task<List<BaseEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<BaseEntity>>(await _bloodGroupsRepository.GetAll().OrderBy(x => x.SequenceNumber).ToListAsync());
            }
        }
    }
}
