using FluentValidation;

namespace Application.Features.ProductBrands.Commands.Delete;

public class DeleteProductBrandCommandValidator : AbstractValidator<DeleteProductBrandCommand>
{
    public DeleteProductBrandCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}