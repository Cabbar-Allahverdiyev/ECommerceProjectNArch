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

namespace Application.Features.Sellers.Commands.Delete;

public class DeleteSellerCommand : IRequest<DeletedSellerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SellersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSellers";

    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand, DeletedSellerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly SellerBusinessRules _sellerBusinessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public DeleteSellerCommandHandler(IMapper mapper,
                                          ISellerRepository sellerRepository,
                                          SellerBusinessRules sellerBusinessRules,
                                          IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            _sellerBusinessRules = sellerBusinessRules;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<DeletedSellerResponse> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            Seller? seller = await _sellerRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sellerBusinessRules.SellerShouldExistWhenSelected(seller);

            await _userOperationClaimService.RemoveSellerClaimOnUser(seller!.UserId);
            await _sellerRepository.DeleteAsync(seller!);

            DeletedSellerResponse response = _mapper.Map<DeletedSellerResponse>(seller);
            return response;
        }
    }
}