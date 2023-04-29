using AutoMapper;
using AutoMapper.QueryableExtensions;
using GoldenHour.DTO.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoldenHour.Application.Users
{
    public class List
    {
        public class Query : IRequest<IList<ServiceMan>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<ServiceMan>>
        {
            private readonly UserManager<Domain.ServiceMan> _userManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<Domain.ServiceMan> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<IList<ServiceMan>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = _userManager.Users;
                var userRolesDictionary = new Dictionary<string, string>();
                
                var usersList = await users.ToListAsync();
                foreach(var user in usersList)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userRolesDictionary.Add(user.Id, string.Join(", ", roles));
                }

                return await users.ProjectTo<ServiceMan>(_mapper.ConfigurationProvider, 
                    new { usersRoles = userRolesDictionary }).ToListAsync();
            }
        }
    }
}
