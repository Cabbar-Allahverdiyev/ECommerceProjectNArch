using FluentValidation;

namespace Application.Features.Sellers.Queries.GetByUserIdSeller;

public class GetByUserIdSellerQueryValidator : AbstractValidator<GetByUserIdSellerQuery>
{
    public GetByUserIdSellerQueryValidator()
    {
        RuleFor(r => r.UserId).NotEmpty();
    }
}