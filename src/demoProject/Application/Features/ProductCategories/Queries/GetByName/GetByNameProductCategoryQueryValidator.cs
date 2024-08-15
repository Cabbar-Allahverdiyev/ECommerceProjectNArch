using FluentValidation;

namespace Application.Features.ProductCategories.Queries.GetByName;

public class GetByNameProductCategoryQueryValidator : AbstractValidator<GetByNameProductCategoryQuery>
{
    public GetByNameProductCategoryQueryValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}