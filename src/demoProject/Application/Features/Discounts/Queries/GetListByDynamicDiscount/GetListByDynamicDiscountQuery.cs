using Application.Features.Discounts.Constants;
using Application.Features.Discounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Discounts.Constants.DiscountsOperationClaims;

namespace Application.Features.Discounts.Queries.GetListByDynamicDiscount;

public class GetListByDynamicDiscountQuery : IRequest<GetListResponse<GetListByDynamicDiscountItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicDiscountQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicDiscountQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }
    public string[] Roles => new[] { Admin, Read, DiscountsOperationClaims.GetListByDynamicDiscount };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicDiscount";
    public string CacheGroupKey => "GetDiscounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByDynamicDiscountQueryHandler : IRequestHandler<GetListResponse<GetListByDynamicDiscountItemDto>, GetListResponse<GetListByDynamicDiscountItemDto>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly DiscountBusinessRules _discountBusinessRules;

        public GetListByDynamicDiscountQueryHandler(IMapper mapper,
                                                    DiscountBusinessRules discountBusinessRules,
                                                    IDiscountRepository discountRepository)
        {
            _mapper = mapper;
            _discountBusinessRules = discountBusinessRules;
            _discountRepository = discountRepository;
        }

        public async Task<GetListResponse<GetListByDynamicDiscountItemDto>> Handle(GetListByDynamicDiscountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Discount> discounts = await _discountRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: d => d.Include(d => d.Products),
                cancellationToken: cancellationToken,
                enableTracking: true
           );
            GetListResponse<GetListByDynamicDiscountItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicDiscountItemDto>>(discounts);
            return response;
        }
    }
}
