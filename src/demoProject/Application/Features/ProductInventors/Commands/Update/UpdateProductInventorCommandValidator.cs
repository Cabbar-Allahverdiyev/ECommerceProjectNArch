using FluentValidation;

namespace Application.Features.ProductInventors.Commands.Update;

public class UpdateProductInventorCommandValidator : AbstractValidator<UpdateProductInventorCommand>
{
    public UpdateProductInventorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}