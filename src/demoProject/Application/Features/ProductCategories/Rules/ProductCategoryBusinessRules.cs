using Application.Features.ProductCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;
using System.Threading;

namespace Application.Features.ProductCategories.Rules;

public class ProductCategoryBusinessRules : BaseBusinessRules
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryBusinessRules(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public Task ProductCategoryShouldExistWhenSelected(ProductCategory? productCategory)
    {
        if (productCategory == null)
            throw new BusinessException(ProductCategoriesBusinessMessages.ProductCategoryNotExists);
        return Task.CompletedTask;
    }

  
    public Task ProductCategoryShouldNotExistWhenSelected(ProductCategory? productCategory)
    {
        if (productCategory != null)
            throw new BusinessException(ProductCategoriesBusinessMessages.ProductCategoryAlreadyExists);
        return Task.CompletedTask;
    }


    public async Task ProductCategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductCategory? productCategory = await _productCategoryRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductCategoryShouldExistWhenSelected(productCategory);
    }

    public async Task ProductCategoryNameShouldNotExistWhenSelected(string? name,CancellationToken cancellationToken)
    {
        ProductCategory? productCategory = await _productCategoryRepository.GetAsync(
          predicate: pc => string.Equals(pc.Name,name,StringComparison.OrdinalIgnoreCase),
        enableTracking: false,
          cancellationToken: cancellationToken
      );
        await ProductCategoryShouldNotExistWhenSelected(productCategory);
    }
}