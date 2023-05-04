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
        public class Query : IRequest<List<ServiceMan>>
        {

        }

        public class Handler : IRequestHandler<Query, List<ServiceMan>>
        {
            private readonly UserManager<Domain.ServiceMan> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<Domain.ServiceMan> userManager, 
                RoleManager<IdentityRole> roleManager, 
                IMapper mapper)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<List<ServiceMan>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = _userManager.Users;
                var userRolesDictionary = new Dictionary<string, string>();
                var rolesDictionary = await _roleManager.Roles.ToDictionaryAsync(r => r.Name, r => r.Id);
                
                var usersList = await users.ToListAsync();
                foreach(var user in usersList)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userRolesDictionary.Add(user.Id, string.Join(", ", roles));
                }

                return await users.ProjectTo<ServiceMan>(_mapper.ConfigurationProvider, 
                    new { usersRoles = userRolesDictionary, roles = rolesDictionary })
                    .ToListAsync();
            }
        }
    }
}
