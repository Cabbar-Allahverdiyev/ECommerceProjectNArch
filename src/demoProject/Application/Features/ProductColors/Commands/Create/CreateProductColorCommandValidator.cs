using FluentValidation;

namespace Application.Features.ProductColors.Commands.Create;

public class CreateProductColorCommandValidator : AbstractValidator<CreateProductColorCommand>
{
    public CreateProductColorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
    }
}