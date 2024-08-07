using Application.Features.ProductCategories.Constants;
using Application.Features.ProductCategories.Rules;
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
using static Application.Features.ProductCategories.Constants.ProductCategoriesOperationClaims;

namespace Application.Features.ProductCategories.Queries.GetListByDynamicProductCategory;

public class GetListByDynamicProductCategoryQuery : IRequest<GetListResponse<GetListByDynamicProductCategoryItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public string[] Roles => new[] { Admin, Read, ProductCategoriesOperationClaims.GetListByDynamicProductCategory };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicProductCategory";
    public string CacheGroupKey => "GetProductCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByDynamicProductCategoryQueryHandler
        : IRequestHandler<GetListByDynamicProductCategoryQuery, GetListResponse<GetListByDynamicProductCategoryItemDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public GetListByDynamicProductCategoryQueryHandler(IMapper mapper,
                                                           ProductCategoryBusinessRules productCategoryBusinessRules,
                                                           IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productCategoryBusinessRules = productCategoryBusinessRules;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<GetListResponse<GetListByDynamicProductCategoryItemDto>> Handle(GetListByDynamicProductCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductCategory> productCategories = await _productCategoryRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Products).Include(c => c.Parent),
                cancellationToken: cancellationToken
            );
            GetListResponse<GetListByDynamicProductCategoryItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicProductCategoryItemDto>>(null);
            return response;
        }
    }
}
