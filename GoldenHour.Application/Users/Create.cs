using AutoMapper;
using GoldenHour.DTO.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GoldenHour.Application.Users
{
    public class Create
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
            private readonly IConfiguration _config;

            public Handler(UserManager<Domain.ServiceMan> userManager, 
                RoleManager<IdentityRole> roleManager, 
                IMapper mapper, 
                IConfiguration config)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _mapper = mapper;
                _config = config;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<Domain.ServiceMan>(request.User);
                user.Id = Guid.NewGuid().ToString();
                var hasher = new PasswordHasher<Domain.ServiceMan>();
                user.PasswordHash = hasher.HashPassword(user, _config["DefaultPassword"]);
                user.EmailConfirmed = true;

                await _userManager.CreateAsync(user);
                var role = await _roleManager.FindByIdAsync(request.User.RoleId);
                if(role != null)
                    await _userManager.AddToRoleAsync(user, role!.Name);

                return Unit.Value;
            }
        }
    }
}
