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

namespace Application.Features.Suppliers.Commands.Update;

public class UpdateSupplierCommand : IRequest<UpdatedSupplierResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }

    public string[] Roles => new[] { Admin, Write, SuppliersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSuppliers";

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdatedSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly SupplierBusinessRules _supplierBusinessRules;

        public UpdateSupplierCommandHandler(IMapper mapper, ISupplierRepository supplierRepository,
                                         SupplierBusinessRules supplierBusinessRules)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _supplierBusinessRules = supplierBusinessRules;
        }

        public async Task<UpdatedSupplierResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _supplierRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _supplierBusinessRules.SupplierShouldExistWhenSelected(supplier);
            supplier = _mapper.Map(request, supplier);

            await _supplierRepository.UpdateAsync(supplier!);

            UpdatedSupplierResponse response = _mapper.Map<UpdatedSupplierResponse>(supplier);
            return response;
        }
    }
}