using Application.Features.Suppliers.Constants;
using Application.Features.Suppliers.Rules;
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
using static Application.Features.Suppliers.Constants.SuppliersOperationClaims;

namespace Application.Features.Suppliers.Queries.GetListByDynamicSupplier;

public class GetListByDynamicSupplierQuery : IRequest<GetListResponse<GetListByDynamicSupplierItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicSupplierQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicSupplierQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }
    public string[] Roles => new[] { Admin, Read, SuppliersOperationClaims.GetListByDynamicSupplier };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicSupplier";
    public string CacheGroupKey => "GetSuppliers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicSupplierQueryHandler : IRequestHandler<GetListByDynamicSupplierQuery, GetListResponse<GetListByDynamicSupplierItemDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public GetListByDynamicSupplierQueryHandler(IMapper mapper,
                                                    SupplierBusinessRules supplierBusinessRules,
                                                    ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetListResponse<GetListByDynamicSupplierItemDto>> Handle(GetListByDynamicSupplierQuery request,
                                                                                   CancellationToken cancellationToken)
        {
            IPaginate<Supplier> suppliers = await _supplierRepository.GetListByDynamicAsync(
                dynamic:request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: s => s.Include(s => s.User).Include(s => s.Company).Include(s => s.Products),
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            GetListResponse<GetListByDynamicSupplierItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicSupplierItemDto>>(suppliers);
            return response;
        }
    }
}
