using FluentValidation;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.BarcodeCode).NotEmpty();
        RuleFor(c => c.Name).Length(3);
    }
}