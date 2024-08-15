using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Security.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Queries.GetByNameUser;

public class GetByNameUserQuery : IRequest<GetByNameUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public GetByNameUserQuery()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public string[] Roles => new[] { Admin, Read, UsersOperationClaims.GetByNameUser };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameUser";
    public string CacheGroupKey => "GetUsers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameUserQueryHandler : IRequestHandler<GetByNameUserQuery, GetByNameUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public GetByNameUserQueryHandler(IMapper mapper, UserBusinessRules userBusinessRules, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<GetByNameUserResponse> Handle(GetByNameUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(
                predicate:u=>string.Equals($"{u.FirstName} {u.LastName}", $"{request.FirstName} {request.LastName}",StringComparison.OrdinalIgnoreCase),
                enableTracking:false,
                cancellationToken:cancellationToken
                );
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

            GetByNameUserResponse response = _mapper.Map<GetByNameUserResponse>(user);
            return response;
        }
    }
}
