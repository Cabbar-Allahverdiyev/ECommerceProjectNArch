using FluentValidation;

namespace Application.Features.Sellers.Queries.GetByShopIdSeller;

public class GetByShopIdSellerQueryValidator : AbstractValidator<GetByShopIdSellerQuery>
{
    public GetByShopIdSellerQueryValidator()
    {
        RuleFor(r => r.ShopId).NotEmpty();
    }
}