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

namespace Application.Features.Sellers.Queries.GetByUserIdSeller;

public class GetByUserIdSellerQuery : IRequest<GetByUserIdSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public int UserId { get; set; }
    public string[] Roles => new[] { Admin, Read, SellersOperationClaims.GetByUserIdSeller };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByUserIdSeller";
    public string CacheGroupKey => "GetSellers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByUserIdSellerQueryHandler : IRequestHandler<GetByUserIdSellerQuery, GetByUserIdSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly SellerBusinessRules _sellerBusinessRules;
        private readonly ISellerRepository _sellerRepository;

        public GetByUserIdSellerQueryHandler(IMapper mapper,
                                             SellerBusinessRules sellerBusinessRules,
                                             ISellerRepository sellerRepository)
        {
            _mapper = mapper;
            _sellerBusinessRules = sellerBusinessRules;
            _sellerRepository = sellerRepository;
        }

        public async Task<GetByUserIdSellerResponse> Handle(GetByUserIdSellerQuery request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(
                    predicate: s => s.UserId == request.UserId,
                    include: s => s.Include(s => s.User).Include(s => s.Shop),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);

            GetByUserIdSellerResponse response = _mapper.Map<GetByUserIdSellerResponse>(seller);
            return response;
        }
    }
}
