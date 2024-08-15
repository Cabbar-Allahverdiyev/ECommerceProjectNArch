using Application.Features.Products.Constants;
using Application.Features.Products.Rules;
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
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Queries.GetListByDynamicProduct;

public class GetListByDynamicProductQuery : IRequest<GetListResponse<GetListByDynamicProductItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicProductQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicProductQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }

    public string[] Roles => new[] { Admin, Read, ProductsOperationClaims.GetListByDynamicProduct };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicProduct";
    public string CacheGroupKey => "GetProducts";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicProductQueryHandler : IRequestHandler<GetListByDynamicProductQuery, GetListResponse<GetListByDynamicProductItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetListByDynamicProductQueryHandler(IMapper mapper,
                                                   ProductBusinessRules productBusinessRules,
                                                   IProductRepository productRepository)
        {
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _productRepository = productRepository;
        }

        public async Task<GetListResponse<GetListByDynamicProductItemDto>> Handle(GetListByDynamicProductQuery request,
                                                                                  CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListByDynamicAsync(
               dynamic:request.DynamicQuery,
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               include: p => p.Include(p => p.Barcode)
                               .Include(p => p.Brand)
                               .Include(p => p.Category)
                               .Include(p => p.Discount)
                               .Include(p => p.ProductColor)
                               .Include(p => p.Supplier)
                               .Include(p => p.Inventor),
               cancellationToken: cancellationToken
           );
            GetListResponse<GetListByDynamicProductItemDto> response =
                _mapper.Map<GetListResponse<GetListByDynamicProductItemDto>>(products);
            return response;
        }
    }
}
