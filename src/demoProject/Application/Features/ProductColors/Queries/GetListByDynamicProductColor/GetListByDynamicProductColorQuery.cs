using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
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
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Queries.GetListByDynamicProductColor;

public class GetListByDynamicProductColorQuery : IRequest<GetListResponse<GetListByDynamicProductColorItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest{ get; set; }
    public DynamicQuery DynamicQuery{ get; set; }

    public GetListByDynamicProductColorQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicProductColorQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }
    public string[] Roles => new[] { Admin, Read, ProductColorsOperationClaims.GetListByDynamicProductColor };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicProductColor";
    public string CacheGroupKey => "GetProductColors";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicProductColorQueryHandler : IRequestHandler<GetListByDynamicProductColorQuery, GetListResponse<GetListByDynamicProductColorItemDto>>
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IMapper _mapper;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public GetListByDynamicProductColorQueryHandler(IMapper mapper,
                                                        ProductColorBusinessRules productColorBusinessRules,
                                                        IProductColorRepository productColorRepository)
        {
            _mapper = mapper;
            _productColorBusinessRules = productColorBusinessRules;
            _productColorRepository = productColorRepository;
        }

        public async Task<GetListResponse<GetListByDynamicProductColorItemDto>> Handle(GetListByDynamicProductColorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductColor> colors = await _productColorRepository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Products),
                enableTracking: false,
                cancellationToken: cancellationToken
           );
            GetListResponse<GetListByDynamicProductColorItemDto> response =
                _mapper.Map<GetListResponse<GetListByDynamicProductColorItemDto>>(colors);
            return response;
        }
    }
}
