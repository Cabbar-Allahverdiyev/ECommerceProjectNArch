using FluentValidation;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AddressLine1).NotEmpty();
        RuleFor(c => c.AddressLine2).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
    }
}