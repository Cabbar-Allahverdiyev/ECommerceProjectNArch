using FluentValidation;

namespace Application.Features.Shops.Queries.GetById;
public  class GetByIdShopQueryValidator:AbstractValidator<GetByIdShopQuery>
{
    public GetByIdShopQueryValidator()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
