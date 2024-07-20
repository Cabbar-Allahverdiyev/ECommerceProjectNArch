using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Barcodes;

public class BarcodesManager : IBarcodesService
{
    private readonly IBarcodeRepository _barcodeRepository;
    private readonly BarcodeBusinessRules _barcodeBusinessRules;

    public BarcodesManager(IBarcodeRepository barcodeRepository, BarcodeBusinessRules barcodeBusinessRules)
    {
        _barcodeRepository = barcodeRepository;
        _barcodeBusinessRules = barcodeBusinessRules;
    }

    public async Task<Barcode?> GetAsync(
        Expression<Func<Barcode, bool>> predicate,
        Func<IQueryable<Barcode>, IIncludableQueryable<Barcode, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Barcode? barcode = await _barcodeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return barcode;
    }

    public async Task<IPaginate<Barcode>?> GetListAsync(
        Expression<Func<Barcode, bool>>? predicate = null,
        Func<IQueryable<Barcode>, IOrderedQueryable<Barcode>>? orderBy = null,
        Func<IQueryable<Barcode>, IIncludableQueryable<Barcode, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Barcode> barcodeList = await _barcodeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return barcodeList;
    }

    public async Task<Barcode> AddAsync(Barcode barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode.BarcodeNumber))
            barcode.BarcodeNumber = BarcodeHelpers.CreateBarcode();
        
        Barcode addedBarcode = await _barcodeRepository.AddAsync(barcode);

        return addedBarcode;
    }

    public async Task<Barcode> UpdateAsync(Barcode barcode)
    {
        Barcode updatedBarcode = await _barcodeRepository.UpdateAsync(barcode);

        return updatedBarcode;
    }

    public async Task<Barcode> DeleteAsync(Barcode barcode, bool permanent = false)
    {
        Barcode deletedBarcode = await _barcodeRepository.DeleteAsync(barcode);

        return deletedBarcode;
    }
}
