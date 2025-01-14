using FluentValidation;

namespace Application.Features.Discounts.Queries.GetByName;
public class GetByNameDiscountQueryValidator : AbstractValidator<GetByNameDiscountQuery>
{
    public GetByNameDiscountQueryValidator()
    {
        RuleFor(d => d.Name).NotEmpty();
    }
}
