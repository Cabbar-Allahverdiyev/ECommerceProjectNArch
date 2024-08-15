using Application.Features.Barcodes.Constants;
using FluentValidation;

namespace Application.Features.Barcodes.Commands.Create;

public class CreateBarcodeCommandValidator : AbstractValidator<CreateBarcodeCommand>
{
    public CreateBarcodeCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.BarcodeNumber).NotEmpty();
        RuleFor(c => c.BarcodeNumber).Matches("^[0-9]+$").WithMessage(BarcodesBusinessMessages.BarcodeNumberMustContainOnlyDigits);
    }
}