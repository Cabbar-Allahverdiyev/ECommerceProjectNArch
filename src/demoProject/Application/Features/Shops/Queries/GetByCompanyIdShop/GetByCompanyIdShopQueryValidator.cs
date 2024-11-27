using FluentValidation;

namespace Application.Features.Shops.Queries.GetByCompanyId;

public class GetByCompanyIdShopQueryValidator : AbstractValidator<GetByCompanyIdShopQuery>
{
    public GetByCompanyIdShopQueryValidator()
    {
        RuleFor(r => r.CompanyId).NotEmpty();
    }
}