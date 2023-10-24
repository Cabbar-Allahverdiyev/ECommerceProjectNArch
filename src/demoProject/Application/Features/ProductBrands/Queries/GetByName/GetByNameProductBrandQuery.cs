using Application.Features.ProductBrands.Constants;
using Application.Features.ProductBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductBrands.Constants.ProductBrandsOperationClaims;

namespace Application.Features.ProductBrands.Queries.GetByName;

public class GetByNameProductBrandQuery : IRequest<GetByNameProductBrandResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }

    public string[] Roles => new[] { Admin, Read, ProductBrandsOperationClaims.GetByName };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByName";
    public string CacheGroupKey => "GetProductBrands";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameProductBrandQueryHandler : IRequestHandler<GetByNameProductBrandQuery, GetByNameProductBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ProductBrandBusinessRules _productBrandBusinessRules;
        private readonly IProductBrandRepository _productBrandRepository;

        public GetByNameProductBrandQueryHandler(IMapper mapper,
                                     ProductBrandBusinessRules productBrandBusinessRules,
                                     IProductBrandRepository productBrandRepository)
        {
            _mapper = mapper;
            _productBrandBusinessRules = productBrandBusinessRules;
            _productBrandRepository = productBrandRepository;
        }

        public async Task<GetByNameProductBrandResponse> Handle(GetByNameProductBrandQuery request, CancellationToken cancellationToken)
        {
            ProductBrand? productBrand = await _productBrandRepository.GetAsync(
                predicate:b=>string.Equals(b.Name,request.Name,StringComparison.OrdinalIgnoreCase),
                include: b=>b.Include(b=>b.Products),
                enableTracking:false,
                cancellationToken:cancellationToken);
            await _productBrandBusinessRules.ProductBrandShouldExistWhenSelected(productBrand);
            GetByNameProductBrandResponse response = _mapper.Map<GetByNameProductBrandResponse>(productBrand);
            return response;
        }
    }
}
