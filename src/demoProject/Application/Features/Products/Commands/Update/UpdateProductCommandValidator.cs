using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.SupplierId).NotEmpty();
        RuleFor(c => c.DiscountId).NotEmpty();
        RuleFor(c => c.InventorId).NotEmpty();
        RuleFor(c => c.UnitsOnOrder).NotEmpty();
        RuleFor(c => c.ReorderLevel).NotEmpty();
        RuleFor(c => c.PurchasePrice).NotEmpty();
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.QuantityPerUnit).NotEmpty();
        RuleFor(c => c.SKU).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IsDiscontinued).NotEmpty();
    }
}