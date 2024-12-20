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
using Application.Services.UserOperationClaims;

namespace Application.Features.Sellers.Commands.Update;

public class UpdateSellerCommand : IRequest<UpdatedSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ShopId { get; set; }

    public string[] Roles => new[] { Admin, Write, SellersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSellers";

    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, UpdatedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UpdateSellerCommandHandler(IMapper mapper,
                                          ISellerRepository sellerRepository,
                                          SellerBusinessRules sellerBusinessRules,
                                          IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<UpdatedSellerResponse> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);
            await _sellerBusinessRules.ShopIdShouldExistWhenSelected(request.ShopId,cancellationToken);
            await _sellerBusinessRules.UserIdShouldExistWhenSelected(request.UserId,cancellationToken);

            if (seller!.UserId != request.UserId)
            {
                await _userOperationClaimService.RemoveSellerClaimOnUser(seller!.UserId);
            }
            await _userOperationClaimService.AddSellerClaimOnUser(request!.UserId);
            seller = _mapper.Map(request, seller);

            await _sellerRepository.UpdateAsync(seller!);

            UpdatedSellerResponse response = _mapper.Map<UpdatedSellerResponse>(seller);
            return response;
        }
    }
}