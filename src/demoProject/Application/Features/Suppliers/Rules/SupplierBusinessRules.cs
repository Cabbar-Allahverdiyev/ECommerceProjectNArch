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
    public Task SupplierShouldNotExistWhenSelected(Supplier? supplier,string errorMessage= SuppliersBusinessMessages.SupplierExists)
    {
        if (supplier != null)
            throw new BusinessException(errorMessage);
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
    public async Task UserIdShouldNotExistWhenCreated(int userId, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(
            predicate: s => s.UserId == userId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupplierShouldNotExistWhenSelected(supplier,SuppliersBusinessMessages.UserIdAlreadyExists);
    }
    public async Task UserIdShouldNotExistWhenUpdated(Guid supplierId,int userId, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(
            predicate: s => s.UserId == userId && s.Id!=supplierId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupplierShouldNotExistWhenSelected(supplier, SuppliersBusinessMessages.UserIdAlreadyExists);
    }

    public async Task CompanyIdShouldNotExistWhenCreated(Guid companyId, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(
            predicate: s => s.CompanyId == companyId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupplierShouldNotExistWhenSelected(supplier, SuppliersBusinessMessages.CompanyIdAlreadyExists);
    }

    public async Task CompanyIdShouldNotExistWhenUpdated(Guid supplierId,Guid companyId, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(
            predicate: s => s.CompanyId == companyId && s.Id!=supplierId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupplierShouldNotExistWhenSelected(supplier, SuppliersBusinessMessages.CompanyIdAlreadyExists);
    }
}