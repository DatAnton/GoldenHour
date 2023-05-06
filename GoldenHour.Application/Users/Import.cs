using GoldenHour.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GoldenHour.Application.Users
{
    public class Import
    {
        public class Command : IRequest<int>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly UserManager<Domain.ServiceMan> _userManager;
            private readonly CsvService _csvService;
            private readonly IConfiguration _config;

            public Handler(UserManager<Domain.ServiceMan> userManager,
                CsvService csvService,
                IConfiguration config)
            {
                _userManager = userManager;
                _csvService = csvService;
                _config = config;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var users = await _csvService.ReadCsv(request.File);
                
                var hasher = new PasswordHasher<Domain.ServiceMan>();

                foreach (var user in users)
                {
                    user.PasswordHash = hasher.HashPassword(user, _config["DefaultPassword"]);
                    await _userManager.CreateAsync(user);
                    await _userManager.AddToRoleAsync(user, "Military");
                }

                return users.Count;
            }
        }
    }
}
