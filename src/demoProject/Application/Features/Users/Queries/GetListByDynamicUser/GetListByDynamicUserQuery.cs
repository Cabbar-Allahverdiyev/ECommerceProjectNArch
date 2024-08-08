using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Queries.GetListByDynamicUser;

public class GetListByDynamicUserQuery : IRequest<GetListResponse<GetListByDynamicUserItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public string[] Roles => new[] { Admin, Read, UsersOperationClaims.GetListByDynamicUser };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicUser";
    public string CacheGroupKey => "GetUsers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicUserQueryHandler : IRequestHandler<GetListByDynamicUserQuery, GetListResponse<GetListByDynamicUserItemDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public GetListByDynamicUserQueryHandler(IMapper mapper,
                                                UserBusinessRules userBusinessRules,
                                                IUserRepository userRepository)
        {
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<GetListResponse<GetListByDynamicUserItemDto>> Handle(GetListByDynamicUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<User> users = await _userRepository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken
           );
            GetListResponse<GetListByDynamicUserItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicUserItemDto>>(users);
            return response;
        }
    }
}
