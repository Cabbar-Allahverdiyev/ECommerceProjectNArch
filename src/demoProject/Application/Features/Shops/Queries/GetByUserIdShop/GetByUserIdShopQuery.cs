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

namespace Application.Features.Shops.Queries.GetByUserId;

public class GetByUserIdShopQuery : IRequest<GetByUserIdShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public int UserId{ get; set; }

    public string[] Roles => new[] { Admin, Read, ShopsOperationClaims.GetByUserIdShop };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByUserIdShop";
    public string CacheGroupKey => "GetShops";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByUserIdShopQueryHandler : IRequestHandler<GetByUserIdShopQuery, GetByUserIdShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly ShopBusinessRules _shopBusinessRules;
        private readonly IShopRepository _shopRepository;

        public GetByUserIdShopQueryHandler(IMapper mapper, ShopBusinessRules shopBusinessRules, IShopRepository shopRepository)
        {
            _mapper = mapper;
            _shopBusinessRules = shopBusinessRules;
            _shopRepository = shopRepository;
        }

        public async Task<GetByUserIdShopResponse> Handle(GetByUserIdShopQuery request, CancellationToken cancellationToken)
        {
            Shop? shop = await _shopRepository.GetAsync(
              predicate: s => s.UserId == request.UserId,
              include: s => s.Include(s => s.User).Include(s => s.Company),
              enableTracking: false,
              cancellationToken: cancellationToken);
            await _shopBusinessRules.ShopShouldExistWhenSelected(shop);

            GetByUserIdShopResponse response = _mapper.Map<GetByUserIdShopResponse>(shop);
            return response;
        }
    }
}
