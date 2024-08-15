using FluentValidation;

namespace Application.Features.ProductCategories.Queries.GetById;
public class GetByIdProductCategoryQueryValidator:AbstractValidator<GetByIdProductCategoryQuery>
{
    public GetByIdProductCategoryQueryValidator()
    {
        RuleFor(c => c.Id).NotEmpty(); 
    }
}
