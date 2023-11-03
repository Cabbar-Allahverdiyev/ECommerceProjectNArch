using FluentValidation;

namespace Application.Features.Suppliers.Commands.Create;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}