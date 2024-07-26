using Application.Features.Barcodes.Constants;
using FluentValidation;

namespace Application.Features.Barcodes.Commands.Update;

public class UpdateBarcodeCommandValidator : AbstractValidator<UpdateBarcodeCommand>
{
    public UpdateBarcodeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.BarcodeNumber).NotEmpty();
        RuleFor(c => c.BarcodeNumber).Matches("^[0-9]+$").WithMessage(BarcodesBusinessMessages.BarcodeNumberMustContainOnlyDigits);

    }
}