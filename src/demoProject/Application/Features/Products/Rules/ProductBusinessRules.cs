using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductsBusinessMessages.ProductNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductShouldExistWhenSelected(product);
    }

    public   Task ProductPurchasePriceShouldBeLessThanUnitPrice(decimal purchasePrice, decimal unitPrice)
    {
        if (purchasePrice >= unitPrice) throw new BusinessException(ProductsBusinessMessages.PurchasePriceShouldBeLessThanOrEqualUnitPrice);
        return Task.CompletedTask;
    }

    public Task ProductNameShouldNotHasSupplierAndColorUsedAlreadyWhenInsert(string? name, Guid supplierId, Guid productColorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}