using GoldenHour.DTO.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GoldenHour.Application.Users
{
    public class ChangePassword
    {
        public class Command : IRequest
        {
            public ChangePasswordData Data { get; set; }
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly UserManager<Domain.ServiceMan> _userManager;

            public Handler(UserManager<Domain.ServiceMan> userManager)
            {
                _userManager = userManager;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!string.IsNullOrWhiteSpace(request.Data?.NewPassword) 
                    && request.Data?.NewPassword == request.Data?.ConfirmPassword
                    && !string.IsNullOrWhiteSpace(request.Data?.OldPassword))
                {
                    var user = await _userManager.FindByIdAsync(request.UserId);

                    if(await _userManager.CheckPasswordAsync(user, request.Data.OldPassword))
                    {
                        await _userManager.ChangePasswordAsync(user, request.Data.OldPassword, 
                            request.Data.NewPassword);
                    }
                }

                return Unit.Value;
            }
        }
    }
}
