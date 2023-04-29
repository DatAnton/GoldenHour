using AutoMapper;
using GoldenHour.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.Roles
{
    public class List
    {
        public class Query : IRequest<IList<BaseEntity>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<BaseEntity>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IMapper _mapper;

            public Handler(RoleManager<IdentityRole> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }
            public async Task<IList<BaseEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IList<BaseEntity>>(await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync());
            }
        }
    }
}
