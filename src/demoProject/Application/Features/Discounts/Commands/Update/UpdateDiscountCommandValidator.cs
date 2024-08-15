using FluentValidation;

namespace Application.Features.Discounts.Commands.Update;

public class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommand>
{
    public UpdateDiscountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Id).NotEqual(default(Guid));

        RuleFor(c => c.DiscountPercent).NotEmpty();
        RuleFor(c => c.DiscountPercent).GreaterThan(1);

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.Description).MaximumLength(50);
    }
}