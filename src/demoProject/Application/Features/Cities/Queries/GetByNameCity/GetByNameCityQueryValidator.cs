using FluentValidation;

namespace Application.Features.Cities.Queries.GetByNameCity;

public class GetByNameCityQueryValidator : AbstractValidator<GetByNameCityQuery>
{
    public GetByNameCityQueryValidator()
    {
        RuleFor(c=>c.Name).NotEmpty();
    }
}