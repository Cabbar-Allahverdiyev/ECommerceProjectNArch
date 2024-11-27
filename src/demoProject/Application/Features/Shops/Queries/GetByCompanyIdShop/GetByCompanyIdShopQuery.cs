using Application.Features.Shops.Constants;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Shops.Constants.ShopsOperationClaims;

namespace Application.Features.Shops.Queries.GetByCompanyId;

public class GetByCompanyIdShopQuery : IRequest<GetByCompanyIdShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid CompanyId  { get; set; }
    public string[] Roles => new[] { Admin, Read, ShopsOperationClaims.GetByCompanyIdShop };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByCompanyIdShop";
    public string CacheGroupKey => "GetShops";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByCompanyIdShopQueryHandler : IRequestHandler<GetByCompanyIdShopQuery, GetByCompanyIdShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly ShopBusinessRules _shopBusinessRules;
        private readonly IShopRepository _shopRepository;

        public GetByCompanyIdShopQueryHandler(IMapper mapper, ShopBusinessRules shopBusinessRules, IShopRepository shopRepository)
        {
            _mapper = mapper;
            _shopBusinessRules = shopBusinessRules;
            _shopRepository = shopRepository;
        }

        public async Task<GetByCompanyIdShopResponse> Handle(GetByCompanyIdShopQuery request, CancellationToken cancellationToken)
        {
            Shop? shop = await _shopRepository.GetAsync(
               predicate: s => s.CompanyId == request.CompanyId,
               include: s => s.Include(s => s.User).Include(s => s.Company),
               enableTracking: false,
               cancellationToken: cancellationToken);
            await _shopBusinessRules.ShopShouldExistWhenSelected(shop);
            GetByCompanyIdShopResponse response = _mapper.Map<GetByCompanyIdShopResponse>(null);
            return response;
        }
    }
}
