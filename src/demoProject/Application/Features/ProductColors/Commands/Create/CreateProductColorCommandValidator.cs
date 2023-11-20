using FluentValidation;

namespace Application.Features.ProductColors.Commands.Create;

public class CreateProductColorCommandValidator : AbstractValidator<CreateProductColorCommand>
{
    public CreateProductColorCommandValidator()
    {
        RuleFor(c => c.Red).NotEmpty();
        RuleFor(c => c.Green).NotEmpty();
        RuleFor(c => c.Blue).NotEmpty();
    }
}