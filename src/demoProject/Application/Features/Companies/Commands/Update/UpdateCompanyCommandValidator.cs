using FluentValidation;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AddressLine1).NotEmpty();
        RuleFor(c => c.AddressLine2).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
    }
}