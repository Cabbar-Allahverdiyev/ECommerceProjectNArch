using Application.Features.Suppliers.Constants;
using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Suppliers.Constants.SuppliersOperationClaims;

namespace Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommand : IRequest<CreatedSupplierResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, SuppliersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSuppliers";

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreatedSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public CreateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository,
                                         SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierBusinessRules = supplierBusinessRules;
        }

        public async Task<CreatedSupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier supplier = _mapper.Map<Supplier>(request);
           await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);
           await _supplierBusinessRules.UserIdShouldNotExistWhenCreated(supplier.UserId,cancellationToken);
           await _supplierBusinessRules.CompanyIdShouldNotExistWhenCreated(supplier.CompanyId,cancellationToken);

            supplier.Id = Guid.NewGuid();
            await _supplierRepository.AddAsync(supplier);

            CreatedSupplierResponse response = _mapper.Map<CreatedSupplierResponse>(supplier);
            return response;
        }
    }
}