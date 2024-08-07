using Application.Features.Discounts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Discounts.Constants.DiscountsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Discounts.Queries.GetList;

public class GetListDiscountQuery : IRequest<GetListResponse<GetListDiscountListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public GetListDiscountQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListDiscountQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListDiscounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetDiscounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDiscountQueryHandler : IRequestHandler<GetListDiscountQuery, GetListResponse<GetListDiscountListItemDto>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetListDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDiscountListItemDto>> Handle(GetListDiscountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Discount> discounts = await _discountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                include:d=>d.Include(d=>d.Products),
                cancellationToken: cancellationToken,
                 enableTracking: true
            );

            GetListResponse<GetListDiscountListItemDto> response = _mapper.Map<GetListResponse<GetListDiscountListItemDto>>(discounts);
            return response;
        }
    }
}