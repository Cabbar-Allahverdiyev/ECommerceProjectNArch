using FluentValidation;

namespace Application.Features.Cities.Queries.GetByName;

public class GetByNameCityQueryValidator : AbstractValidator<GetByNameCityQuery>
{
    public GetByNameCityQueryValidator()
    {
        RuleFor(c=>c.Name).NotEmpty();
    }
}