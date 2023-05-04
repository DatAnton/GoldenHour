using AutoMapper;
using GoldenHour.Domain.Services;
using GoldenHour.DTO.Users;
using MediatR;

namespace GoldenHour.Application.Users
{
    public class Details
    {
        public class Query : IRequest<ServiceMan>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceMan>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public Handler(IUserRepository userRepository,
                IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<ServiceMan> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetFullServiceManByUserName(request.UserName);

                return _mapper.Map<ServiceMan>(user);
            }
        }
    }
}
