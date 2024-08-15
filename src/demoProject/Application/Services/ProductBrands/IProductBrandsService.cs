using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductBrands;

public interface IProductBrandsService
{
    Task<ProductBrand?> GetAsync(
        Expression<Func<ProductBrand, bool>> predicate,
        Func<IQueryable<ProductBrand>, IIncludableQueryable<ProductBrand, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductBrand>?> GetListAsync(
        Expression<Func<ProductBrand, bool>>? predicate = null,
        Func<IQueryable<ProductBrand>, IOrderedQueryable<ProductBrand>>? orderBy = null,
        Func<IQueryable<ProductBrand>, IIncludableQueryable<ProductBrand, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductBrand> AddAsync(ProductBrand productBrand);
    Task<ProductBrand> UpdateAsync(ProductBrand productBrand);
    Task<ProductBrand> DeleteAsync(ProductBrand productBrand, bool permanent = false);
}
