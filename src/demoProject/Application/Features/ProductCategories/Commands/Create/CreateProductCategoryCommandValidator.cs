using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);

        RuleFor(c => c.Description).MaximumLength(50);
    }
}