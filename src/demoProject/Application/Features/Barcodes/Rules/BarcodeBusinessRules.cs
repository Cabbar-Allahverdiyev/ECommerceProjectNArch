using Application.Common.Helpers.BarcodeHelpers;
using Application.Features.Barcodes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Barcodes.Rules;

public class BarcodeBusinessRules : BaseBusinessRules
{
    private readonly IBarcodeRepository _barcodeRepository;
    private readonly IBarcodeHelper _barcodeHelper;

    public BarcodeBusinessRules(IBarcodeRepository barcodeRepository, IBarcodeHelper barcodeHelper)
    {
        _barcodeRepository = barcodeRepository;
        _barcodeHelper = barcodeHelper;
    }

    public Task BarcodeShouldExistWhenSelected(Barcode? barcode)
    {
        if (barcode == null)
            throw new BusinessException(BarcodesBusinessMessages.BarcodeNotExists);
        return Task.CompletedTask;
    }

    public Task BarcodeShouldNotExistWhenSelected(Barcode? barcode,string? message= BarcodesBusinessMessages.BarcodeExists)
    {
        if (barcode != null)
            throw new BusinessException(message);
        return Task.CompletedTask;
    }
    public async Task BarcodeNumberShouldNotExistWhenUpdated(Barcode? barcode, string? newBarcodeNumber, CancellationToken cancellationToken)
    {

        if (barcode == null)
            throw new BusinessException(BarcodesBusinessMessages.BarcodeIsNull);
        Barcode? result = await _barcodeRepository.GetAsync(
        predicate: b => string.Equals(b.BarcodeNumber, newBarcodeNumber, StringComparison.OrdinalIgnoreCase)
        && b.Id != barcode.Id,
        enableTracking: false,
        cancellationToken: cancellationToken);
        await BarcodeShouldNotExistWhenSelected(result, BarcodesBusinessMessages.BarcodeNumberAlreadyExists);
    }

    public async Task BarcodeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Barcode? barcode = await _barcodeRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BarcodeShouldExistWhenSelected(barcode);
    }

    public async Task BarcodeNumberShouldNotExistWhenSelected(string? barcodeNumber, CancellationToken cancellationToken)
    {
        Barcode? barcode = await _barcodeRepository.GetAsync(
            predicate: b => string.Equals( b.BarcodeNumber , barcodeNumber, StringComparison.OrdinalIgnoreCase),
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        await BarcodeShouldNotExistWhenSelected(barcode,BarcodesBusinessMessages.BarcodeNumberAlreadyExists); 
    }

  

    public Task ChekSumMustCorrect(string ? chekSum)
    {
        if(_barcodeHelper.CheckChecksum(chekSum)) 
            throw new BusinessException(BarcodesBusinessMessages.BarcodeNumberNotInCorrectFormat);
        return Task.CompletedTask;
    }

   
}