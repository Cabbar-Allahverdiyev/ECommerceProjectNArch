using Application.Features.Companies.Constants;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.AddressLine1).NotEmpty();
        RuleFor(c => c.AddressLine1).MinimumLength(3);
        RuleFor(c => c.AddressLine1).MaximumLength(100);

        //RuleFor(c =>c.AddressLine2).NotEmpty();

        RuleFor(c => c.CityId).NotEmpty();

        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.Email).MinimumLength(7);
        RuleFor(c => c.Email).MaximumLength(50);

        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.PhoneNumber).MinimumLength(10);
        RuleFor(c => c.PhoneNumber).MaximumLength(13);
        RuleFor(c => c.PhoneNumber).Matches(new Regex(pattern: @"^(\d{12}|\d{13})$"))
            .WithMessage(CompaniesValidationMessages.PhoneNumberNotValid);//bunu duzelt duzgun islemir
    }
}