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

namespace Application.Features.Discounts.Commands.Create;

public class CreateDiscountCommand : IRequest<CreatedDiscountResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public decimal DiscountPercent { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, DiscountsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetDiscounts";

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CreatedDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;
        private readonly DiscountBusinessRules _discountBusinessRules;

        public CreateDiscountCommandHandler(IMapper mapper, IDiscountRepository discountRepository,
                                         DiscountBusinessRules discountBusinessRules)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
            _discountBusinessRules = discountBusinessRules;
        }

        public async Task<CreatedDiscountResponse> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount discount = _mapper.Map<Discount>(request);
            discount.Id = Guid.NewGuid();

            await _discountBusinessRules.DiscountIdShouldNotExistWhenSelected(discount.Id,cancellationToken);
            await _discountBusinessRules.DiscountNameShouldNotExistWhenSelected(discount,cancellationToken);

            await _discountRepository.AddAsync(discount);

            CreatedDiscountResponse response = _mapper.Map<CreatedDiscountResponse>(discount);
            return response;
        }
    }
}