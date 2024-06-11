using Application.Features.Barcodes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Barcodes.Rules;

public class BarcodeBusinessRules : BaseBusinessRules
{
    private readonly IBarcodeRepository _barcodeRepository;

    public BarcodeBusinessRules(IBarcodeRepository barcodeRepository)
    {
        _barcodeRepository = barcodeRepository;
    }

    public Task BarcodeShouldExistWhenSelected(Barcode? barcode)
    {
        if (barcode == null)
            throw new BusinessException(BarcodesBusinessMessages.BarcodeNotExists);
        return Task.CompletedTask;
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
}