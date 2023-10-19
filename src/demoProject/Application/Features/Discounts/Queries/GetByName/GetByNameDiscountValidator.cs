using FluentValidation;

namespace Application.Features.Discounts.Queries.GetByName;
public class GetByNameDiscountValidator : AbstractValidator<GetByNameDiscountQuery>
{
    public GetByNameDiscountValidator()
    {
        RuleFor(d => d.Name).NotEmpty();
    }
}
