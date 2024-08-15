using Application.Features.ProductInventors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductInventors;

public class ProductInventorsManager : IProductInventorsService
{
    private readonly IProductInventorRepository _productInventorRepository;
    private readonly ProductInventorBusinessRules _productInventorBusinessRules;

    public ProductInventorsManager(IProductInventorRepository productInventorRepository, ProductInventorBusinessRules productInventorBusinessRules)
    {
        _productInventorRepository = productInventorRepository;
        _productInventorBusinessRules = productInventorBusinessRules;
    }

    public async Task<ProductInventor?> GetAsync(
        Expression<Func<ProductInventor, bool>> predicate,
        Func<IQueryable<ProductInventor>, IIncludableQueryable<ProductInventor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductInventor? productInventor = await _productInventorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productInventor;
    }

    public async Task<IPaginate<ProductInventor>?> GetListAsync(
        Expression<Func<ProductInventor, bool>>? predicate = null,
        Func<IQueryable<ProductInventor>, IOrderedQueryable<ProductInventor>>? orderBy = null,
        Func<IQueryable<ProductInventor>, IIncludableQueryable<ProductInventor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductInventor> productInventorList = await _productInventorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productInventorList;
    }

    public async Task<ProductInventor> AddAsync(ProductInventor productInventor)
    {
        ProductInventor addedProductInventor = await _productInventorRepository.AddAsync(productInventor);

        return addedProductInventor;
    }

    public async Task<ProductInventor> UpdateAsync(ProductInventor productInventor)
    {
        ProductInventor updatedProductInventor = await _productInventorRepository.UpdateAsync(productInventor);

        return updatedProductInventor;
    }

    public async Task<ProductInventor> DeleteAsync(ProductInventor productInventor, bool permanent = false)
    {
        ProductInventor deletedProductInventor = await _productInventorRepository.DeleteAsync(productInventor);

        return deletedProductInventor;
    }
}
