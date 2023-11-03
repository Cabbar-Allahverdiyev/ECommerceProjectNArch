using Application.Features.Suppliers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Suppliers.Rules;

public class SupplierBusinessRules : BaseBusinessRules
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierBusinessRules(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public Task SupplierShouldExistWhenSelected(Supplier? supplier)
    {
        if (supplier == null)
            throw new BusinessException(SuppliersBusinessMessages.SupplierNotExists);
        return Task.CompletedTask;
    }

    public async Task SupplierIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupplierShouldExistWhenSelected(supplier);
    }
}