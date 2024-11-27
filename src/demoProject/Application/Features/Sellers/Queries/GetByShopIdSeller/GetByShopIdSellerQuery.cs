using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Queries.GetByShopIdSeller;

public class GetByShopIdSellerQuery : IRequest<GetByShopIdSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid ShopId { get; set; }
    public string[] Roles => new[] { Admin, Read, SellersOperationClaims.GetByShopIdSeller };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByShopIdSeller";
    public string CacheGroupKey => "GetSellers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByShopIdSellerQueryHandler : IRequestHandler<GetByShopIdSellerQuery, GetByShopIdSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly SellerBusinessRules _sellerBusinessRules; 
        private readonly ISellerRepository _sellerRepository;

        public GetByShopIdSellerQueryHandler(IMapper mapper,
                                             SellerBusinessRules sellerBusinessRules,
                                             ISellerRepository sellerRepository)
        {
            _mapper = mapper;
            _sellerBusinessRules = sellerBusinessRules;
            _sellerRepository = sellerRepository;
        }

        public async Task<GetByShopIdSellerResponse> Handle(GetByShopIdSellerQuery request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(
                predicate: s => s.ShopId == request.ShopId,
                include: s => s.Include(s => s.User).Include(s => s.Shop),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);

            GetByShopIdSellerResponse response = _mapper.Map<GetByShopIdSellerResponse>(seller);
            return response;
        }
    }
}
