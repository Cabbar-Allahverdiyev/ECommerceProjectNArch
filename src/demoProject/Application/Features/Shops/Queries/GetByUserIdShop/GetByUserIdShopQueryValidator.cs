using FluentValidation;

namespace Application.Features.Shops.Queries.GetByUserId;

public class GetByUserIdShopQueryValidator : AbstractValidator<GetByUserIdShopQuery>
{
    public GetByUserIdShopQueryValidator()
    {
        RuleFor(s => s.UserId).NotEmpty();
    }
}