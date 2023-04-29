using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GoldenHour.Application.Users
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
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
                var user = await _userManager.FindByIdAsync(request.Id);
                if(user != null)
                {
                    await _userManager.DeleteAsync(user);
                }

                return Unit.Value;
            }
        }
    }
}
