using FluentValidation;

namespace Application.Features.Barcodes.Queries.GetByBarcodeNumber;

public class GetByBarcodeNumberQueryValidator : AbstractValidator<GetByBarcodeNumberQuery>
{
    public GetByBarcodeNumberQueryValidator()
    {
        RuleFor(b => b.BarcodeNumber).NotEmpty();
    }
}