using Application.Features.ProductBrands.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductBrands;

public class ProductBrandsManager : IProductBrandsService
{
    private readonly IProductBrandRepository _productBrandRepository;
    private readonly ProductBrandBusinessRules _productBrandBusinessRules;

    public ProductBrandsManager(IProductBrandRepository productBrandRepository, ProductBrandBusinessRules productBrandBusinessRules)
    {
        _productBrandRepository = productBrandRepository;
        _productBrandBusinessRules = productBrandBusinessRules;
    }

    public async Task<ProductBrand?> GetAsync(
        Expression<Func<ProductBrand, bool>> predicate,
        Func<IQueryable<ProductBrand>, IIncludableQueryable<ProductBrand, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductBrand? productBrand = await _productBrandRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productBrand;
    }

    public async Task<IPaginate<ProductBrand>?> GetListAsync(
        Expression<Func<ProductBrand, bool>>? predicate = null,
        Func<IQueryable<ProductBrand>, IOrderedQueryable<ProductBrand>>? orderBy = null,
        Func<IQueryable<ProductBrand>, IIncludableQueryable<ProductBrand, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductBrand> productBrandList = await _productBrandRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productBrandList;
    }

    public async Task<ProductBrand> AddAsync(ProductBrand productBrand)
    {
        ProductBrand addedProductBrand = await _productBrandRepository.AddAsync(productBrand);

        return addedProductBrand;
    }

    public async Task<ProductBrand> UpdateAsync(ProductBrand productBrand)
    {
        ProductBrand updatedProductBrand = await _productBrandRepository.UpdateAsync(productBrand);

        return updatedProductBrand;
    }

    public async Task<ProductBrand> DeleteAsync(ProductBrand productBrand, bool permanent = false)
    {
        ProductBrand deletedProductBrand = await _productBrandRepository.DeleteAsync(productBrand);

        return deletedProductBrand;
    }
}
