using Application.Features.ProductInventors.Constants;
using Application.Features.ProductInventors.Rules;
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
using static Application.Features.ProductInventors.Constants.ProductInventorsOperationClaims;

namespace Application.Features.ProductInventors.Queries.GetListByDynamicProductInventor;

public class GetListByDynamicProductInventorQuery : IRequest<GetListResponse<GetListByDynamicProductInventorItemDto>>
                                                  , ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    public string[] Roles => new[] { Admin, Read, ProductInventorsOperationClaims.GetListByDynamicProductInventor };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicProductInventor";
    public string CacheGroupKey => "GetProductInventors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByDynamicProductInventorQueryHandler
        : IRequestHandler<GetListByDynamicProductInventorQuery, GetListResponse<GetListByDynamicProductInventorItemDto>>
    {
        private readonly IProductInventorRepository _productInventorRepository;
        private readonly IMapper _mapper;
        private readonly ProductInventorBusinessRules _productInventorBusinessRules;

        public GetListByDynamicProductInventorQueryHandler(IMapper mapper,
                                                           ProductInventorBusinessRules productInventorBusinessRules,
                                                           IProductInventorRepository productInventorRepository)
        {
            _mapper = mapper;
            _productInventorBusinessRules = productInventorBusinessRules;
            _productInventorRepository = productInventorRepository;
        }

        public async Task<GetListResponse<GetListByDynamicProductInventorItemDto>> Handle(GetListByDynamicProductInventorQuery request,
                                                                                          CancellationToken cancellationToken)
        {
            IPaginate<ProductInventor> inventors = await _productInventorRepository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: i => i.Include(i => i.Product),
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            GetListResponse<GetListByDynamicProductInventorItemDto> response =
                _mapper.Map<GetListResponse<GetListByDynamicProductInventorItemDto>>(inventors);
            return response;
        }
    }
}
