using FluentValidation;

namespace Application.Features.ProductInventors.Commands.Delete;

public class DeleteProductInventorCommandValidator : AbstractValidator<DeleteProductInventorCommand>
{
    public DeleteProductInventorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}