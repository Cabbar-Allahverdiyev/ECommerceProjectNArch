using Application.Features.Products.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Products.Constants.ProductsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public GetListProductQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListProductQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProducts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProducts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                include: p=>p.Include(p=>p.Barcode)
                                .Include(p=>p.Brand)
                                .Include(p=>p.Category)
                                .Include(p=>p.Discount)
                                .Include(p=>p.ProductColor)
                                .Include(p=>p.Supplier)
                                .Include(p=>p.Inventor),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductListItemDto> response = _mapper.Map<GetListResponse<GetListProductListItemDto>>(products);
            return response;
        }
    }
}