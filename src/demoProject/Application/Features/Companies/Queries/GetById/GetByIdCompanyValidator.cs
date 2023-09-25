using FluentValidation;

namespace Application.Features.Companies.Queries.GetById;
public class GetByIdCompanyQueryValidator:AbstractValidator<GetByIdCompanyQuery>
{
    public GetByIdCompanyQueryValidator()
    {
        RuleFor(c=>c.Id).NotEmpty();
    }
}
