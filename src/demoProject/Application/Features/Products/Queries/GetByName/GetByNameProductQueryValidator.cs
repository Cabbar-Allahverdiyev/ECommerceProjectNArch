using FluentValidation;

namespace Application.Features.Products.Queries.GetByName;

public class GetByNameProductQueryValidator : AbstractValidator<GetByNameProductQuery>
{
    public GetByNameProductQueryValidator() { RuleFor(r => r.Name); }
}