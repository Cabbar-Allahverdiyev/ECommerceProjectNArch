using FluentValidation;

namespace Application.Features.Discounts.Queries.GetById;
public class GetByIdDiscountValidator : AbstractValidator<GetByIdDiscountQuery>
{
    public GetByIdDiscountValidator()
    {
        RuleFor(d => d.Id).NotEmpty();
    }
}
