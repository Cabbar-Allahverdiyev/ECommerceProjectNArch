using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}