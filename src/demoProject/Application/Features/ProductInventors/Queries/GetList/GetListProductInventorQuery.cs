using Application.Features.ProductInventors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductInventors.Constants.ProductInventorsOperationClaims;

namespace Application.Features.ProductInventors.Queries.GetList;

public class GetListProductInventorQuery : IRequest<GetListResponse<GetListProductInventorListItemDto>>//, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProductInventors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProductInventors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductInventorQueryHandler : IRequestHandler<GetListProductInventorQuery, GetListResponse<GetListProductInventorListItemDto>>
    {
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly IMapper _mapper;

        public GetListProductInventorQueryHandler(IProductInventorRepository productInventorRepository, IMapper mapper)
        {
            _productInventorRepository = productInventorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductInventorListItemDto>> Handle(GetListProductInventorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductInventor> productInventors = await _productInventorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductInventorListItemDto> response = _mapper.Map<GetListResponse<GetListProductInventorListItemDto>>(productInventors);
            return response;
        }
    }
}