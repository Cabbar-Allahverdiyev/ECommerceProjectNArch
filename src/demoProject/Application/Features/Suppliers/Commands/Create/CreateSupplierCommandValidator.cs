using FluentValidation;

namespace Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BarcodeCode).NotEmpty();
        RuleFor(c => c.BarcodeCode).Length(4);
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Description).MaximumLength(100);
    }
}