using FluentValidation;

namespace Application.Features.Barcodes.Commands.Create;

public class CreateBarcodeCommandValidator : AbstractValidator<CreateBarcodeCommand>
{
    public CreateBarcodeCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.BarcodeNumber).NotEmpty();
    }
}