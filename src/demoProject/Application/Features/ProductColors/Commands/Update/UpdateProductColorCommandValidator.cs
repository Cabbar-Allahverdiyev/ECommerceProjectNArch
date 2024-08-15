using FluentValidation;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdateProductColorCommandValidator : AbstractValidator<UpdateProductColorCommand>
{
    public UpdateProductColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
    }
}