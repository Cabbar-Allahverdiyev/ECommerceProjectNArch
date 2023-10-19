using FluentValidation;

namespace Application.Features.Discounts.Commands.Create;

public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountCommandValidator()
    {
        RuleFor(c => c.DiscountPercent).NotEmpty();
        RuleFor(c => c.DiscountPercent).GreaterThan(1);

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.Description).MaximumLength(50);
    }
}