using FluentValidation;

namespace Application.Features.Barcodes.Commands.Delete;

public class DeleteBarcodeCommandValidator : AbstractValidator<DeleteBarcodeCommand>
{
    public DeleteBarcodeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}