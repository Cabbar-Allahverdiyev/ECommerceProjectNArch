using Application.Features.Shops.Constants;
using Application.Features.Shops.Queries.GetList;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Shops.Constants.ShopsOperationClaims;

namespace Application.Features.Shops.Queries.GetListByCompanyName;

public class GetListByCompanyNameShopQuery : IRequest<GetListResponse<GetListByCompanyNameShopListItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CompanyName{ get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { Admin, Read, ShopsOperationClaims.GetByCompanyNameShopQuery };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByCompanyNameShopQuery";
    public string CacheGroupKey => "GetShops";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByCompanyNameShopQueryHandler : IRequestHandler<GetListByCompanyNameShopQuery, GetListResponse<GetListByCompanyNameShopListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ShopBusinessRules _shopBusinessRules;
        private readonly IShopRepository _shopRepository;

        public GetListByCompanyNameShopQueryHandler(IMapper mapper,
                                                     ShopBusinessRules shopBusinessRules,
                                                     IShopRepository shopRepository)
        {
            _mapper = mapper;
            _shopBusinessRules = shopBusinessRules;
            _shopRepository = shopRepository;
        }

        public async Task<GetListResponse<GetListByCompanyNameShopListItemDto>> Handle(GetListByCompanyNameShopQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Shop> shops = await _shopRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                predicate:s=> s.Company.Name.ToLower() == request.CompanyName.ToLower(),
                include: s => s.Include(s => s.User).Include(s => s.Company),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByCompanyNameShopListItemDto> response = _mapper.Map<GetListResponse<GetListByCompanyNameShopListItemDto>>(shops);
            return response;
        }
    }
}
