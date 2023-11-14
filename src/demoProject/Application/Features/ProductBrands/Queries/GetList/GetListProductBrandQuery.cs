using Application.Features.ProductBrands.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductBrands.Constants.ProductBrandsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductBrands.Queries.GetList;

public class GetListProductBrandQuery : IRequest<GetListResponse<GetListProductBrandListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductBrands({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductBrands";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductBrandQueryHandler : IRequestHandler<GetListProductBrandQuery, GetListResponse<GetListProductBrandListItemDto>>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public GetListProductBrandQueryHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductBrandListItemDto>> Handle(GetListProductBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductBrand> productBrands = await _productBrandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                include:pb=>pb.Include(pb=>pb.Products),
                enableTracking:true
            );

            GetListResponse<GetListProductBrandListItemDto> response = _mapper.Map<GetListResponse<GetListProductBrandListItemDto>>(productBrands);
            return response;
        }
    }
}