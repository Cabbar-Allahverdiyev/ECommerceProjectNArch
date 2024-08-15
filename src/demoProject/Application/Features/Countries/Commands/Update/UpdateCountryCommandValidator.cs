using FluentValidation;

namespace Application.Features.Countries.Commands.Update;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();

        RuleFor(c => c.BarcodeCode).NotEmpty();
        RuleFor(c => c.BarcodeCode).Length(3);

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(4);
    }
}