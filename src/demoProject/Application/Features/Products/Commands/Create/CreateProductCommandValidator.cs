using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.SupplierId).NotEmpty();
        RuleFor(c => c.DiscountId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(0);
        RuleFor(c => c.PurchasePrice).NotEmpty();
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.UnitPrice).GreaterThan(0);
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(3);
        RuleFor(c => c.Name).MaximumLength(50);
        RuleFor(c => c.QuantityPerUnit).NotEmpty();
    }
}