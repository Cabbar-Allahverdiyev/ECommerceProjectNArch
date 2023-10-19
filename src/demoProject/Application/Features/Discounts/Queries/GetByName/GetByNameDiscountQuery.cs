﻿using Application.Features.Discounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Discounts.Constants.DiscountsOperationClaims;

namespace Application.Features.Discounts.Queries.GetByName;
public class GetByNameDiscountQuery:IRequest<GetByNameDiscountResponse>//, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByNameDiscountQueryHandler : IRequestHandler<GetByNameDiscountQuery, GetByNameDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;
        private readonly DiscountBusinessRules _discountBusinessRules;

        public GetByNameDiscountQueryHandler(IMapper mapper, IDiscountRepository discountRepository, DiscountBusinessRules discountBusinessRules)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
            _discountBusinessRules = discountBusinessRules;
        }
        public async Task<GetByNameDiscountResponse> Handle(GetByNameDiscountQuery request, CancellationToken cancellationToken)
        {
            Discount? discount = await _discountRepository.GetAsync(
                predicate: d =>string.Equals(d.Name,request.Name,StringComparison.OrdinalIgnoreCase),
                cancellationToken: cancellationToken,
                enableTracking:false);
            await _discountBusinessRules.DiscountShouldExistWhenSelected(discount);

            GetByNameDiscountResponse response = _mapper.Map<GetByNameDiscountResponse>(discount);
            return response;
        }
    }
}
