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

namespace Application.Features.Suppliers.Queries.GetByUserId;

public class GetByUserIdSupplierQuery : IRequest<GetByUserIdSupplierResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public int UserId { get; set; }
    public string[] Roles => new[] { Admin, Read, SuppliersOperationClaims.GetByUserIdSupplier };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByUserIdSupplier";
    public string CacheGroupKey => "GetSuppliers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByUserIdSupplierQueryHandler : IRequestHandler<GetByUserIdSupplierQuery, GetByUserIdSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public GetByUserIdSupplierQueryHandler(IMapper mapper,
                                                 ISupplierRepository supplierRepository,
                                                 SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierBusinessRules = supplierBusinessRules;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetByUserIdSupplierResponse> Handle(GetByUserIdSupplierQuery request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _supplierRepository.GetAsync(
               predicate: s => s.UserId == request.UserId,
               include: s => s.Include(s => s.User).Include(s => s.Company).Include(s => s.Products),
               enableTracking: false,
               cancellationToken: cancellationToken);
            await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);
            GetByUserIdSupplierResponse response = _mapper.Map<GetByUserIdSupplierResponse>(null);
            return response;
        }
    }
}
