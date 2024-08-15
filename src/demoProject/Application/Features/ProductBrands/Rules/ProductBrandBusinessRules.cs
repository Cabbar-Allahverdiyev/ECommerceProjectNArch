using Application.Features.ProductBrands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductBrands.Rules;

public class ProductBrandBusinessRules : BaseBusinessRules
{
    private readonly IProductBrandRepository _productBrandRepository;

    public ProductBrandBusinessRules(IProductBrandRepository productBrandRepository)
    {
        _productBrandRepository = productBrandRepository;
    }

    public Task ProductBrandShouldExistWhenSelected(ProductBrand? productBrand)
    {
        if (productBrand == null)
            throw new BusinessException(ProductBrandsBusinessMessages.ProductBrandNotExists);
        return Task.CompletedTask;
    }
    public Task ProductBrandShouldNotExistWhenSelected(ProductBrand? productBrand)
    {
        if (productBrand != null)
            throw new BusinessException(ProductBrandsBusinessMessages.ProductBrandExists);
        return Task.CompletedTask;
    }

    public async Task ProductBrandIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductBrand? productBrand = await _productBrandRepository.GetAsync(
            predicate: pb => pb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductBrandShouldExistWhenSelected(productBrand);
    }

    public async Task ProductBrandNameShouldNotExistWhenSelected(string name, CancellationToken cancellationToken)
    {
        ProductBrand? productBrand = await _productBrandRepository.GetAsync(
            predicate: pb => string.Equals(pb.Name,name,StringComparison.OrdinalIgnoreCase) ,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductBrandShouldNotExistWhenSelected(productBrand);
    }

    public async Task ProductBrandNameShouldNotExistWhenUpdated(Guid id, string? name, CancellationToken cancellationToken)
    {
        ProductBrand? productBrand = await _productBrandRepository.GetAsync(
            predicate: pb => string.Equals(pb.Name, name, StringComparison.OrdinalIgnoreCase) && pb.Id !=id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductBrandShouldNotExistWhenSelected(productBrand);
    }
}