using Application.Features.Products.Constants;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Queries.GetByName;

public class GetByNameProductQuery : IRequest<GetByNameProductResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }

    public string[] Roles => new[] { Admin, Read, ProductsOperationClaims.GetByNameProduct };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameProduct";
    public string CacheGroupKey => "GetProducts";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameProductQueryHandler : IRequestHandler<GetByNameProductQuery, GetByNameProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetByNameProductQueryHandler(IMapper mapper, IProductRepository productRepository, ProductBusinessRules productBusinessRules)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<GetByNameProductResponse> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(// eyni adli mehsul bazada var cunki
                                                                 // eyni adla ferqli tedarukculer ferqli
                                                                 // rengler ile mehsul elave ede bilerler
                predicate: p => p.Name == request.Name,
                include: p => p.Include(p => p.Brand)
                                .Include(p => p.Category)
                                .Include(p => p.Discount)
                                .Include(p => p.ProductColor)
                                .Include(p => p.ProductInventor)
                                .Include(p => p.Supplier),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _productBusinessRules.ProductShouldExistWhenSelected(product);

            GetByNameProductResponse response = _mapper.Map<GetByNameProductResponse>(product);
            return response;
        }

    }
}
