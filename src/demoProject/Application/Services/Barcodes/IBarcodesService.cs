using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Barcodes;

public interface IBarcodesService
{
    Task<Barcode?> GetAsync(
        Expression<Func<Barcode, bool>> predicate,
        Func<IQueryable<Barcode>, IIncludableQueryable<Barcode, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Barcode>?> GetListAsync(
        Expression<Func<Barcode, bool>>? predicate = null,
        Func<IQueryable<Barcode>, IOrderedQueryable<Barcode>>? orderBy = null,
        Func<IQueryable<Barcode>, IIncludableQueryable<Barcode, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Barcode> AddAsync(Barcode barcode,Guid? supplierId);
    Task<Barcode> UpdateAsync(Barcode barcode);
    Task<Barcode> DeleteAsync(Barcode barcode, bool permanent = false);
}
