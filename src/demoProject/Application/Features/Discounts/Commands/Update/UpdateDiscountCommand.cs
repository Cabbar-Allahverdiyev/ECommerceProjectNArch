using Application.Features.Discounts.Constants;
using Application.Features.Discounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Discounts.Constants.DiscountsOperationClaims;

namespace Application.Features.Discounts.Commands.Update;

public class UpdateDiscountCommand : IRequest<UpdatedDiscountResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => new[] { Admin, Write, DiscountsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetDiscounts";

    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, UpdatedDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;
        private readonly DiscountBusinessRules _discountBusinessRules;

        public UpdateDiscountCommandHandler(IMapper mapper, IDiscountRepository discountRepository,
                                         DiscountBusinessRules discountBusinessRules)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
            _discountBusinessRules = discountBusinessRules;
        }

        public async Task<UpdatedDiscountResponse> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount? discount = await _discountRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _discountBusinessRules.DiscountShouldExistWhenSelected(discount);
            await _discountBusinessRules.DiscountNameShouldNotExistWhenUpdated(discount,request.Name,cancellationToken);
            discount = _mapper.Map(request, discount);

            await _discountRepository.UpdateAsync(discount!);

            UpdatedDiscountResponse response = _mapper.Map<UpdatedDiscountResponse>(discount);
            return response;
        }
    }
}