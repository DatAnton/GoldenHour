using AutoMapper;
using GoldenHour.DTO.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GoldenHour.Application.Users
{
    public class Update
    {
        public class Command : IRequest
        {
            public ServiceMan User { get; set; }
        }

        public class Handler : IRequestHandler<Command>
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
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var requestUser = _mapper.Map<Domain.ServiceMan>(request.User);
                var existedUser = await _userManager.FindByIdAsync(requestUser.Id);

                var user = _mapper.Map(requestUser, existedUser);
                
                await _userManager.UpdateAsync(user);

                var existedRole = (await _userManager.GetRolesAsync(user)).First();
                var role = await _roleManager.FindByIdAsync(request.User.RoleId);
                if (role != null && existedRole != role.Name)
                {
                    await _userManager.RemoveFromRoleAsync(user, existedRole);
                    await _userManager.AddToRoleAsync(user, role!.Name);   
                }

                return Unit.Value;
            }
        }
    }
}
