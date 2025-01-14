using FluentValidation;

namespace Application.Features.Shops.Queries.GetListByCompanyName;

public class GetListByCompanyNameShopQueryValidator : AbstractValidator<GetListByCompanyNameShopQuery>
{
    public GetListByCompanyNameShopQueryValidator()
    {
        RuleFor(s=>s.CompanyName).NotNull().NotEmpty();
        RuleFor(s=>s.PageRequest).NotNull().NotEmpty();
    }
}