using Application.Features.Suppliers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Suppliers.Constants.SuppliersOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Suppliers.Queries.GetList;

public class GetListSupplierQuery : IRequest<GetListResponse<GetListSupplierListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public GetListSupplierQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListSupplierQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSuppliers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSuppliers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSupplierQueryHandler : IRequestHandler<GetListSupplierQuery, GetListResponse<GetListSupplierListItemDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetListSupplierQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSupplierListItemDto>> Handle(GetListSupplierQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Supplier> suppliers = await _supplierRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: s => s.Include(s => s.User).Include(s => s.Company).Include(s => s.Products),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSupplierListItemDto> response = _mapper.Map<GetListResponse<GetListSupplierListItemDto>>(suppliers);
            return response;
        }
    }
}