using FluentValidation;

namespace Application.Features.Companies.Queries.GetByNameCompany;

public class GetByNameCompanyQueryValidator : AbstractValidator<GetByNameCompanyQuery>
{
    public GetByNameCompanyQueryValidator() { RuleFor(c => c.Name).NotEmpty(); }
}