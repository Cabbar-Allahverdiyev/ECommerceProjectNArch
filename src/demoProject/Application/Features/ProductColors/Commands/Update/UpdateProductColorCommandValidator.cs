using FluentValidation;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdateProductColorCommandValidator : AbstractValidator<UpdateProductColorCommand>
{
    public UpdateProductColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Red).NotEmpty();
        RuleFor(c => c.Green).NotEmpty();
        RuleFor(c => c.Blue).NotEmpty();
    }
}