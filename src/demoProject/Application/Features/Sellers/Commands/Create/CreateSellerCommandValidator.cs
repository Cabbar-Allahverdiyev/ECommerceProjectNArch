using FluentValidation;

namespace Application.Features.Sellers.Commands.Create;

public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}