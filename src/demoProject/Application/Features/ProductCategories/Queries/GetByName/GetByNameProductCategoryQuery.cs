using Application.Features.ProductCategories.Constants;
using Application.Features.ProductCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductCategories.Constants.ProductCategoriesOperationClaims;

namespace Application.Features.ProductCategories.Queries.GetByName;

public class GetByNameProductCategoryQuery : IRequest<GetByNameProductCategoryResponse>//, ISecuredRequest, ILoggableRequest
{
    public string? Name { get; set; }
    public string[] Roles => new[] { Admin, Read, ProductCategoriesOperationClaims.GetByNameProductCategory };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameProductCategory";
    public string CacheGroupKey => "GetProductCategories";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameProductCategoryQueryHandler : IRequestHandler<GetByNameProductCategoryQuery, GetByNameProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public GetByNameProductCategoryQueryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository, ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _mapper = mapper;
            _productCategoryBusinessRules = productCategoryBusinessRules;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<GetByNameProductCategoryResponse> Handle(GetByNameProductCategoryQuery request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(
                predicate: pc => string.Equals(pc.Name,request.Name,StringComparison.OrdinalIgnoreCase) ,
                enableTracking: false,
                include: c => c.Include(c=>c.Parent).Include(c=>c.Products),
                cancellationToken: cancellationToken);
            await _productCategoryBusinessRules.ProductCategoryShouldExistWhenSelected(productCategory);

            GetByNameProductCategoryResponse response = _mapper.Map<GetByNameProductCategoryResponse>(productCategory);
            return response;
        }
    }
}
