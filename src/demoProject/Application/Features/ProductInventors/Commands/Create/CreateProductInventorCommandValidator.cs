using FluentValidation;

namespace Application.Features.ProductInventors.Commands.Create;

public class CreateProductInventorCommandValidator : AbstractValidator<CreateProductInventorCommand>
{
    public CreateProductInventorCommandValidator()
    {
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThanOrEqualTo(1);
    }
}