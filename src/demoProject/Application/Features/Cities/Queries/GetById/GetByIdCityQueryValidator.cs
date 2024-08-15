using FluentValidation;

namespace Application.Features.Cities.Queries.GetById;
public class GetByIdCityQueryValidator:AbstractValidator<GetByIdCityQuery>
{
    public GetByIdCityQueryValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
