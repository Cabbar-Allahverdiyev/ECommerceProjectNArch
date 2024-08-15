using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();

        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.Description).MaximumLength(50);
    }
}