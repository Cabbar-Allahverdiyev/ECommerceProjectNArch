using FluentValidation;

namespace Application.Features.Barcodes.Queries.GetById;
public class GetByIdBarcodeQueryValidator:AbstractValidator<GetByIdBarcodeQuery>
{
    public GetByIdBarcodeQueryValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
    }
}
