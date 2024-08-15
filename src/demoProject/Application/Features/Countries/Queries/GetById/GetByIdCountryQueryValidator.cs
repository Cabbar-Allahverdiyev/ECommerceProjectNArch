using FluentValidation;

namespace Application.Features.Countries.Queries.GetById;
public class GetByIdCountryQueryValidator:AbstractValidator<GetByIdCountryQuery>
{
    public GetByIdCountryQueryValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
