using FluentValidation;

namespace Application.Features.Countries.Queries.GetByName;

public class GetByNameCountryQueryValidator : AbstractValidator<GetByNameCountryQuery>
{
    public GetByNameCountryQueryValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}