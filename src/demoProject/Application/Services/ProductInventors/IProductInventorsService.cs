using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductInventors;

public interface IProductInventorsService
{
    Task<ProductInventor?> GetAsync(
        Expression<Func<ProductInventor, bool>> predicate,
        Func<IQueryable<ProductInventor>, IIncludableQueryable<ProductInventor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductInventor>?> GetListAsync(
        Expression<Func<ProductInventor, bool>>? predicate = null,
        Func<IQueryable<ProductInventor>, IOrderedQueryable<ProductInventor>>? orderBy = null,
        Func<IQueryable<ProductInventor>, IIncludableQueryable<ProductInventor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductInventor> AddAsync(ProductInventor productInventor);
    Task<ProductInventor> UpdateAsync(ProductInventor productInventor);
    Task<ProductInventor> DeleteAsync(ProductInventor productInventor, bool permanent = false);
}
