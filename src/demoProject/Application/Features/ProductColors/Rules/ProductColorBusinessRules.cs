using Application.Features.ProductColors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductColors.Rules;

public class ProductColorBusinessRules : BaseBusinessRules
{
    private readonly IProductColorRepository _productColorRepository;

    public ProductColorBusinessRules(IProductColorRepository productColorRepository)
    {
        _productColorRepository = productColorRepository;
    }

    public Task ProductColorShouldExistWhenSelected(ProductColor? productColor,string? message= ProductColorsBusinessMessages.ProductColorNotExists)
    {
        if (productColor == null)
            throw new BusinessException(message);
        return Task.CompletedTask;
    }

    public Task ProductColorShouldNotExistWhenSelected(ProductColor? productColor, string? message = ProductColorsBusinessMessages.ProductColorAlreadyExists)
    {
        if (productColor != null)
            throw new BusinessException(message);
        return Task.CompletedTask;
    }

    public async Task ProductColorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductColor? productColor = await _productColorRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductColorShouldExistWhenSelected(productColor);
    }

    public async Task ProductColorNameShouldNotExistWhenSelected(string? name,CancellationToken cancellationToken)
    {
        ProductColor? productColor = await _productColorRepository.GetAsync(
            predicate: pc => string.Equals(pc.Name, name, StringComparison.OrdinalIgnoreCase),
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        await ProductColorShouldNotExistWhenSelected(productColor, ProductColorsBusinessMessages.ColorNameAlreadyExists);
    }

    public async Task ProductColorNameShouldNotExistWhenUpdated(Guid id, string? name, CancellationToken cancellationToken)
    {  ProductColor? productColor = await _productColorRepository.GetAsync(
            predicate: pb => string.Equals(pb.Name, name, StringComparison.OrdinalIgnoreCase) && pb.Id !=id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductColorShouldNotExistWhenSelected(productColor, ProductColorsBusinessMessages.ColorNameAlreadyExists);
    }
}