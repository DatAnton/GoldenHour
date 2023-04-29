using AutoMapper;
using GoldenHour.DTO;
using GoldenHour.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.BloodGroups
{
    public class List
    {
        public class Query : IRequest<IList<BaseEntity>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<BaseEntity>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<BaseEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IList<BaseEntity>>(await _context.BloodGroups.OrderBy(x => x.Name).ToListAsync());
            }
        }
    }
}
