using Application.Features.ProductInventors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductInventors.Rules;

public class ProductInventorBusinessRules : BaseBusinessRules
{
    private readonly IProductInventorRepository _productInventorRepository;

    public ProductInventorBusinessRules(IProductInventorRepository productInventorRepository)
    {
        _productInventorRepository = productInventorRepository;
    }

    public Task ProductInventorShouldExistWhenSelected(ProductInventor? productInventor)
    {
        if (productInventor == null)
            throw new BusinessException(ProductInventorsBusinessMessages.ProductInventorNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductInventorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductInventor? productInventor = await _productInventorRepository.GetAsync(
            predicate: pi => pi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductInventorShouldExistWhenSelected(productInventor);
    }
}