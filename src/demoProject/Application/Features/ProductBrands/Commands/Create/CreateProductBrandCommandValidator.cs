using FluentValidation;

namespace Application.Features.ProductBrands.Commands.Create;

public class CreateProductBrandCommandValidator : AbstractValidator<CreateProductBrandCommand>
{
    public CreateProductBrandCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.Description).MaximumLength(50);
    }
}