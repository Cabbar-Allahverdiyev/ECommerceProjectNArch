using FluentValidation;

namespace Application.Features.Companies.Queries.GetByName;

public class GetByNameCompanyQueryValidator : AbstractValidator<GetByNameCompanyQuery>
{
    public GetByNameCompanyQueryValidator() { RuleFor(c => c.Name).NotEmpty(); }
}