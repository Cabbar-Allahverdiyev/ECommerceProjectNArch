using Application.Features.Products.Constants;
using Application.Services.Barcodes;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;
using System.Threading;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;
    private readonly IBarcodesService _barcodesService;

    public ProductBusinessRules(IProductRepository productRepository, IBarcodesService barcodesService)
    {
        _productRepository = productRepository;
        _barcodesService = barcodesService;
    }

    public Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductsBusinessMessages.ProductNotExists);
        return Task.CompletedTask;
    }
    public Task ProductShouldNotExistWhenSelected(Product? product)
    {
        if (product != null)
            throw new BusinessException(ProductsBusinessMessages.ProductExists);
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

    public Task ProductPurchasePriceShouldBeLessThanUnitPrice(decimal? purchasePrice, decimal? unitPrice)
    {
        if (purchasePrice >= unitPrice) throw new BusinessException(ProductsBusinessMessages.PurchasePriceShouldBeLessThanOrEqualUnitPrice);
        return Task.CompletedTask;
    }

    public async Task ProductNameShouldNotHasSupplierAndColorUsedAlreadyWhenInsert(string? name, Guid supplierId, Guid productColorId, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetAsync(
            predicate: p => p.ProductColorId == productColorId && p.SupplierId == supplierId && p.Name == name,
            enableTracking: false,
            cancellationToken: cancellationToken);
        await ProductShouldNotExistWhenSelected(product);
    }
    public async Task ProductNameShouldNotHasSupplierAndColorUsedAlreadyWhenUpdate(Guid? productId,
        string? name, Guid? supplierId, Guid? productColorId, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetAsync(
            predicate: p => p.ProductColorId == productColorId && p.SupplierId == supplierId && p.Name == name && p.Id != productId,
        enableTracking: false,
            cancellationToken: cancellationToken);
        await ProductShouldNotExistWhenSelected(product);
    }

    public async Task ProductPurchasePriceShouldBeLessThanUnitPriceWhenUpdated(decimal? purchasePrice, decimal? unitPrice)
    {
        if (purchasePrice > 0 && unitPrice > 0) await ProductPurchasePriceShouldBeLessThanUnitPrice(purchasePrice, unitPrice);
    }

    public async Task BarcdeNumberShouldNotExistWhenInserted(string barcodeNumber, CancellationToken cancellationToken)
    {
        if (barcodeNumber != null)
        {
            var getBarcode = await _barcodesService.GetAsync(predicate: b => b.BarcodeNumber.ToLower() == barcodeNumber.ToLower(),
                                                            cancellationToken: cancellationToken,
                                                            enableTracking: false);


            if (getBarcode != null)throw new BusinessException(ProductsBusinessMessages.BarcoodeNumberAlreadyExist);            
        }
        throw new BusinessException(ProductsBusinessMessages.BarcodeNumberIsNull);
    }
}