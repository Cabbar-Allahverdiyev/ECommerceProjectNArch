using Application.Features.Shops.Constants;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Shops.Constants.ShopsOperationClaims;
using Application.Services.UserOperationClaims;
using Application.Services.OperationClaims;
using Core.Security.Entities;
using Azure;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Shops.Commands.Create;

public class CreateShopCommand : IRequest<CreatedShopResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShops";

    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, CreatedShopResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly ShopBusinessRules _shopBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;

        public CreateShopCommandHandler(IMapper mapper, IShopRepository shopRepository,
                                         ShopBusinessRules shopBusinessRules)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _shopBusinessRules = shopBusinessRules;
        }

        public async Task<CreatedShopResponse> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            Shop shop = _mapper.Map<Shop>(request);
            await _shopBusinessRules.UserIdShouldExistWhenSelected(shop.UserId,cancellationToken);
            await _shopBusinessRules.CompanyIdShouldExistWhenSelected(shop.CompanyId,cancellationToken);

            shop.Id = Guid.NewGuid();

            await AddShopClaimOnUser(shop);
            await _shopRepository.AddAsync(shop);

            CreatedShopResponse response = _mapper.Map<CreatedShopResponse>(shop);
           
            return response;
        }

        private async Task AddShopClaimOnUser(Shop? shop)
        {
            if (shop != null)
            {
                OperationClaim? getClaim = await _operationClaimService.GetAsync(c => c.Name == ShopsOperationClaims.Shop);
                if (getClaim != null) { await _userOperationClaimService.AddAsync(new(shop.UserId, getClaim.Id)); }
                else { throw new BusinessException(ShopsBusinessMessages.ShopClaimNotExists); }
            }
        }
    }
}