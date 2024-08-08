using Application.Features.ProductBrands.Constants;
using Application.Features.ProductBrands.Rules;
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
using static Application.Features.ProductBrands.Constants.ProductBrandsOperationClaims;

namespace Application.Features.ProductBrands.Queries.GetListByDynamicProductBrand;

public class GetListByDynamicProductBrandQuery : IRequest<GetListResponse<GetListByDynamicProductBrandItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery{ get; set; }

    public GetListByDynamicProductBrandQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicProductBrandQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }
    public string[] Roles => new[] { Admin, Read, ProductBrandsOperationClaims.GetListByDynamicProductBrand };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicProductBrand";
    public string CacheGroupKey => "GetProductBrands";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicProductBrandQueryHandler : IRequestHandler<GetListByDynamicProductBrandQuery, GetListResponse<GetListByDynamicProductBrandItemDto>>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;

        public GetListByDynamicProductBrandQueryHandler(IMapper mapper,
                                                        ProductBrandBusinessRules productBrandBusinessRules,
                                                        IProductBrandRepository productBrandRepository)
        {
            _mapper = mapper;
            _productBrandBusinessRules = productBrandBusinessRules;
            _productBrandRepository = productBrandRepository;
        }

        public async Task<GetListResponse<GetListByDynamicProductBrandItemDto>> Handle(GetListByDynamicProductBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductBrand> productBrands = await _productBrandRepository.GetListByDynamicAsync(
               dynamic: request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               include: pb => pb.Include(pb => pb.Products),
               cancellationToken: cancellationToken,
               enableTracking: false
           );
            GetListResponse<GetListByDynamicProductBrandItemDto> response = _mapper.
                Map<GetListResponse<GetListByDynamicProductBrandItemDto>>(productBrands);
            return response;
        }
    }
}
