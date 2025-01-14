using FluentValidation;

namespace Application.Features.ProductBrands.Queries.GetByName;

public class GetByNameProductBrandQueryValidator : AbstractValidator<GetByNameProductBrandQuery>
{
    public GetByNameProductBrandQueryValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
    }
}