using FluentValidation;

namespace Application.Features.ProductBrands.Queries.GetByName;

public class GetByNameQueryValidator : AbstractValidator<GetByNameProductBrandQuery>
{
    public GetByNameQueryValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
    }
}