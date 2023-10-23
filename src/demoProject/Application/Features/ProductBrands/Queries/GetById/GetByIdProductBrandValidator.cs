using FluentValidation;

namespace Application.Features.ProductBrands.Queries.GetById;
public class GetByIdProductBrandValidator:AbstractValidator<GetByIdProductBrandQuery>
{
    public GetByIdProductBrandValidator()
    {
        RuleFor(p=>p.Id).NotEmpty();
    }
}
