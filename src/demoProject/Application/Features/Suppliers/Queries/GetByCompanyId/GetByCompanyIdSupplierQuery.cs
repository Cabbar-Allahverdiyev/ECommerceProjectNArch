using Application.Features.Suppliers.Constants;
using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Suppliers.Constants.SuppliersOperationClaims;

namespace Application.Features.Suppliers.Queries.GetByCompanyId;

public class GetByCompanyIdSupplierQuery : IRequest<GetByCompanyIdSupplierResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid CompanyId { get; set; }
    public string[] Roles => new[] { Admin, Read, SuppliersOperationClaims.GetByCompanyIdSuppier };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByCompanyIdSuppier";
    public string CacheGroupKey => "GetSuppliers";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByCompanyIdSuppierQueryHandler : IRequestHandler<GetByCompanyIdSupplierQuery, GetByCompanyIdSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public GetByCompanyIdSuppierQueryHandler(IMapper mapper,
                                                 ISupplierRepository supplierRepository,
                                                 SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetByCompanyIdSupplierResponse> Handle(GetByCompanyIdSupplierQuery request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _supplierRepository.GetAsync(
               predicate: s => s.CompanyId == request.CompanyId,
               include: s => s.Include(s => s.User).Include(s => s.Company).Include(s => s.Products),
               enableTracking: false,
               cancellationToken: cancellationToken);
            await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);
            GetByCompanyIdSupplierResponse response = _mapper.Map<GetByCompanyIdSupplierResponse>(supplier);
            return response;
        }
    }
}
