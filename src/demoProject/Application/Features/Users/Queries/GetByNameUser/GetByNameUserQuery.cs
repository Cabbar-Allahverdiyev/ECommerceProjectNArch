using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Queries.GetByNameUser;

public class GetByNameUserQuery : IRequest<GetByNameUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{

    public string[] Roles => new[] { Admin, Read, UsersOperationClaims.GetByNameUser };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameUser";
    public string CacheGroupKey => "GetUsers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameUserQueryHandler : IRequestHandler<GetByNameUserQuery, GetByNameUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public GetByNameUserQueryHandler(IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<GetByNameUserResponse> Handle(GetByNameUserQuery request, CancellationToken cancellationToken)
        {
            GetByNameUserResponse response = _mapper.Map<GetByNameUserResponse>(null);
            return response;
        }
    }
}
