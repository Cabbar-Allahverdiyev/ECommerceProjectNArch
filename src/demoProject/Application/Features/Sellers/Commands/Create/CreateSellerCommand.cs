using Application.Features.Sellers.Constants;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sellers.Constants.SellersOperationClaims;

namespace Application.Features.Sellers.Commands.Create;

public class CreateSellerCommand : IRequest<CreatedSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public Guid ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, SellersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSellers";

    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, CreatedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;

        public CreateSellerCommandHandler(IMapper mapper, ISellerRepository sellerRepository,
                                         SellerBusinessRules sellerBusinessRules)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
        }

        public async Task<CreatedSellerResponse> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            Seller seller = _mapper.Map<Seller>(request);

            await _sellerRepository.AddAsync(seller);

            CreatedSellerResponse response = _mapper.Map<CreatedSellerResponse>(seller);
            return response;
        }
    }
}